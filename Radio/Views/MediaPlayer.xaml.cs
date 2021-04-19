using System;
using System.Threading;
using System.Windows;
using Radio.Models;

namespace Radio.Views
{
    public partial class MediaPlayer
    {
        private string _path;
        public MediaPlayer()
        {
            InitializeComponent();
            m_Volume.Value = 0.5f;
            
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
            PosOfMusic.Text = TimeSpan.FromSeconds(RadioPlayer.GetPosOfStream(RadioPlayer.Stream)).ToString();
            TimeOfMusic.Text = TimeSpan.FromSeconds(RadioPlayer.GetTimeOfStream(RadioPlayer.Stream)).ToString();

            m_Slider.Maximum = RadioPlayer.GetTimeOfStream(RadioPlayer.Stream);
            m_Slider.Value = RadioPlayer.GetPosOfStream(RadioPlayer.Stream);

            m_listBox.Items.Add(_path);
        }

        private void Suspend(object sender, RoutedEventArgs e)
        {
            RadioPlayer.SuspendChannel();
        }
        
    }
}