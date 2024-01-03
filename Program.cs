using Controller;
using Model;

Data.initialize(new Competition());
Data.NextRace();
Data.NextRace();
Console.WriteLine(Data.CurrentRace.Track.Name);

while (true)
{
    Thread.Sleep(100);
}