// <copyright file="PlayGamePage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Windows;
using System.Windows.Controls;

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation
{
    /// <summary>
    /// Interaction logic for PlayGamePage.
    /// </summary>
    public partial class PlayGamePage : Page
    {
        private MenuControl control;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayGamePage"/> class.
        /// </summary>
        public PlayGamePage()
        {
            this.InitializeComponent();
            this.control = new MenuControl();
            this.loadlist.ItemsSource = this.control.LoadMaps();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GamePage());
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (this.loadlist.SelectedItem != null)
            {
                this.NavigationService.Navigate(new GamePage(this.loadlist.SelectedItem.ToString()));
            }
        }

        private void SetName_Click(object sender, RoutedEventArgs e)
        {
            this.control.SetName(this.textbox.Text);
        }
    }
}
