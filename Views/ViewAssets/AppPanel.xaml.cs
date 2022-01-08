using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TakeOff.Views.ViewAssets
{
    /// <summary>
    /// Interaction logic for AppPanel.xaml
    /// </summary>
    public partial class AppPanel : UserControl
    {

        public AppPanel()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            topPanel.Background = new SolidColorBrush(Color.FromRgb(122, 255, 133));
            Debug.WriteLine("green");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            topPanel.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Debug.WriteLine("white");
        }
    }
}
