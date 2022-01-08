using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Newtonsoft.Json;
using TakeOff.Resources;
using System.Windows;
using System.Collections.Generic;

namespace TakeOff.Views
{
    public partial class DownloadView : UserControl
    {
        public DownloadView()
        {
            InitializeComponent();

            string programsDataSerialized = File.ReadAllText(@"Assets/Programs.json");
            var programs = JsonConvert.DeserializeObject<List<Program>>(programsDataSerialized);
            icProgramsList.ItemsSource = programs;

        }
    }
}
