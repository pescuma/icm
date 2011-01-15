using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using AppLimit.NetSparkle;
using Point = System.Windows.Point;

namespace InternetConnectionMonitor
{
	public partial class MainWindow : Window
	{
		public const string APP_NAME = "Internet Connection Monitor";

		private Sparkle sparkle;

		private readonly Presenter presenter = new Presenter();
		private System.Windows.Forms.NotifyIcon trayIcon;
		private GrowlNotifier growlNofier;

		private bool moving;
		private Vector toCenter;
		private Options options;

		public MainWindow()
		{
			InitializeComponent();

#if DEBUG
			var checkOnStart = true;
#else
			var checkOnStart = true;
#endif
// ReSharper disable ConditionIsAlwaysTrueOrFalse
			sparkle = new Sparkle("http://icm.googlecode.com/svn-history/updater/versioninfo.xml", checkOnStart);
// ReSharper restore ConditionIsAlwaysTrueOrFalse

			InitPosition();

			InitTray();

			InitContextMenu();

			growlNofier = new GrowlNotifier(presenter);

			LocationChanged += delegate { StoreWindowPosition(); };
			SizeChanged += delegate { StoreWindowPosition(); };

			presenter.PropertyChanged += (s, e) =>
			                             	{
			                             		if (e.PropertyName == BasePresenter.PROPERTIES.MAIN_IMAGE)
			                             			UpdateImage();
			                             		if (e.PropertyName == BasePresenter.PROPERTIES.TRAY_IMAGE)
			                             			UpdateTray();
			                             	};
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
			trayIcon = new System.Windows.Forms.NotifyIcon();
			trayIcon.Text = APP_NAME;
			trayIcon.Visible = true;

			trayIcon.ContextMenu = new System.Windows.Forms.ContextMenu();

			var showHide = new System.Windows.Forms.MenuItem();
			showHide.DefaultItem = true;
			showHide.Text = "Show / Hide";
			showHide.Click += delegate { ShowHide(); };
			trayIcon.ContextMenu.MenuItems.Add(showHide);

			trayIcon.ContextMenu.MenuItems.Add("Show &Information", delegate { ShowInformation(); });
			trayIcon.ContextMenu.MenuItems.Add("-");
			trayIcon.ContextMenu.MenuItems.Add("&Options...", delegate { ShowOptions(); });
			trayIcon.ContextMenu.MenuItems.Add("-");
			trayIcon.ContextMenu.MenuItems.Add("E&xit", delegate { Close(); });

			trayIcon.DoubleClick += delegate { ShowInformation(); };

			UpdateTray();
		}

		private void UpdateTray()
		{
			trayIcon.Icon = new Icon(presenter.TrayImage);
		}

		private void InitContextMenu()
		{
			ContextMenu menu = new ContextMenu();

			MenuItem menuItem = new MenuItem {Header = "Show / Hide"};
			menuItem.Click += delegate { ShowHide(); };
			menu.Items.Add(menuItem);

			menuItem = new MenuItem {Header = "Show _Information"};
			menuItem.Click += delegate { ShowInformation(); };
			menu.Items.Add(menuItem);

			menu.Items.Add(new Separator());

			menuItem = new MenuItem {Header = "_Options..."};
			menuItem.Click += delegate { ShowOptions(); };
			menu.Items.Add(menuItem);

			menu.Items.Add(new Separator());

			menuItem = new MenuItem {Header = "E_xit"};
			menuItem.Click += delegate { Close(); };
			menu.Items.Add(menuItem);

			ContextMenu = menu;
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

		private void ShowInformation()
		{
			if (growlNofier.IsConnected)
				growlNofier.ShowInformation();
			else
				trayIcon.ShowBalloonTip(2000, presenter.GetQualityStateTitle(), presenter.GetQualityStateInfo(), GetBalloonIcon());
		}

		private System.Windows.Forms.ToolTipIcon GetBalloonIcon()
		{
			switch (presenter.CurrentQuality)
			{
				case Quality.Good:
					return System.Windows.Forms.ToolTipIcon.Info;
				case Quality.Problem:
					return System.Windows.Forms.ToolTipIcon.Warning;
				case Quality.Fail:
					return System.Windows.Forms.ToolTipIcon.Error;
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

		private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ShowInformation();
		}

		private BitmapImage LoadImage(string imageFullPath)
		{
			BitmapImage img = new BitmapImage();
			img.BeginInit();
			img.UriSource = new Uri(imageFullPath, UriKind.Absolute);
			img.EndInit();
			return img;
		}

		private void ShowOptions()
		{
			if (options != null)
			{
				options.Focus();
				return;
			}

			options = new Options(presenter);
			options.DataContext = presenter.Config.Clone();
			options.Closed += delegate { options = null; };

			options.Show();
		}
	}
}
