using System.Windows;
using Radio.Models;

namespace Radio.Views
{
    public partial class InputUrl : Window
    {
        public InputUrl()
        {
            InitializeComponent();
        }

        public void AddFavourite(object sender, RoutedEventArgs e)
        {
            StationsStorage.urlRadios.Add(new Stations { name = "none", url = $"{RadioUrl.Text}" });
        }

        public void ClickOk(object sender, RoutedEventArgs e)
        {
            RadioPlayer.Play(RadioUrl.Text, 50);
            this.Close();
        }
    }
}