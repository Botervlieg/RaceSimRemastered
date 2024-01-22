using Controller;
using Model;
using RaceSimRemastered;

Data.initialize(new Competition());
Data.NextRace();
Visuals.Initialize(Data.CurrentRace);
Visuals.DrawTrack();
//Data.CurrentRace.Debug();
while (true)
{
    Thread.Sleep(100);
}
