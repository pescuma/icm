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
			if (Config.AverageType == 1)
				avg = new HistoricalAverageCalculator(Config.AverageWindow);
			else
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

			Console.WriteLine(string.Format("Ping: {0:0000} -> avg = {1:0000} -> {2}", dt, AvgPingTimeMs, CurrentQuality));
		}

		private Quality ComputeQuality(int pingTime)
		{
			int problemThresholdMs;
			int failThresholdMs;

			// Avoid switching too much when closer to the border
			switch (CurrentQuality)
			{
				case Quality.Good:
					problemThresholdMs = (int) (Config.ProblemThresholdMs + Config.ZenerFactor * Config.ProblemThresholdMs);
					failThresholdMs = Config.FailThresholdMs;
					break;
				case Quality.Problem:
					problemThresholdMs = (int) (Config.ProblemThresholdMs - Config.ZenerFactor * Config.ProblemThresholdMs);
					failThresholdMs = (int) (Config.FailThresholdMs + Config.ZenerFactor * (Config.FailThresholdMs - Config.ProblemThresholdMs));
					break;
				case Quality.Fail:
					problemThresholdMs = Config.ProblemThresholdMs;
					failThresholdMs = (int) (Config.FailThresholdMs - Config.ZenerFactor * (Config.FailThresholdMs - Config.ProblemThresholdMs));
					break;
				default:
					throw new Exception();
			}

			if (pingTime <= problemThresholdMs)
				return Quality.Good;
			else if (pingTime <= failThresholdMs)
				return Quality.Problem;
			else
				return Quality.Fail;
		}

		public string GetQualityStateTitle()
		{
			switch (CurrentQuality)
			{
				case Quality.Good:
					return "Internet connection is good";
				case Quality.Problem:
					return "Internet connection has some problems";
				case Quality.Fail:
					return "No internet connection";
			}
			throw new Exception();
		}

		public string GetQualityStateText()
		{
			return "Average ping time: " + AvgPingTimeMs + " ms";
		}

		public string GetFullResourcePath(string filename)
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

		public bool NotificationsEnabled
		{
			get { return avg.SampleSize == avg.WindowSize; }
		}
	}
}
