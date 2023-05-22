// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Navigation;
    using OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation;

    /// <summary>
    /// Interaction logic for App.
    /// </summary>
    public partial class App : Application
    {
        private NavigationWindow navigationWindow;

        /// <summary>
        /// Gets or sets current NavigationWindow.
        /// </summary>
        public NavigationWindow NavigationWindow
        {
            get { return this.navigationWindow; }
            set { this.navigationWindow = value; }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.navigationWindow = new NavigationWindow();
            this.navigationWindow.Width = 1920;
            this.navigationWindow.Height = 1080;
            this.navigationWindow.WindowState = WindowState.Maximized;
            this.navigationWindow.ResizeMode = ResizeMode.CanMinimize;
            this.navigationWindow.WindowStyle = WindowStyle.None;
            this.navigationWindow.ShowsNavigationUI = false;

            var page = new MenuPage();
            this.navigationWindow.Navigate(page);
            this.navigationWindow.Show();
        }
    }
}
