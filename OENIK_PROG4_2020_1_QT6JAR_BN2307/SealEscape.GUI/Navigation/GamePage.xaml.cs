// <copyright file="GamePage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Windows.Controls;

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation
{
    /// <summary>
    /// Interaction logic for GamePage.xaml.
    /// </summary>
    public partial class GamePage : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GamePage"/> class.
        /// </summary>
        public GamePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePage"/> class.
        /// </summary>
        /// <param name="loadgame">savefile name.</param>
        public GamePage(string loadgame)
        {
            Control.GameSave = loadgame;
            this.InitializeComponent();
        }
    }
}
