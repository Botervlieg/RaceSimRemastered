using Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Controller
{
    public class DataContextStatistics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        public Track Track => Data.CurrentRace.Track;

        public BindingList<Track> Tracks => new(Data.Competition.Tracks.ToList());

        public BindingList<IParticipant> Drivers => new(Data.Competition.Participants.OrderByDescending(p => p.Points).ToList());

        public BindingList<Section> Sections => new(Data.CurrentRace.Track.Sections.ToList());


        public DataContextStatistics()
        {
            Data.CurrentRace.DriversChanged += OnDriversChanged;
            Data.CurrentRace.RaceEnded += OnRaceEnded;
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
