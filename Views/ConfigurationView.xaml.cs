using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using TakeOff.Resources;

namespace TakeOff.Views
{
    public partial class ConfigurationView : UserControl
    {
        private UserConfig _userConfig;
        public ConfigurationView()
        {
            InitializeComponent();

            string userConfigData = File.ReadAllText(@"Assets/UserConfig.json");
            _userConfig = JsonConvert.DeserializeObject<UserConfig>(userConfigData);
            ChoosenPathTextBlock.Text = _userConfig.ProgramsInstalationPath;
            ApplyChangesBtn.Visibility = Visibility.Hidden;
        }

        private void PathChooseBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                ChoosenPathTextBlock.Text = openFileDlg.SelectedPath;
                _userConfig.ProgramsInstalationPath = ChoosenPathTextBlock.Text;
                ApplyChangesBtn.Visibility = Visibility.Visible;
            }
        }

        private void ApplyChangesBtn_Click(object sender, RoutedEventArgs e)
        {
            string userConfigSerializedData = JsonConvert.SerializeObject(_userConfig);

            StreamWriter myStream = new StreamWriter(@"Assets/UserConfig.json", append: true);
            myStream.WriteLine(userConfigSerializedData);
            myStream.Close();

            //File.WriteAllText("Assets/UserConfig.json", userConfigNewData);
        }
    }
}
