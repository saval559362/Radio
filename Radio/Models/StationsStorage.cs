using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Radio.Models
{
    class StationsStorage
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//Stations.xml";
        public static ObservableCollection<Stations> urlRadios = new ObservableCollection<Stations>();
        
        /*public static ObservableCollection<Stations> urlRadios = new ObservableCollection<Stations>
        {
            new Stations { name = "Energy", url = "http://87.252.227.241:8888/energyfm"},
            new Stations { name = "Legend FM", url = "http://live.legendy.by:8000/legendyfm"},
            new Stations { name = "Jazz FM", url = "http://jfm1.hostingradio.ru:14536/ijstream.mp3"}
        };*/

        public static ObservableCollection<Stations> LoadStations()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            foreach (XmlElement item in doc.DocumentElement)
            {
                string nameStation = Convert.ToString(item["name"].InnerText);
                string urlStation = Convert.ToString(item["url"].InnerText);
                urlRadios.Add(new Stations(){ name = nameStation, url = urlStation});
            }

            return urlRadios;
        }

        public static void WriteStation(string name, string url)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement stationElem = xDoc.CreateElement("Station");
            XmlElement nameElem = xDoc.CreateElement("name");
            XmlElement urlElem = xDoc.CreateElement("url");
            XmlText nameText = xDoc.CreateTextNode(name);
            XmlText urlText = xDoc.CreateTextNode(url);
            
            nameElem.AppendChild(nameText);
            urlElem.AppendChild(urlText);
            stationElem.AppendChild(nameElem);
            stationElem.AppendChild(urlElem);
            xRoot.AppendChild(stationElem);
            xDoc.Save(path);
        }
    }
}