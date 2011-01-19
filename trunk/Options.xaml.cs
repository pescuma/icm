using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace org.pescuma.icm
{
	/// <summary>
	/// Interaction logic for Options.xaml
	/// </summary>
	public partial class Options : Window
	{
		private readonly Presenter presenter;

		public Options(Presenter presenter)
		{
			this.presenter = presenter;
			InitializeComponent();
		}

		private void NumericPreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
				e.Handled = true;
		}

		private void NumericPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !e.Text.All(Char.IsDigit);
			base.OnPreviewTextInput(e);
		}

		private void DoublePreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			//e.Handled = !e.Text.All(Char.IsNumber);
			base.OnPreviewTextInput(e);
		}

		private void OnOK(object sender, RoutedEventArgs e)
		{
			presenter.Config.CopyFrom((Configuration) DataContext);
			presenter.Config.GrowlPassword = GrowlPassword.Password;

			Properties.Settings.Default.Servers = presenter.Config.Servers;
			Properties.Settings.Default.Bytes = presenter.Config.Bytes;
			Properties.Settings.Default.ProblemThresholdMs = presenter.Config.ProblemThresholdMs;
			Properties.Settings.Default.FailThresholdMs = presenter.Config.FailThresholdMs;
			Properties.Settings.Default.TimeoutMs = presenter.Config.TimeoutMs;
			Properties.Settings.Default.TestEachMs = presenter.Config.TestEachMs;
			Properties.Settings.Default.ZenerFactor = presenter.Config.ZenerFactor;
			Properties.Settings.Default.AverageWindow = presenter.Config.AverageWindow;
			Properties.Settings.Default.AverageType = presenter.Config.AverageType;
			Properties.Settings.Default.GaussianAverageSigma = presenter.Config.GaussianAverageSigma;
			Properties.Settings.Default.GaussianAverageGuessWindow = presenter.Config.GaussianAverageGuessWindow;
			Properties.Settings.Default.GrowlServer = presenter.Config.GrowlServer;
			Properties.Settings.Default.GrowlPassword = presenter.Config.GrowlPassword;
			Properties.Settings.Default.MaxHistoryPoints = presenter.Config.MaxHistoryPoints;
			Properties.Settings.Default.Save();

			Close();
		}

		private void OnCancel(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void OnResetDefault(object sender, RoutedEventArgs e)
		{
			Configuration config = (Configuration) DataContext;

			var defaultConfig = new Configuration();
			defaultConfig.Servers = config.Servers;
			defaultConfig.GrowlServer = config.GrowlServer;
			defaultConfig.GrowlPassword = config.GrowlPassword;

			config.CopyFrom(defaultConfig);
		}
	}
}
