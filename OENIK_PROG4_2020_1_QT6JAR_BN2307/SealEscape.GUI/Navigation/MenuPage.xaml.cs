// <copyright file="MenuPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MenuPage.
    /// </summary>
    public partial class MenuPage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPage"/> class.
        /// </summary>
        public MenuPage()
        {
            this.InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PlayGamePage());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.Close();
            }
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ShopPage());
        }

        private void Encyclopedia_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EncyclopediaPage());
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StatisticsPage());
        }
    }
}
