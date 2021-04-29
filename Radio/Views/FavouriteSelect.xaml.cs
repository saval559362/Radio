using System;
using System.Windows;
using Radio.Models;

namespace Radio.Views
{
    public partial class FavouriteSelect : Window
    {
        public FavouriteSelect()
        {
            StationsStorage.urlRadios.Clear();
            InitializeComponent();
            UrlList.ItemsSource = StationsStorage.LoadStations();
        }
        
        /// <summary>
        /// Playing from ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayFromContext(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Deleting from ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteFromContext(object sender, RoutedEventArgs e)
        {
            StationsStorage.urlRadios.RemoveAt(UrlList.SelectedIndex);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow log = Application.Current.Windows[0] as MainWindow; // форма в которую нужно передать значения
                log.SelectedName.Text = "Выбрано " + StationsStorage.urlRadios[UrlList.SelectedIndex].name;
                log.needUrlIndex = UrlList.SelectedIndex;
                this.Close();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Вы не выбрали станцию!","Ошибка", MessageBoxButton.OK);
            }
            
        }
    }
}