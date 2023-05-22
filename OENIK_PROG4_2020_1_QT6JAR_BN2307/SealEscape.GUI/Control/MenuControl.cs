// <copyright file="MenuControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation;
    using OENIK_PROG4_2020_1_QT6JAR_BN2307.Renderer;
    using SealEscape.Logic;
    using SealEscape.Logic.OtherLogics;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Controller class for menus.
    /// </summary>
    public class MenuControl
    {
        private IGameModel model;
        private IGameLogic gamelogic;
        private IMenuLogic menulogic;
        private GameRenderer gameRenderer;
        private DispatcherTimer timer;
        private DispatcherTimer maptimer;
        private bool isKeyDown = false;
        private bool isGameOver = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuControl"/> class.
        /// </summary>
        public MenuControl()
        {
            this.model = new GameModel(0, 0, 0 /*this.model.Highscore*/, 1); // ide pname, highcore, difficulty a menüből/repóból
            this.gamelogic = new GameLogic(this.model);
            this.menulogic = new MenuLogic(this.model);
            this.gameRenderer = new GameRenderer(this.model);
        }

        /// <summary>
        /// Returns saved maps.
        /// </summary>
        /// <param name="mapname">saved map name.</param>
        public void LoadGame(string mapname)
        {
            this.gamelogic.LoadMap(mapname);
        }

        /// <summary>
        /// Returns saved maps.
        /// </summary>
        /// <returns>List of maps.</returns>
        public List<string> LoadMaps()
        {
            return this.gamelogic.ListSavedMaps();
        }

        /// <summary>
        /// Returns shop elements.
        /// </summary>
        /// <returns>List of powerups.</returns>
        public ObservableCollection<IPowerupModel> LoadShop()
        {
            return this.menulogic.ListPowerUps();
        }

        /// <summary>
        /// Purchases an item from the shop.
        /// </summary>
        /// <param name="itemname">Name of purchased item.</param>
        public void PurchaseShopItem(string itemname)
        {
            this.menulogic.PurchaseShopItem(itemname);
        }

        /// <summary>
        /// Sets player name.
        /// </summary>
        /// <param name="playername">Name of player.</param>
        public void SetName(string playername)
        {
            this.menulogic.SetPlayerName(playername);
        }

        /// <summary>
        /// Gets current fish count.
        /// </summary>
        /// <returns>Number of collected fish.</returns>
        public int GetCollectedFish()
        {
           return this.menulogic.GetCollectedFish();
        }

        /// <summary>
        /// Gets all leaderboard entries.
        /// </summary>
        /// <returns>Leaderboards entries.</returns>
        public List<ILeaderboardEntryModel> GetLeaderboards()
        {
            return this.menulogic.DisplayLeaderboard();
        }

        /// <summary>
        /// Gets all leaderboard entries.
        /// </summary>
        /// <returns>Encyclopedia entries.</returns>
        public List<EncyclopediaEntryModel> GetEncyclopedia()
        {
            return this.menulogic.DisplayEncyclopedia();
        }
    }
}
