using Model;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;

namespace Controller
{
    public class DataContextStatistics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        private string _trackName => Data.CurrentRace.Track.Name;
        public string TrackName { get { return _trackName; } private set { } }

        private List<IParticipant> _drivers => Data.CurrentRace.Participants;
        public List<IParticipant> Drivers { get { return _drivers; } private set { } }


        public DataContextStatistics()
        {
            if (Data.CurrentRace != null)
            {
                Data.CurrentRace.DriversChanged += OnDriversChanged;
                Data.CurrentRace.RaceEnded += OnRaceEnded;
            }
        }

        public void OnRaceEnded(object sender, EventArgs e)
        {
            Data.CurrentRace.DriversChanged += OnDriversChanged;
            Data.CurrentRace.RaceEnded += OnRaceEnded;
        }



        public void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(""));
        }


    }
}
