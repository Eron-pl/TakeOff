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
using TakeOff.ViewModels;

namespace TakeOff
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        //Przyciski do zmiany okien
        private void DownloadView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new DownloadViewModel();
        }

        private void ConfigurationView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ConfigurationViewModel();
        }

        private void PackView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new PackViewModel();
        }

        private void HelpView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HelpViewModel();
        }

        //Poruszanie programem na left-click 
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        //Wychodzenie z programu po kliknięciu 'X'
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        //Minimalizacja programu po kliknięciu '_'
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)

        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
