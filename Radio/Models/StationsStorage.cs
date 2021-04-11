using System.Collections.ObjectModel;

namespace Radio.Models
{
    class StationsStorage
    {
        public static ObservableCollection<Stations> urlRadios = new ObservableCollection<Stations>
        {
            new Stations { name = "Energy", url = "http://87.252.227.241:8888/energyfm"},
            new Stations { name = "Legend FM", url = "http://live.legendy.by:8000/legendyfm"},
            new Stations { name = "Jazz FM", url = "http://jfm1.hostingradio.ru:14536/ijstream.mp3"}
        };

        public static ObservableCollection<Stations> GetStations()
        {
            return urlRadios;
        }
    }
}