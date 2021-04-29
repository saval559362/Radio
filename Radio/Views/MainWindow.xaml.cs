using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Radio.Models;
using Un4seen.Bass;

namespace Radio.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        ObservableCollection<Line> lines = new ObservableCollection<Line>();
        
        DispatcherTimer timer = new DispatcherTimer();

        public int needUrlIndex;
        public MainWindow()
        {
            InitializeComponent();
            /*RadioList.ItemsSource = null;
            RadioList.ItemsSource = StationsStorage.LoadStations();*/
            TextBlockPlaying.Opacity = 0;
            SliderVal.Maximum = 100;
            SliderVal.Value = 25;
            
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            
            CreateLines();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DrawLines();
        }

        /// <summary>
        /// Playing from ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*public void PlayFromContext(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            RadioPlayer.Play(StationsStorage.urlRadios[RadioList.SelectedIndex].url, 50);
            SetNameRadio(StationsStorage.urlRadios[RadioList.SelectedIndex].name);
            TextBlockPlaying.Opacity = 1;
            timer.Start();
        }*/

        public void PlayComm(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            RadioPlayer.Play(StationsStorage.urlRadios[needUrlIndex].url, 50);
            SetNameRadio(StationsStorage.urlRadios[needUrlIndex].name);
            TextBlockPlaying.Opacity = 1;
            timer.Start();
            SelectedName.Text = "";
            RadioPlayer.GetTagsFromCurrentURLStream(RadioPlayer.Stream);
            TextBlockTagTrack.Text = RadioPlayer.tag;
        }

        /// <summary>
        /// Deleting from ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteFromContext(object sender, RoutedEventArgs e)
        {
            StationsStorage.urlRadios.RemoveAt(RadioList.SelectedIndex);
        }

        /// <summary>
        /// Stopping stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void StopRadio(object sender, RoutedEventArgs e)
        {
            RadioPlayer.Stop();
            TextBlockPlaying.Opacity = 0;
        }

        /// <summary>
        /// Adding new radio url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayFromUrl(object sender, RoutedEventArgs e)
        {
            InputUrl inp = new InputUrl();
            inp.Show();
        }

        /// <summary>
        /// Showing playing radio name
        /// </summary>
        /// <param name="name"></param>
        public void SetNameRadio(string name)
        {
            TextBlockPlaying.Text = "Сейчас играет: " + name;
        }

        /// <summary>
        /// Change volume of stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBlockVolume.Opacity = 1;
            //TextBlockPlaying.Text = SliderVal.Value.ToString();
            int vol = Convert.ToInt32(SliderVal.Value);
            TextBlockVolume.Text = vol.ToString();
            RadioPlayer.SetVolumeToStream(RadioPlayer.Stream, vol);
        }

        /// <summary>
        /// Open media pleer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MediaPlayerOpen(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = new MediaPlayer();
            player.Owner = this;
            this.Hide();
            player.Show();
        }

        private double start = 0;

        /// <summary>
        /// Create lines and insert it in ObservableCollection
        /// </summary>
        public void CreateLines()
        {
            for (int i = 0; i < 150; i++)
            {
                Line line = new Line();
                line.X1 = start;
                line.X2 = start;
                line.Y1 = 200;
                line.Y2 = 200;
                line.MinHeight = 150;
                line.Stroke = Brushes.Coral;
                line.StrokeThickness = 5;
                line.VerticalAlignment = VerticalAlignment.Bottom;
                
                lines.Add(line);
                start += 5.5;
            }
            
            for (int i = 0; i < lines.Count; i++)
            {
                LinesCanvas.Children.Add(lines[i]);
            }
        }
        
        /// <summary>
        /// Draw lines in visualizator
        /// </summary>
        public void DrawLines()
        {
            RadioPlayer.GetChannelInfo(RadioPlayer.Stream);

            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].Y2 = 200 - (RadioPlayer.fft[i] * 300);
            }
            
        }

        public void FavouriteSelect_Click(object sender, RoutedEventArgs e)
        {
            FavouriteSelect fav = new FavouriteSelect();
            fav.Show();

        }
        
    }
}