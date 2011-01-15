using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace InternetConnectionMonitor
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

			Close();
		}

		private void OnCancel(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
