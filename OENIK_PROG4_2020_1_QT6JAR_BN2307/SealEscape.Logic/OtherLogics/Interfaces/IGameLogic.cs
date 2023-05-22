// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model;

    /// <summary>
    /// Describes methods which control the game as a whole.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// This event is fired if player's lives are zero.
        /// </summary>
        event EventHandler GameOver;

        /// <summary>
        /// Gets or sets the model to manipulate.
        /// </summary>
        IGameModel GameModel { get; set; }

        /// <summary>
        /// Gets or sets a pair containing a Player and a Logic.
        /// </summary>
        KeyValuePair<IPlayerModel, IPlayerLogic> PlayerModelLogicPair { get; set; }

        /// <summary>
        /// Gets or sets pairs a dict containing pairs of Enemies and Logics.
        /// </summary>
        Dictionary<IEnemyModel, IEnemyLogic> EnemyModelLogicPairs { get; set; }

        /// <summary>
        /// Gets or sets pairs a dict containing pairs of Feed and Logics.
        /// </summary>
        Dictionary<IFoodModel, IFoodLogic> FoodModelLogicPairs { get; set; }

        /// <summary>
        /// Approaches with all enemies and food.
        /// </summary>
        void ApproachAll();

        /// <summary>
        /// Move the player upwards.
        /// </summary>
        void AscendPlayer();

        /// <summary>
        /// Move the player downwards.
        /// </summary>
        void DescendPlayer();

        /// <summary>
        /// Fill the next section ahead with random GameElements.
        /// </summary>
        void GenerateMap();

        /// <summary>
        /// Remove game elements which exited the game area.
        /// </summary>
        void Cleanup();

        /// <summary>
        /// Load the map from a save.
        /// </summary>
        /// <param name="savename">The name of the save.</param>
        void LoadMap(string savename);

        /// <summary>
        /// Store the current map in the repository.
        /// </summary>
        /// <param name="savename">Identifier of save.</param>
        void SaveMap(string savename);

        /// <summary>
        /// Update highscore stored in the model.
        /// </summary>
        /// <param name="highscore">Value to set highscore to.</param>
        void SetHighscore(int highscore);

        /// <summary>
        /// Load highscore from the repository.
        /// </summary>
        void LoadHighscore();

        /// <summary>
        /// Store current highscore in the repository.
        /// </summary>
        void SaveHighscore();

        /// <summary>
        /// Increase current score in model.
        /// </summary>
        /// <param name="diff">Delta to increase highscore with.</param>
        void IncreaseScore(int diff);

        /// <summary>
        /// Increase current food collected score in model.
        /// </summary>
        /// <param name="diff">Delta to increase food collected with.</param>
        void IncreaseFoodCollected(int diff);

        /// <summary>
        /// Store current game's collected fish in repository.
        /// </summary>
        void StoreFoodCollected();

        /// <summary>
        /// Get player name.
        /// </summary>
        /// <returns>The player name.</returns>
        string GetPlayerName();

        /// <summary>
        /// Sets player name.
        /// </summary>
        /// <param name="playername">The string to set player name to.</param>
        void SetPlayerName(string playername);

        /// <summary>
        /// Returns a list containing the names of available saves.
        /// </summary>
        /// <returns>A list of saved map names.</returns>
        List<string> ListSavedMaps();
    }
}
