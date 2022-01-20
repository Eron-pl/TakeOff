using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeOff.Resources
{
    public class Program: INotifyPropertyChanged // ViewModel
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string DownloadLink { get; set; }
        public string ImagePath { get; set; }

        private bool _isSelected;
        public bool IsSelected 
        { 
            get => _isSelected;
            set => SetValue(ref _isSelected, value, nameof(IsSelected)); 
        }

        private string _visibility;
        public string Visibility
        {
             get => _visibility;
             set => SetValue(ref _visibility, value, nameof(Visibility));
        }

        public void Download ()
        {
            Downloader.Download(DownloadLink);
        }

        public void DownloadTo(string path)
        {
            Downloader.Download(DownloadLink, path);
        }

        private void SetValue(ref string value, string newValue, string propertyName)
        {
            if (value == newValue)
                return;
            value = newValue;
            if (PropertyChanged is not null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetValue(ref bool value, bool newValue, string propertyName)
        {
            if (value == newValue)
                return;
            value = newValue;
            if (PropertyChanged is not null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
