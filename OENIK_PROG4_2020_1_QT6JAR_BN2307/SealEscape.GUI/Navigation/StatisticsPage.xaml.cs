// <copyright file="StatisticsPage.xaml.cs" company="PlaceholderCompany">
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
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Interaction logic for StatisticsPage.
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private MenuControl control;
        private List<ILeaderboardEntryModel> leaderboardentries;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsPage"/> class.
        /// </summary>
        public StatisticsPage()
        {
            this.InitializeComponent();
            this.control = new MenuControl();
            this.leaderboardentries = this.control.GetLeaderboards();

            this.leaderboards.ItemsSource = this.leaderboardentries;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
