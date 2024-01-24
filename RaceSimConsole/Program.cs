using Controller;
using Model;
using RaceSimRemastered;

Data.initialize();
Data.NextRace();
Visuals.Initialize(Data.CurrentRace);
while (true)
{
    Thread.Sleep(100);
}
