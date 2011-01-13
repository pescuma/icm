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
		public Options()
		{
			InitializeComponent();
		}

		private void NumericPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !e.Text.All(Char.IsNumber);
			base.OnPreviewTextInput(e);
		}

		private void DoublePreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = !e.Text.All(Char.IsNumber);
			base.OnPreviewTextInput(e);
		}
	}
}
