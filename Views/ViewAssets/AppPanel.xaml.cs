using System;
using System.Collections.Generic;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (Convert.ToString(isChecked.Content) == "1")
            {
                xdxd.Content = "biale";
                topPanel.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                isChecked.Content = "0";
            }

            xdxd.Content = "zielone";
            topPanel.Background = new SolidColorBrush(Color.FromRgb(122, 255, 131));
            isChecked.Content = "1";
        }
    }
}
