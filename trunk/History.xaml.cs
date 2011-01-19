using System.Windows;

namespace org.pescuma.icm
{
	/// <summary>
	/// Interaction logic for History.xaml
	/// </summary>
	public partial class History : Window
	{
		public History()
		{
			InitializeComponent();
		}

		private void OnOK(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
