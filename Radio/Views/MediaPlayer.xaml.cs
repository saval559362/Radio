using System;
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
            m_Volume.Value = 5;
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
        }

        private void Suspend(object sender, RoutedEventArgs e)
        {
            RadioPlayer.SuspendChannel();
        }
    }
}