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

namespace TakeOff.Views
{
    public partial class DownloadView : UserControl
    {
        public DownloadView()
        {
            InitializeComponent();
            
            // Wczytanie danych z pliku JSON
            string programsDataSerialized = File.ReadAllText(@"Assets/Programs.json");

            // Deserializacja danych do listy zawierającej programy
            var programs = JsonConvert.DeserializeObject<List<Program>>(programsDataSerialized);

            // Wczytanie programów do ItemControla (Binding)
            icProgramsList.ItemsSource = programs;

            // Utworzenie event'u przy zmianie wartości w search box'ie
            SearchBox.TextChanged += new TextChangedEventHandler( SearchBoxTextChanged );
        }

        // Obługa event'u przy zmianie wartości w search box'ie
        private void SearchBoxTextChanged(object Sender, TextChangedEventArgs e)
        {
            // Wczytanie wszystkich danych programów
            System.Diagnostics.Debug.WriteLine(SearchBox.Text.ToLowerInvariant());
            string programsDataSerialized = File.ReadAllText(@"Assets/Programs.json");
            var programs = JsonConvert.DeserializeObject<List<Program>>(programsDataSerialized);

            // Filtrowanie zapytania z search box'a
            // Jeśli puste to wyświetla wszystkie programy
            if(SearchBox.Text == "")
            {
                icProgramsList.ItemsSource = programs;
            } 
            else 
            {
                // Tworzenie listy programów opartej na zapytaniu 
                // Zapytanie szuka nazm programów, które mają w sobie treść z search box'a. Sprawdza oryginalne nazwy, warianty z dużymi i małymi literami
                IEnumerable<Program> programsQuery = programs.Where(Program => Program.Name.Contains(SearchBox.Text) 
                    || Program.Name.ToLowerInvariant().Contains(SearchBox.Text) 
                    || Program.Name.ToUpperInvariant().Contains(SearchBox.Text));

                // Wczytanie programów które pasują do zapytania do ItemControla 
                icProgramsList.ItemsSource = programsQuery;
            }
        }

        // Obsługa przycisku pobierania
        private void DwnldBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (Program program in icProgramsList.Items)
            {
                //Jeżeli isSelected = true, pobierz program za pomocą .Download()
                if(program.isSelected == true)
                {
                    program.Download();
                }
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
