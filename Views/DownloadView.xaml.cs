using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using Newtonsoft.Json;
using TakeOff.Resources;

namespace TakeOff.Views
{
    public partial class DownloadView : UserControl
    {
        public DownloadView()
        {
            InitializeComponent();


            string programsDataSerialized = File.ReadAllText(@"Assets/Programs.json");
            Programs[] programs = JsonConvert.DeserializeObject<Programs[]>(programsDataSerialized);

            program1_Image.Source    = new BitmapImage(new Uri(programs[0].ImagePath, UriKind.Relative));
            program1_Name.Content    = programs[0].Name;
            program1_Version.Content = programs[0].Version;

            program2_Image.Source    = new BitmapImage(new Uri(programs[1].ImagePath, UriKind.Relative));
            program2_Name.Content    = programs[1].Name;
            program2_Version.Content = programs[1].Version;

            program3_Image.Source    = new BitmapImage(new Uri(programs[2].ImagePath, UriKind.Relative));
            program3_Name.Content    = programs[2].Name;
            program3_Version.Content = programs[2].Version;

            program4_Image.Source    = new BitmapImage(new Uri(programs[3].ImagePath, UriKind.Relative));
            program4_Name.Content    = programs[3].Name;
            program4_Version.Content = programs[3].Version;

            program5_Image.Source    = new BitmapImage(new Uri(programs[4].ImagePath, UriKind.Relative));
            program5_Name.Content    = programs[4].Name;
            program5_Version.Content = programs[4].Version;

            program6_Image.Source    = new BitmapImage(new Uri(programs[5].ImagePath, UriKind.Relative));
            program6_Name.Content    = programs[5].Name;
            program6_Version.Content = programs[5].Version;
        }
    }
}
