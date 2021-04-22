using System;
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
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            RadioList.ItemsSource = StationsStorage.urlRadios;
            TextBlockPlaying.Opacity = 0;
            
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            DrawLines();
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
            TextBlockVolume.Opacity = 1;
            //TextBlockPlaying.Text = SliderVal.Value.ToString();
            int vol = Convert.ToInt32(SliderVal.Value * 10);
            TextBlockVolume.Text = vol.ToString();
            RadioPlayer.SetVolumeToStream(RadioPlayer.Stream, vol);
        }

        public void MediaPlayerOpen(object sender, RoutedEventArgs e)
        {
            MediaPlayer player = new MediaPlayer();
            player.Owner = this;
            this.Hide();
            player.Show();
        }

        public void GetInfoClick(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private int start = 50;
        public void DrawLines()
        {
            RadioPlayer.GetChannelInfo(RadioPlayer.Stream);
            
            for (int i = 0; i < 15; i++)
            {
                
                Line line = new Line();
                line.X1 = start;
                line.X2 = start;
                line.Y1 = 0;
                line.Y2 = RadioPlayer.fft[(i+1) * 2] * 1000;
                line.Stroke = Brushes.Red;
                LinesCanvas.Children.Add(line);
                this.AddChild(LinesCanvas);
                start += 20;
            }
            
            /*RedLine.X1 = 70;
            RedLine.X2 = 70;
            RedLine.Y1 = 0;
            RedLine.Y2 = RadioPlayer.fft[2] * 1000;
            
            RedLine2.X1 = 80;
            RedLine2.X2 = 80;
            RedLine2.Y1 = 0;
            RedLine2.Y2 = RadioPlayer.fft[4] * 1000;
            
            RedLine3.X1 = 90;
            RedLine3.X2 = 90;
            RedLine3.Y1 = 0;
            RedLine3.Y2 = RadioPlayer.fft[6] * 1000;
            
            RedLine4.X1 = 100;
            RedLine4.X2 = 100;
            RedLine4.Y1 = 0;
            RedLine4.Y2 = RadioPlayer.fft[8] * 1000;
            
            RedLine5.X1 = 110;
            RedLine5.X2 = 110;
            RedLine5.Y1 = 0;
            RedLine5.Y2 = RadioPlayer.fft[10] * 1000;
            
            RedLine6.X1 = 120;
            RedLine6.X2 = 120;
            RedLine6.Y1 = 0;
            RedLine6.Y2 = RadioPlayer.fft[12] * 1000;
            
            RedLine7.X1 = 130;
            RedLine7.X2 = 130;
            RedLine7.Y1 = 0;
            RedLine7.Y2 = RadioPlayer.fft[14] * 1000;
            
            RedLine8.X1 = 140;
            RedLine8.X2 = 140;
            RedLine8.Y1 = 0;
            RedLine8.Y2 = RadioPlayer.fft[16] * 1000;
            
            RedLine9.X1 = 150;
            RedLine9.X2 = 150;
            RedLine9.Y1 = 0;
            RedLine9.Y2 = RadioPlayer.fft[18] * 1000;
            
            RedLine10.X1 = 160;
            RedLine10.X2 = 160;
            RedLine10.Y1 = 0;
            RedLine10.Y2 = RadioPlayer.fft[20] * 1000;*/
        }
        
    }
}