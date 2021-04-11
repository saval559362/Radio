using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Radio.Models;

namespace Radio.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            RadioList.ItemsSource = StationsStorage.urlRadios;
            TextBlockPlaying.Opacity = 0;
        }

        public void PlayComm(object sender, RoutedEventArgs e)
        {
            RadioPlayer.Play("http://87.252.227.241:8888/energyfm", 50);
        }
        public void PlayFromContext(object sender, RoutedEventArgs e)
        {
            RadioPlayer.Play(StationsStorage.urlRadios[RadioList.SelectedIndex].url, 50);
            SetNameRadio(StationsStorage.urlRadios[RadioList.SelectedIndex].name);
            TextBlockPlaying.Opacity = 1;
        }

        public void DeleteFromContext(object sender, RoutedEventArgs e)
        {
            StationsStorage.urlRadios.RemoveAt(RadioList.SelectedIndex);
        }

        public void StopRadio(object sender, RoutedEventArgs e)
        {
            RadioPlayer.Stop();
            TextBlockPlaying.Opacity = 0;
        }

        public void PlayFromUrl(object sender, RoutedEventArgs e)
        {
            InputUrl inp = new InputUrl();
            inp.Show();
        }

        public void SetNameRadio(string name)
        {
            TextBlockPlaying.Text = "Сейчас играет: " + name;
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlockPlaying.Opacity = 1;
            //TextBlockPlaying.Text = SliderVal.Value.ToString();
            int vol = Convert.ToInt32(SliderVal.Value * 10);
            TextBlockPlaying.Text = vol.ToString();
            RadioPlayer.SetVolumeToStream(RadioPlayer.Stream, vol);
        }

        public void MediaPlayerOpen(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = new MediaPlayer();
            player.Owner = this;
            this.Hide();
            player.Show();
        }
    }
}