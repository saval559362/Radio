using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Radio.Models;
using Un4seen.Bass;

namespace Radio.Views
{
    public partial class MediaPlayer
    {
        private string _path;
        DispatcherTimer timer = new DispatcherTimer();
        public MediaPlayer()
        {
            InitializeComponent();
            m_Volume.Value = 0.5f;
            
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 1);
        }
        
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            PosOfMusic.Text = TimeSpan.FromSeconds(RadioPlayer.GetPosOfStream(RadioPlayer.Stream)).ToString();
            m_Slider.Value = RadioPlayer.GetPosOfStream(RadioPlayer.Stream);
            //RadioPlayer.SetPosOfScroll(RadioPlayer.Stream, Convert.ToInt32(m_Slider.Value));
        }

        public void SelectTrack(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();
            _path = openFileDlg.FileName;

        }

        private void M_Volume_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int vol = Convert.ToInt32(m_Volume.Value * 10);
            RadioPlayer.SetVolumeToStream(RadioPlayer.Stream, vol);
        }

        private void PlayerStop(object sender, RoutedEventArgs e)
        {
            RadioPlayer.Stop();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            RadioPlayer.PlayFile(_path, Convert.ToInt32(m_Volume.Value * 10));
            timer.Start();
            TimeOfMusic.Text = TimeSpan.FromSeconds(RadioPlayer.GetTimeOfStream(RadioPlayer.Stream)).ToString();
            m_Slider.Maximum = RadioPlayer.GetTimeOfStream(RadioPlayer.Stream);
            m_listBox.Items.Add(_path);
        }

        public void Window_Closing(object sender, CancelEventArgs e)
        {
            this.Owner.Show();
        }
    }
}