// <copyright file="EscapePage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation
{
    /// <summary>
    /// Interaction logic for EscapePage.xaml.
    /// </summary>
    public partial class EscapePage : Page
    {
        private Control control;

        /// <summary>
        /// Initializes a new instance of the <see cref="EscapePage"/> class.
        /// </summary>
        /// <param name="control">control from GamePage.</param>
        public EscapePage(Control control)
        {
            this.InitializeComponent();
            this.control = control;
            this.loadlist.ItemsSource = control.LoadMaps();
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.NavigationService.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.control.SaveGame();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (this.loadlist.SelectedItem != null)
            {
                this.control.LoadGame(this.loadlist.SelectedItem.ToString());
                this.NavigationService.GoBack();
            }
        }
    }
}
