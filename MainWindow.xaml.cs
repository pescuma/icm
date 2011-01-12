using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Growl.Connector;
using Application = Growl.Connector.Application;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Windows.Point;

namespace InternetConnectionMonitor
{
	public partial class MainWindow : Window
	{
		private const string APP_NAME = "Internet Connection Monitor";
		private const string GROWL_GOOD = "GOOD";
		private const string GROWL_PROBLEM = "PROBLEM";
		private const string GROWL_FAIL = "FAIL";

		private readonly Presenter presenter = new Presenter();
		private NotifyIcon trayIcon;
		private GrowlConnector growl;

		private bool moving;
		private Vector toCenter;

		public MainWindow()
		{
			InitializeComponent();

			InitPosition();

			InitTray();

			InitGrowl();

			LocationChanged += delegate { StoreWindowPosition(); };
			SizeChanged += delegate { StoreWindowPosition(); };

			presenter.PropertyChanged += (s, e) =>
			                             	{
			                             		if (e.PropertyName == BasePresenter.PROPERTIES.MAIN_IMAGE)
			                             			UpdateImage();
			                             		if (e.PropertyName == BasePresenter.PROPERTIES.TRAY_IMAGE)
			                             			UpdateTray();
			                             		if (e.PropertyName == BasePresenter.PROPERTIES.CURRENT_QUALITY)
			                             			UpdateGrowl();
			                             	};
		}

		private void InitGrowl()
		{
			growl = new GrowlConnector();

			Application app = new Application(APP_NAME);
			app.Icon = presenter.GetGrowlAppImage();

			NotificationType good = new NotificationType(GROWL_GOOD, presenter.GetGrowlGoodName());
			good.Icon = presenter.GetGrowlGoodImage();

			NotificationType problem = new NotificationType(GROWL_PROBLEM, presenter.GetGrowlProblemName());
			problem.Icon = presenter.GetGrowlProblemImage();

			NotificationType fail = new NotificationType(GROWL_FAIL, presenter.GetGrowFailName());
			fail.Icon = presenter.GetGrowlFailImage();

			growl.Register(app, new[] {good, problem, fail});
		}

		private void UpdateGrowl()
		{
			Notification notification = new Notification(APP_NAME, GetGrowlNotificaionName(), null,
			                                             presenter.GetGrowlTitle(), presenter.GetGrowlText(),
			                                             presenter.GetGrowlImage(), false, Priority.Normal,
			                                             null);
			growl.Notify(notification);
		}

		private string GetGrowlNotificaionName()
		{
			switch (presenter.CurrentQuality)
			{
				case Quality.Good:
					return GROWL_GOOD;
				case Quality.Problem:
					return GROWL_PROBLEM;
				case Quality.Fail:
					return GROWL_FAIL;
			}
			throw new Exception();
		}

		private void InitPosition()
		{
			Point center;
			if (Properties.Settings.Default.CenterX >= 0 && Properties.Settings.Default.CenterY >= 0)
				center = new Point(Properties.Settings.Default.CenterX, Properties.Settings.Default.CenterY);
			else
				center = new Point(Left + Width / 2, Top + Height / 2);

			var screen = WpfScreen.GetScreenFrom(center).DeviceBounds;

			presenter.CurrentSide = GetClosestSide(screen, center);
			UpdateImage();
			UpdatePosition(screen, center, center - new Vector(Width / 2, Height / 2));
		}

		private void UpdateImage()
		{
			var img = LoadImage(presenter.MainImage);

			Img.Source = img;
			Width = Img.Width = img.PixelWidth;
			Height = Img.Height = img.PixelHeight;
		}

		private void InitTray()
		{
			trayIcon = new NotifyIcon();
			trayIcon.Text = APP_NAME;
			trayIcon.Visible = true;

			trayIcon.ContextMenu = new ContextMenu();

			var showHide = new MenuItem();
			showHide.DefaultItem = true;
			showHide.Text = "Show / Hide";
			showHide.Click += delegate { ShowHide(); };
			trayIcon.ContextMenu.MenuItems.Add(showHide);

			trayIcon.ContextMenu.MenuItems.Add("Show &Information", delegate { ShowBalloon(); });
			trayIcon.ContextMenu.MenuItems.Add("-");
			trayIcon.ContextMenu.MenuItems.Add("E&xit", delegate { Close(); });

			trayIcon.DoubleClick += delegate { ShowBalloon(); };

			UpdateTray();
		}

		private void UpdateTray()
		{
			trayIcon.Icon = new Icon(presenter.TrayImage);
		}

		private void StoreWindowPosition()
		{
			if (WindowState == WindowState.Normal)
			{
				Properties.Settings.Default.CenterY = Top + Height / 2;
				Properties.Settings.Default.CenterX = Left + Width / 2;
			}
			else
			{
				Properties.Settings.Default.CenterY = RestoreBounds.Top + RestoreBounds.Height / 2;
				Properties.Settings.Default.CenterX = RestoreBounds.Left + RestoreBounds.Width / 2;
			}
			Properties.Settings.Default.Save();
		}

		private void ShowBalloon()
		{
			trayIcon.ShowBalloonTip(2000, presenter.GetBalloonTitle(), presenter.GetBalloonText(),
			                        GetBalloonIcon());
		}

		private ToolTipIcon GetBalloonIcon()
		{
			switch (presenter.CurrentQuality)
			{
				case Quality.Good:
					return ToolTipIcon.Info;
				case Quality.Problem:
					return ToolTipIcon.Warning;
				case Quality.Fail:
					return ToolTipIcon.Error;
			}
			throw new Exception();
		}

		private void ShowHide()
		{
			if (IsVisible)
				Hide();
			else
				Show();
		}

		private Point TopLeft
		{
			get { return new Point(Left, Top); }
		}

		private Point HalfSize
		{
			get { return new Point(Width / 2, Height / 2); }
		}

		private Point Center
		{
			get { return TopLeft + (Vector) HalfSize; }
		}

		private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			CaptureMouse();

			moving = true;
			toCenter = Center - Win32Utils.GetCursorPos();
		}

		private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			moving = false;

			ReleaseMouseCapture();
		}

		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (moving)
			{
				Point cursor = Win32Utils.GetCursorPos();

				var screen = WpfScreen.GetScreenFrom(cursor).DeviceBounds;

				presenter.CurrentSide = GetClosestSide(screen, cursor);
				UpdatePosition(screen, cursor, (Point) (cursor + toCenter - HalfSize));
			}
		}

		private void UpdatePosition(Rect screen, Point cursor, Point topLeft)
		{
			switch (presenter.CurrentSide)
			{
				case Side.Top:
					topLeft = ToTop(screen, topLeft);
					topLeft = AssertInsideX(screen, cursor, topLeft);
					break;
				case Side.Bottom:
					topLeft = ToBottom(screen, topLeft);
					topLeft.Y -= Height;
					topLeft = AssertInsideX(screen, cursor, topLeft);
					break;
				case Side.Left:
					topLeft = ToLeft(screen, topLeft);
					topLeft = AssertInsideY(screen, cursor, topLeft);
					break;
				case Side.Right:
					topLeft = ToRigth(screen, topLeft);
					topLeft.X -= Width;
					topLeft = AssertInsideY(screen, cursor, topLeft);
					break;
			}

			Top = topLeft.Y;
			Left = topLeft.X;
		}

		private Point AssertInsideX(Rect screen, Point cursor, Point pos)
		{
			if (cursor.X - screen.Left <= screen.Right - cursor.X)
				pos.X = Math.Max(pos.X, screen.Left);
			else
				pos.X = Math.Min(pos.X, screen.Right - Width);

			return pos;
		}

		private Point AssertInsideY(Rect screen, Point cursor, Point pos)
		{
			if (cursor.Y - screen.Top <= screen.Bottom - cursor.Y)
				pos.Y = Math.Max(pos.Y, screen.Top);
			else
				pos.Y = Math.Min(pos.Y, screen.Bottom - Height);

			return pos;
		}

		private Point ToLeft(Rect workingArea, Point p)
		{
			return new Point(workingArea.Left, p.Y);
		}

		private Point ToRigth(Rect workingArea, Point p)
		{
			return new Point(workingArea.Right, p.Y);
		}

		private Point ToTop(Rect workingArea, Point p)
		{
			return new Point(p.X, workingArea.Top);
		}

		private Point ToBottom(Rect workingArea, Point p)
		{
			return new Point(p.X, workingArea.Bottom);
		}

		private Side GetClosestSide(Rect workingArea, Point p)
		{
			var min = (p - ToLeft(workingArea, p)).Length;
			var ret = Side.Left;

			var dist = (p - ToTop(workingArea, p)).Length;
			if (dist < min)
			{
				min = dist;
				ret = Side.Top;
			}

			dist = (p - ToRigth(workingArea, p)).Length;
			if (dist < min)
			{
				min = dist;
				ret = Side.Right;
			}

			dist = (p - ToBottom(workingArea, p)).Length;
			if (dist < min)
				ret = Side.Bottom;

			return ret;
		}

		private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
		}

		private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
		}

		private BitmapImage LoadImage(string imageFullPath)
		{
			BitmapImage img = new BitmapImage();
			img.BeginInit();
			img.UriSource = new Uri(imageFullPath, UriKind.Absolute);
			img.EndInit();
			return img;
		}
	}
}
