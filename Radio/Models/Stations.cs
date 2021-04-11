namespace Radio.Models
{
    public class Stations
    {
        public string url { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return this.name + " (" + this.url + ")";       //Перегрузка, которая позволяет ObservableCollection правильно выводит строку в ListBox
        }
    }
}