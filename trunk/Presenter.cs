using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace org.pescuma.icm
{
	[DataContract]
	public class Presenter : BasePresenter
	{
		private readonly Pinger pinger;
		private IAverageCalculator avg;

		public Presenter()
		{
			Config.Servers = Properties.Settings.Default.Servers;
			Config.Bytes = Properties.Settings.Default.Bytes;
			Config.ProblemThresholdMs = Properties.Settings.Default.ProblemThresholdMs;
			Config.FailThresholdMs = Properties.Settings.Default.FailThresholdMs;
			Config.TimeoutMs = Properties.Settings.Default.TimeoutMs;
			Config.TestEachMs = Properties.Settings.Default.TestEachMs;
			Config.ZenerFactor = Properties.Settings.Default.ZenerFactor;
			Config.AverageWindow = Properties.Settings.Default.AverageWindow;
			Config.AverageType = Properties.Settings.Default.AverageType;
			Config.GaussianAverageSigma = Properties.Settings.Default.GaussianAverageSigma;
			Config.GaussianAverageGuessWindow = Properties.Settings.Default.GaussianAverageGuessWindow;
			Config.GrowlServer = Properties.Settings.Default.GrowlServer;
			Config.GrowlPassword = Properties.Settings.Default.GrowlPassword;

			avg = CreateAverageCalculator();

			pinger = new Pinger(Config, OnPingCompleted);
			pinger.Start();

			PropertyChanging += NotifyDependentPropertyChanging;
			PropertyChanged += NotifyDependentPropertyChanged;

			Config.PropertyChanged += (s, e) =>
			                          	{
			                          		if (e.PropertyName == BaseConfiguration.PROPERTIES.AVERAGE_WINDOW)
			                          		{
			                          			avg.WindowSize = Config.AverageWindow;
			                          		}
			                          		else if (e.PropertyName == BaseConfiguration.PROPERTIES.AVERAGE_TYPE)
			                          		{
			                          			avg = CreateAverageCalculator();
			                          		}
			                          		else if (e.PropertyName == BaseConfiguration.PROPERTIES.GAUSSIAN_AVERAGE_GUESS_WINDOW)
			                          		{
			                          			var gavg = avg as GaussianAverageCalculator;
			                          			if (gavg != null)
			                          				gavg.GuessWindowSize = Config.GaussianAverageGuessWindow;
			                          		}
			                          		else if (e.PropertyName == BaseConfiguration.PROPERTIES.GAUSSIAN_AVERAGE_SIGMA)
			                          		{
			                          			var gavg = avg as GaussianAverageCalculator;
			                          			if (gavg != null)
			                          				gavg.Sigma = Config.GaussianAverageSigma;
			                          		}
			                          	};
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

		private void OnPingCompleted(string server, int dt)
		{
			var error = (dt == -1);
			if (error)
				dt = Config.TimeoutMs;

			avg.Add(dt);

			LastPingTimeMs = dt;
			AvgPingTimeMs = (int) avg.Average;
			CurrentQuality = (error ? Quality.Fail : ComputeQuality(AvgPingTimeMs));

			Console.WriteLine(string.Format("Ping: {0} {1}ms -> avg = {2}ms -> {3}", server.PadLeft(15), error ? "----" : dt.ToString().PadLeft(4), AvgPingTimeMs.ToString().PadLeft(4), CurrentQuality));
		}

		private Quality ComputeQuality(int pingTime)
		{
			int problemThresholdMs;
			int failThresholdMs;

			// Avoid switching too much when closer to the border
			switch (CurrentQuality)
			{
				case Quality.Good:
					problemThresholdMs = Math.Min(Config.ProblemThresholdMs + ComputeZener(Config.ProblemThresholdMs), Config.TimeoutMs - 1);
					failThresholdMs = Config.TimeoutMs;
					break;
				case Quality.Problem:
					problemThresholdMs = Math.Max(Config.ProblemThresholdMs - ComputeZener(Config.ProblemThresholdMs), 1);
					failThresholdMs = Math.Min(Config.FailThresholdMs + ComputeZener(Config.FailThresholdMs - Config.ProblemThresholdMs), Config.TimeoutMs - 1);
					break;
				case Quality.Fail:
					problemThresholdMs = -1;
					failThresholdMs = Math.Max(Config.FailThresholdMs - ComputeZener(Config.FailThresholdMs - Config.ProblemThresholdMs), 1);
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
			var skinPath = Path.Combine(exePath, @"..\..\Resources");
#else
			var skinPath = Path.Combine(exePath, @"DefaultSkin");
#endif
			var result = Path.Combine(skinPath, filename.ToLower());
			result = Path.GetFullPath(result);

			return result;
		}

		public bool NotificationsEnabled
		{
			get { return avg.WindowIsFull; }
		}
	}
}
