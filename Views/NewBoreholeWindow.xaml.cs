using BoreholeCalculations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BoreholeCalculations.Views
{
	/// <summary>
	/// Interaction logic for NewBoreholeWindow.xaml
	/// </summary>
	public partial class NewBoreholeWindow : Window
	{
		public NewBoreholeWindow()
		{
			InitializeComponent();
			Loaded += NewBoreholeWindow_Loaded;
		}

		private void NewBoreholeWindow_Loaded(object sender, RoutedEventArgs e)
		{
            if (DataContext is ICloseWindow close)
            {
				close.Close += () =>
				{
					this.Close();
				};
            }
        }

		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex(@"^-?\d*\.?\d*$");
			e.Handled = !regex.IsMatch((sender as TextBox).Text + e.Text);
		}
		private void NumberValidationPositiveTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex(@"^\d*\.?\d*$");
			e.Handled = !regex.IsMatch((sender as TextBox).Text + e.Text);
		}
	}
}
