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
			avg = CreateAverageCalculator();

			pinger = new Pinger(Config, OnPingCompleted);
			pinger.Start();

			PropertyChanging += NotifyDependentPropertyChanging;
			PropertyChanged += NotifyDependentPropertyChanged;
		}

		private IAverageCalculator CreateAverageCalculator()
		{
			switch (Config.AverageType)
			{
				case 1:
					return new HistoricalAverageCalculator(Config.AverageWindow);
				case 2:
					return new GaussianAverageCalculator(Config.AverageWindow, Config.GaussianAverageSigma, Config.GaussianAverageGuessWindow);
				default:
					return new AverageCalculator(Config.AverageWindow);
			}
		}

		public Presenter(Presenter other)
			: base(other)
		{
		}

		public int LastPingTimeMs { get; private set; }

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

			LastPingTimeMs = dt;
			AvgPingTimeMs = (int) avg.Average;
			CurrentQuality = ComputeQuality(AvgPingTimeMs);

			Console.WriteLine(string.Format("Ping: {0} -> avg = {1} -> {2}", dt == Config.TimeoutMs ? "----" : dt.ToString().PadLeft(4), AvgPingTimeMs.ToString().PadLeft(4), CurrentQuality));
		}

		private Quality ComputeQuality(int pingTime)
		{
			int problemThresholdMs;
			int failThresholdMs;

			// Avoid switching too much when closer to the border
			switch (CurrentQuality)
			{
				case Quality.Good:
					problemThresholdMs = Config.ProblemThresholdMs + ComputeZener(Config.ProblemThresholdMs);
					failThresholdMs = Config.TimeoutMs;
					break;
				case Quality.Problem:
					problemThresholdMs = Config.ProblemThresholdMs - ComputeZener(Config.ProblemThresholdMs);
					failThresholdMs = Config.FailThresholdMs + ComputeZener(Config.FailThresholdMs - Config.ProblemThresholdMs);
					break;
				case Quality.Fail:
					problemThresholdMs = -1;
					failThresholdMs = Config.FailThresholdMs - ComputeZener(Config.FailThresholdMs - Config.ProblemThresholdMs);
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

		private int ComputeZener(int threshold)
		{
			if (Config.ZenerFactor < 1)
				return (int) (Config.ZenerFactor * threshold);
			else
				return (int) Config.ZenerFactor;
		}

		public string GetQualityStateTitle()
		{
			switch (CurrentQuality)
			{
				case Quality.Good:
					return "Internet connection is good";
				case Quality.Problem:
					return "Internet connection is having problems";
				case Quality.Fail:
					return "No internet connection";
			}
			throw new Exception();
		}

		public string GetQualityStateInfo()
		{
			return "Average ping time: " + (AvgPingTimeMs == Config.TimeoutMs ? "no connection" : AvgPingTimeMs + "ms") + "\n" //
			       + "Last ping time: " + (LastPingTimeMs == Config.TimeoutMs ? "timed out" : LastPingTimeMs + "ms");
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
			get { return avg.WindowIsFull; }
		}
	}
}
