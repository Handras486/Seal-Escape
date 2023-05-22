// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// General properties required for constructing and displaying the game.
    /// </summary>
    public class GameModel : IGameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        /// <param name="gameheight">GameModel height.</param>
        /// <param name="gamewidth">GameModel width.</param>
        /// <param name="hscore">Game highscore.</param>
        /// <param name="difficulty">Game difficulty.</param>
        public GameModel(double gameheight, double gamewidth, int hscore, int difficulty)
        {
            this.GameHeight = gameheight;
            this.GameWidth = gamewidth;
            this.Highscore = hscore;
            this.Difficulty = difficulty;
            this.Score = 0;
            this.FishCollected = 0;
            this.GameUpperBorder = 200;
            this.Level = 1;

            this.EnemiesOnScreen = new List<IEnemyModel>();
            this.FoodOnScreen = new List<IFoodModel>();
            this.ActivePowerUps = new List<IPowerupModel>();
            this.Player = new PlayerModel(15, 15, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        public GameModel()
        {
        }

        /// <inheritdoc/>
        public List<IPowerupModel> ActivePowerUps { get; set; }

        /// <inheritdoc/>
        public int Highscore { get; set; }

        /// <inheritdoc/>
        public int Score { get; set; }

        /// <inheritdoc/>
        public int FishCollected { get; set; }

        /// <inheritdoc/>
        public int Difficulty { get; set; }

        /// <inheritdoc/>
        public double GameWidth { get; private set; }

        /// <inheritdoc/>
        public double GameHeight { get; private set; }

        /// <inheritdoc/>
        public double GameUpperBorder { get; set; }

        /// <inheritdoc/>
        public IPlayerModel Player { get; set; }

        /// <inheritdoc/>
        public List<IEnemyModel> EnemiesOnScreen { get; set; }

        /// <inheritdoc/>
        public List<IFoodModel> FoodOnScreen { get; set; }

        /// <inheritdoc/>
        public int Level { get; set; }
    }
}
