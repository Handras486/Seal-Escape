// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System.Collections.Generic;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Describes properties representing the game as a whole.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        IPlayerModel Player { get; set; }

        /// <summary>
        /// Gets or sets a list of all enemies on screen.
        /// </summary>
        List<IEnemyModel> EnemiesOnScreen { get; set; }

        /// <summary>
        /// Gets or sets a list of all feed on screen.
        /// </summary>
        List<IFoodModel> FoodOnScreen { get; set; }

        /// <summary>
        /// Gets or sets a list of all currently active powerups.
        /// </summary>
        List<IPowerupModel> ActivePowerUps { get; set; }

        /// <summary>
        /// Gets or sets a value storing the highscore.
        /// </summary>
        int Highscore { get; set; }

        /// <summary>
        /// Gets or sets a value storing the current score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets a value storing the current fish score.
        /// </summary>
        int FishCollected { get; set; }

        /// <summary>
        /// Gets or sets a value storing how fast the game is.
        /// </summary>
        int Difficulty { get; set; }

        /// <summary>
        /// Gets value of MainWindow Width.
        /// </summary>
        double GameWidth { get; }

        /// <summary>
        /// Gets value of MainWindow Height.
        /// </summary>
        double GameHeight { get; }

        /// <summary>
        /// Gets or sets the upper border of the traversable map.
        /// </summary>
        double GameUpperBorder { get; set; }

        /// <summary>
        /// Gets or sets ingame level.
        /// </summary>
        int Level { get; set; }
    }
}
