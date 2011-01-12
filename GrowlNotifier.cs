using System;
using Growl.Connector;

namespace InternetConnectionMonitor
{
	internal class GrowlNotifier
	{
		private readonly Presenter presenter;
		private readonly GrowlConnector growl = new GrowlConnector();

		public bool IsConnected { get; private set; }

		public GrowlNotifier(Presenter presenter)
		{
			this.presenter = presenter;

			Application app = new Application(MainWindow.APP_NAME);
			app.Icon = GetGrowlAppImage();

			var info = new NotificationType("INFO", "Information");
			info.Icon = GetGrowlAppImage();

			var goodToProblem = new NotificationType(ID(Quality.Good, Quality.Problem), "Good to problems");
			goodToProblem.Icon = GetGrowlImage(Quality.Problem);

			var goodToFail = new NotificationType(ID(Quality.Good, Quality.Fail), "Good to no connection");
			goodToFail.Icon = GetGrowlImage(Quality.Fail);

			var problemToGood = new NotificationType(ID(Quality.Problem, Quality.Good), "Problems to good");
			problemToGood.Icon = GetGrowlImage(Quality.Good);

			var problemToFail = new NotificationType(ID(Quality.Problem, Quality.Fail), "Problems to no connection");
			problemToFail.Icon = GetGrowlImage(Quality.Fail);

			var failToGood = new NotificationType(ID(Quality.Fail, Quality.Good), "No connection to good");
			failToGood.Icon = GetGrowlImage(Quality.Good);

			var failToProblem = new NotificationType(ID(Quality.Fail, Quality.Problem), "No connection to problems");
			failToProblem.Icon = GetGrowlImage(Quality.Problem);

			IsConnected = true;
			growl.ErrorResponse += (r, s) =>
			                       	{
			                       		if (!r.IsError)
			                       			return;
			                       		IsConnected = false;
			                       	};
			growl.Register(app, new[] {info, goodToProblem, goodToFail, problemToGood, problemToFail, failToGood, failToProblem});

			var oldVal = new Quality[1];
			presenter.PropertyChanging += (s, e) =>
			                              	{
			                              		if (e.PropertyName == BasePresenter.PROPERTIES.CURRENT_QUALITY)
			                              			oldVal[0] = presenter.CurrentQuality;
			                              	};
			presenter.PropertyChanged += (s, e) =>
			                             	{
			                             		if (e.PropertyName == BasePresenter.PROPERTIES.CURRENT_QUALITY)
			                             			ShowChangedNotification(oldVal[0], presenter.CurrentQuality);
			                             	};
		}

// ReSharper disable InconsistentNaming
		private string ID(Quality old, Quality current) // ReSharper restore InconsistentNaming
		{
			return old + "_TO_" + current;
		}

		private string GetGrowlAppImage()
		{
			return presenter.GetFullResourcePath("Growl_App.png");
		}

		private string GetGrowlImage(Quality quality)
		{
			return presenter.GetFullResourcePath("Growl_" + quality + ".png");
		}

		private void ShowChangedNotification(Quality old, Quality current)
		{
			if (!presenter.NotificationsEnabled)
				return;

			Notification notification = new Notification(MainWindow.APP_NAME, old + "_TO_" + current, null, GetTitle(old, current), presenter.GetQualityStateText());
			growl.Notify(notification);
		}

		private string GetTitle(Quality old, Quality current)
		{
			var id = ID(old, current);

			if (id == ID(Quality.Good, Quality.Problem)) return "Connection is having problems";
			if (id == ID(Quality.Good, Quality.Fail)) return "Lost connection";
			if (id == ID(Quality.Problem, Quality.Good)) return "Connection is fine again";
			if (id == ID(Quality.Problem, Quality.Fail)) return "Lost connection (had problems)";
			if (id == ID(Quality.Fail, Quality.Good)) return "Internet recovered";
			if (id == ID(Quality.Fail, Quality.Problem)) return "Internet recovered but is problematic";

			throw new Exception();
		}

		public void ShowInformation()
		{
			Notification notification = new Notification(MainWindow.APP_NAME, "INFO", null, presenter.GetQualityStateTitle(), presenter.GetQualityStateText(), GetGrowlImage(presenter.CurrentQuality), false, Priority.Normal, null);
			growl.Notify(notification);
		}
	}
}
