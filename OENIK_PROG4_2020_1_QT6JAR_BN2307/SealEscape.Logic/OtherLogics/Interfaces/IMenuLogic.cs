// <copyright file="IMenuLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Describes methods which are used in the menu.
    /// </summary>
    public interface IMenuLogic
    {
        /// <summary>
        /// Gets or sets the model to manipulate.
        /// </summary>
        IGameModel GameModel { get; set; }

        /// <summary>
        /// Returns data from the repository representing the leaderboard.
        /// </summary>
        /// <returns>The list containing leaderboard entries.</returns>
        List<ILeaderboardEntryModel> DisplayLeaderboard();

        /// <summary>
        /// Returns data from the repository representing the encyclopedia.
        /// </summary>
        /// <returns>A list of encyclopedia items.</returns>
        List<EncyclopediaEntryModel> DisplayEncyclopedia();

        /// <summary>
        /// Sets player name in repository.
        /// </summary>
        /// <param name="playername">Player name.</param>
        void SetPlayerName(string playername);

        /// <summary>
        /// Gets player name in repository.
        /// </summary>
        /// <returns>Player name.</returns>
        string GetPlayerName();

        /// <summary>
        /// Returns a list of available power ups.
        /// </summary>
        /// <returns>A list of available power ups.</returns>
        ObservableCollection<IPowerupModel> ListPowerUps();

        /// <summary>
        /// Add an item from ShopRepository to PurchasesRepository.
        /// </summary>
        /// <param name="itemName">Define which item should be purchased.</param>
        void PurchaseShopItem(string itemName);

        /// <summary>
        /// Get how much fish do we have.
        /// </summary>
        /// <returns>The amount of fish.</returns>
        int GetCollectedFish();
    }
}
