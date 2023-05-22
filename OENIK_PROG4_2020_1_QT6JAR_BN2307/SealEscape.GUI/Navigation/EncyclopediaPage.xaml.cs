// <copyright file="EncyclopediaPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using SealEscape.Model.OtherModels;

    /// <summary>
    /// Interaction logic for EncyclopediaPage.xaml.
    /// </summary>
    public partial class EncyclopediaPage : Page
    {
        private MenuControl control;
        private List<EncyclopediaEntryModel> encyclopediaentries;

        /// <summary>
        /// Initializes a new instance of the <see cref="EncyclopediaPage"/> class.
        /// </summary>
        public EncyclopediaPage()
        {
            this.InitializeComponent();
            this.control = new MenuControl();
            this.encyclopediaentries = this.control.GetEncyclopedia();

            this.loadencyclopedia.ItemsSource = this.encyclopediaentries;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
