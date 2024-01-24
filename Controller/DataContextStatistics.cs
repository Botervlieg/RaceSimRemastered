using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class DataContextStatistics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _trackName => Data.CurrentRace.Track.Name;
        public string TrackName {  get { return _trackName; } private set { } }

        public DataContextStatistics()
        {
            if(Data.CurrentRace != null)
            {
                Data.CurrentRace.DriversChanged += OnDriversChanged;
            }
        }


        public void OnDriversChanged(object sender, EventArgs e) { 
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(""));
        }


    }
}
