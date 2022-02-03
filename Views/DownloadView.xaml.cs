using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Newtonsoft.Json;
using TakeOff.Resources;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace TakeOff.Views
{
    public partial class DownloadView : UserControl
    {
        private readonly List<Program> _programs;

        public DownloadView()
        {
            InitializeComponent();
            
            // Wczytanie danych z pliku JSON
            string programsDataSerialized = File.ReadAllText(@"Assets/Programs.json");
            _programs = JsonConvert.DeserializeObject<List<Program>>(programsDataSerialized);
            icProgramsList.ItemsSource = _programs;

            // Utworzenie event'u przy zmianie wartości w search box'ie
            SearchBox.TextChanged += new TextChangedEventHandler( SearchBoxTextChanged );
        }

        // Obługa event'u przy zmianie wartości w search box'ie
        private void SearchBoxTextChanged(object Sender, TextChangedEventArgs e)
        {
            

            if (SearchBox.Text == "")
            {
                foreach (var program in _programs)
                {
                    program.Visibility = "visible";
                }
               // icProgramsList.ItemsSource = _programs;
            } 
            else 
            {
                // Tworzenie listy programów opartej na zapytaniu 
                var programsQuery = _programs.Where(Program => !Program.Name.ToLower().Contains(SearchBox.Text.ToLower()));
                //var programsQuery2 = _programs.Where(Program => Program.Name.ToLower().Contains(SearchBox.Text.ToLower()));


                foreach (var program in programsQuery)
                {
                    program.Visibility= "collapsed";
                }
                //icProgramsList.ItemsSource = programsQuery2;
            }
        }

        // Obsługa przycisku pobierania
        private void DwnldBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("hejka, co tam u ciebie? znowu pobierasz jakieś programy?", "Pobieranie", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                foreach (Program program in icProgramsList.Items)
                {
                    //Jeżeli isSelected = true, pobierz program za pomocą .Download()
                    if (program.IsSelected == true)
                    {
                        program.Download();
                    }
                }
            }
            else
            {
                Debug.WriteLine("Pobieranie anulowane przez użytkownika");
            }
            
        }

        // Zliczanie zaznaczonych paneli
        int checkedCount = 0;
 
        private void TglBtn_Checked(object sender, RoutedEventArgs e)
        {
            checkedCount += 1;
            Console.WriteLine(checkedCount);
            DwnldBtn.Visibility = Visibility.Visible;
            DwnldBtn.Content = $"Pobierz ({checkedCount})";
        }

        private void TglBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            checkedCount -= 1;
            Console.WriteLine(checkedCount);
            DwnldBtn.Content = $"Pobierz ({checkedCount})";

            if(checkedCount == 0)
            {
                DwnldBtn.Visibility = Visibility.Hidden;
            }
        }
    }
}
