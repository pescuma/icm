using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace InternetConnectionMonitor
{
	[DataContract]
	public class Presenter : BasePresenter
	{
		private readonly Pinger pinger;
		private readonly IAverageCalculator avg;

		public Presenter()
		{
			avg = new AverageCalculator(Config.AverageWindow);
			pinger = new Pinger(Config, OnPingCompleted);
			pinger.Start();

			PropertyChanging += NotifyDependentPropertyChanging;
			PropertyChanged += NotifyDependentPropertyChanged;
		}

		public Presenter(Presenter other)
			: base(other)
		{
		}

		private void NotifyDependentPropertyChanging(object sender, PropertyChangingEventArgs e)
		{
			if (e.PropertyName == PROPERTIES.CURRENT_SIDE || e.PropertyName == PROPERTIES.CURRENT_QUALITY)
				NotifyPropertyChanging(PROPERTIES.MAIN_IMAGE);

			if (e.PropertyName == PROPERTIES.CURRENT_QUALITY)
				NotifyPropertyChanging(PROPERTIES.TRAY_IMAGE);
		}

		private void NotifyDependentPropertyChanged(object s, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == PROPERTIES.CURRENT_SIDE || e.PropertyName == PROPERTIES.CURRENT_QUALITY)
				NotifyPropertyChanged(PROPERTIES.MAIN_IMAGE);

			if (e.PropertyName == PROPERTIES.CURRENT_QUALITY)
				NotifyPropertyChanged(PROPERTIES.TRAY_IMAGE);
		}

		protected override string GetMainImage()
		{
			return GetFullResourcePath(CurrentSide + "_" + CurrentQuality + ".png");
		}

		protected override string GetTrayImage()
		{
			return GetFullResourcePath("Tray_" + CurrentQuality + ".ico");
		}

		private void OnPingCompleted(int dt)
		{
			avg.Add(dt);

			AvgPingTimeMs = (int) avg.Average;
			CurrentQuality = ComputeQuality(AvgPingTimeMs);

			Console.WriteLine("AVG: " + AvgPingTimeMs + " -> " + CurrentQuality);
		}

		private Quality ComputeQuality(int pingTime)
		{
			if (pingTime <= Config.ProblemThresholdMs)
				return Quality.Good;
			else if (pingTime <= Config.FailThresholdMs)
				return Quality.Problem;
			else
				return Quality.Fail;
		}

		public string GetBalloonTitle()
		{
			switch (CurrentQuality)
			{
				case Quality.Good:
					return "Internet connection is good";
				case Quality.Problem:
					return "Internet connection has some problem";
				case Quality.Fail:
					return "No internet connection";
			}
			throw new Exception();
		}

		public string GetBalloonText()
		{
			return "Average ping time: " + AvgPingTimeMs + " ms";
		}

		public string GetGrowFailName()
		{
			return "Lost connection";
		}

		public string GetGrowlProblemName()
		{
			return "Problems";
		}

		public string GetGrowlGoodName()
		{
			return "Good connection";
		}

		public string GetGrowlTitle()
		{
			switch (CurrentQuality)
			{
				case Quality.Good:
					return "Internet connection is now good";
				case Quality.Problem:
					return "Internet connection started having problems";
				case Quality.Fail:
					return "Lost internet connection";
			}
			throw new Exception();
		}

		public string GetGrowlAppImage()
		{
			return GetFullResourcePath("Growl_App.png");
		}

		public string GetGrowlImage()
		{
			return GetFullResourcePath("Growl_" + CurrentQuality + ".png");
		}

		public string GetGrowlGoodImage()
		{
			return GetFullResourcePath("Growl_" + Quality.Good + ".png");
		}

		public string GetGrowlProblemImage()
		{
			return GetFullResourcePath("Growl_" + Quality.Problem + ".png");
		}

		public string GetGrowlFailImage()
		{
			return GetFullResourcePath("Growl_" + Quality.Fail + ".png");
		}

		public string GetGrowlText()
		{
			return GetBalloonText();
		}

		private string GetFullResourcePath(string filename)
		{
			var exePath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
			if (exePath == null)
				throw new Exception("Could not get exe path");

#if DEBUG
			exePath = Path.Combine(exePath, @"..\..");
#endif
			var result = Path.Combine(Path.Combine(exePath, @"Resources"), filename.ToLower());
			result = Path.GetFullPath(result);

			return result;
		}
	}
}
