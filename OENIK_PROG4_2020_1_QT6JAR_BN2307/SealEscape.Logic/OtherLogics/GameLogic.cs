// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic.OtherLogics
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using SealEscape.Logic.GameElementLogics;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;
    using SealEscape.Repository;

    /// <summary>
    /// Methods which control the game as a whole.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Just a random number generator.
        /// </summary>
        private readonly Random rng = new Random();

        private readonly MapRepository mapRepository;

        private readonly CollectedFishRepository fishRepository;

        private readonly PurchasesRepository purchasesRepository;
        private readonly LeaderboardRepository leaderboardRepository;

        private int scoreCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="gameModel">The model to manipulate.</param>
        public GameLogic(IGameModel gameModel)
        {
            this.GameModel = gameModel ?? throw new ArgumentNullException(nameof(gameModel));

            this.PlayerModelLogicPair = default;
            this.EnemyModelLogicPairs = new Dictionary<IEnemyModel, IEnemyLogic>();
            this.FoodModelLogicPairs = new Dictionary<IFoodModel, IFoodLogic>();

            this.mapRepository = new MapRepository();
            this.fishRepository = new CollectedFishRepository();
            this.purchasesRepository = new PurchasesRepository();
            this.leaderboardRepository = new LeaderboardRepository();

            this.LoadHighscore();

            // If it's not on the default value, we are loading an active save so no need to activate powerups.
            if (this.GameModel.Player.LivesTotal == 3 && this.GameModel.Player.LivesLeft == 3)
            {
                foreach (var item in this.purchasesRepository.ReadAll())
                {
                    if (ShopRepository.Read(item.Name) is IPowerupModel)
                    {
                        this.GameModel.ActivePowerUps.Add(ShopRepository.Read(item.Name) as IPowerupModel);
                    }
                }

                foreach (var item in this.GameModel.ActivePowerUps)
                {
                    this.GameModel.Player.LivesTotal += item.IncreasesLifeBy;
                    this.GameModel.Player.LivesLeft += item.IncreasesLifeBy;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="gameModel">The model.</param>
        /// <param name="purchasesRepository">The purchase repo.</param>
        /// <param name="mapRepository">The map repository.</param>
        /// <param name="leaderboardRepository">The leaderboard repo.</param>
        /// <param name="fishRepository">The fish repo.</param>
        public GameLogic(
            IGameModel gameModel,
            MapRepository mapRepository,
            PurchasesRepository purchasesRepository,
            LeaderboardRepository leaderboardRepository,
            CollectedFishRepository fishRepository)
        {
            this.GameModel = gameModel ?? throw new ArgumentNullException(nameof(gameModel));

            this.PlayerModelLogicPair = default;
            this.EnemyModelLogicPairs = new Dictionary<IEnemyModel, IEnemyLogic>();
            this.FoodModelLogicPairs = new Dictionary<IFoodModel, IFoodLogic>();

            this.mapRepository = mapRepository;
            this.fishRepository = fishRepository;
            this.purchasesRepository = purchasesRepository;
            this.leaderboardRepository = leaderboardRepository;
        }

        /// <inheritdoc/>
        public event EventHandler GameOver;

        /// <inheritdoc/>
        public IGameModel GameModel { get; set; }

        /// <inheritdoc/>
        public KeyValuePair<IPlayerModel, IPlayerLogic> PlayerModelLogicPair { get; set; }

        /// <inheritdoc/>
        public Dictionary<IEnemyModel, IEnemyLogic> EnemyModelLogicPairs { get; set; }

        /// <inheritdoc/>
        public Dictionary<IFoodModel, IFoodLogic> FoodModelLogicPairs { get; set; }

        /// <inheritdoc/>
        public void ApproachAll()
        {
            var toRemoveEnemies = new List<IEnemyModel>();
            var toRemoveFood = new List<IFoodModel>();

            // Move enemies
            foreach (var enemy in this.EnemyModelLogicPairs)
            {
                if (enemy.Key.HasAimBot)
                {
                    enemy.Value.AimBotApproach(this.PlayerModelLogicPair.Key.YPosition);
                }
                else
                {
                    enemy.Value.HorizontalApproach();
                }

                // Collision check with player
                if (this.PlayerModelLogicPair.Key.IsCollision(enemy.Key))
                {
                    this.PlayerModelLogicPair.Value.DecreaseLivesLeft(enemy.Key.Damage);
                    toRemoveEnemies.Add(enemy.Key);
                    if (this.PlayerModelLogicPair.Key.LivesLeft <= 0)
                    {
                        this.GameOver?.Invoke(this, EventArgs.Empty);
                    }
                }
            }

            // Move food
            foreach (var food in this.FoodModelLogicPairs)
            {
                if (food.Key.HasRandomApproach)
                {
                    food.Value.RandomApproach();
                }
                else
                {
                    food.Value.HorizontalApproach();
                }

                // Collision check with player
                if (this.PlayerModelLogicPair.Key.IsCollision(food.Key))
                {
                    int multiply = 0;
                    foreach (var item in this.GameModel.ActivePowerUps)
                    {
                        multiply += item.MultipliesCollectedFoodBy;
                    }

                    if (multiply == 0)
                    {
                        multiply = 1;
                    }

                    this.IncreaseFoodCollected(food.Key.Value * multiply);
                    toRemoveFood.Add(food.Key);
                }
            }

            // Run cleanup
            foreach (var item in toRemoveEnemies)
            {
                this.GameModel.EnemiesOnScreen.Remove(item);
                this.EnemyModelLogicPairs.Remove(item);
            }

            foreach (var item in toRemoveFood)
            {
                this.GameModel.FoodOnScreen.Remove(item);
                this.FoodModelLogicPairs.Remove(item);
            }

            // Add to score
            this.scoreCounter++;
            if (this.scoreCounter % 5 == 0)
            {
                this.GameModel.Score++;
            }

            // Check and set level
            if (this.GameModel.Score < 200)
            {
                this.GameModel.Level = 1;
            }
            else
            {
                this.GameModel.Level = 2;
            }
        }

        /// <inheritdoc/>
        public void AscendPlayer()
        {
            if (this.PlayerModelLogicPair.Key.RealArea.Bounds.Top >= 150)
            {
                this.PlayerModelLogicPair.Value.Ascend();
            }
        }

        /// <inheritdoc/>
        public void Cleanup()
        {
            for (int i = 0; i < this.EnemyModelLogicPairs.Count; i++)
            {
                var item = this.EnemyModelLogicPairs.ElementAt(i);
                if (item.Key.XPosition < 0 - (this.GameModel.GameWidth * 2))
                {
                    this.EnemyModelLogicPairs.Remove(item.Key);
                    this.GameModel.EnemiesOnScreen.Remove(item.Key);
                }
            }

            for (int i = 0; i < this.FoodModelLogicPairs.Count; i++)
            {
                var item = this.FoodModelLogicPairs.ElementAt(i);
                if (item.Key.XPosition < 0 - (this.GameModel.GameWidth * 2))
                {
                    this.FoodModelLogicPairs.Remove(item.Key);
                    this.GameModel.FoodOnScreen.Remove(item.Key);
                }
            }
        }

        /// <inheritdoc/>
        public void DescendPlayer()
        {
            if (this.PlayerModelLogicPair.Key.YPosition +
                this.PlayerModelLogicPair.Value.DescentSpeed >
                this.GameModel.GameHeight -
                this.GameModel.Player.RealArea.Bounds.Height)
            {
                this.PlayerModelLogicPair.Value.SetY(
                    this.GameModel.GameHeight -
                    this.GameModel.Player.RealArea.Bounds.Height);
            }

            if (this.PlayerModelLogicPair.Key.RealArea.Bounds.Bottom <
                this.GameModel.GameHeight)
            {
                this.PlayerModelLogicPair.Value.Descend();
            }
        }

        /// <inheritdoc/>
        public void GenerateMap()
        {
            // Enemies
            int enemiesToAddCount = 10 - this.GameModel.EnemiesOnScreen.Count;
            for (int i = 0; i < enemiesToAddCount; i++)
            {
                double xpos = (double)this.rng.Next(
                    (int)this.GameModel.GameWidth,
                    (int)this.GameModel.GameWidth * 2);
                double ypos = (double)this.rng.Next(150, (int)this.GameModel.GameHeight - 500);
                int dmg;
                bool aimbot;
                if (this.rng.Next(0, 10) < 8)
                {
                    dmg = 1;
                    aimbot = false;
                }
                else
                {
                    dmg = 3;
                    aimbot = true;
                }

                double speed = 10;
                EnemyModel enemyToAdd = new EnemyModel(xpos, ypos, dmg, aimbot, speed);
                bool addIsOk = true;
                foreach (var item in this.GameModel.EnemiesOnScreen)
                {
                    if (enemyToAdd.IsCollision(item) ||
                        (Math.Abs(enemyToAdd.YPosition - item.YPosition) < 100 &&
                        Math.Abs(enemyToAdd.XPosition - item.XPosition) < 200) ||
                        (item.Damage == 3 && enemyToAdd.Damage == 3))
                    {
                        addIsOk = false;
                    }
                }

                foreach (var item in this.GameModel.FoodOnScreen)
                {
                    if (enemyToAdd.IsCollision(item))
                    {
                        addIsOk = false;
                    }
                }

                if (addIsOk)
                {
                    this.GameModel.EnemiesOnScreen.Add(enemyToAdd);
                }
            }

            // Food
            int foodToAddCount = 30 - this.GameModel.FoodOnScreen.Count;
            for (int i = 0; i < foodToAddCount; i++)
            {
                double xpos = (double)this.rng.Next(
                    (int)this.GameModel.GameWidth,
                    (int)this.GameModel.GameWidth * 2);
                double ypos = (double)this.rng.Next(150, (int)this.GameModel.GameHeight - 500);
                int value;
                bool randomapproach;
                if (this.rng.Next(0, 10) < 8)
                {
                    value = 1;
                    randomapproach = false;
                }
                else
                {
                    value = 3;
                    randomapproach = true;
                }

                double speed = 10;
                FoodModel foodToAdd = new FoodModel(xpos, ypos, value, randomapproach, speed);
                bool addIsOk = true;
                foreach (var item in this.GameModel.EnemiesOnScreen)
                {
                    if (foodToAdd.IsCollision(item))
                    {
                        addIsOk = false;
                    }
                }

                foreach (var item in this.GameModel.FoodOnScreen)
                {
                    if (foodToAdd.IsCollision(item))
                    {
                        addIsOk = false;
                    }
                }

                if (addIsOk)
                {
                    this.GameModel.FoodOnScreen.Add(foodToAdd);
                }
            }

            this.FillModelLogicPairs();
        }

        /// <inheritdoc/>
        public void IncreaseFoodCollected(int diff)
        {
            this.GameModel.FishCollected += diff;
        }

        /// <inheritdoc/>
        public void StoreFoodCollected()
        {
            this.fishRepository.Add(this.GameModel.FishCollected);
        }

        /// <inheritdoc/>
        public void IncreaseScore(int diff)
        {
            this.GameModel.Score += diff;
        }

        /// <inheritdoc/>
        public List<string> ListSavedMaps()
        {
            return this.mapRepository.ListSaves();
        }

        /// <inheritdoc/>
        public void LoadHighscore()
        {
            this.GameModel.Highscore = this.leaderboardRepository.GetHighscore();
        }

        /// <inheritdoc/>
        public void LoadMap(string savename)
        {
            this.GameModel.EnemiesOnScreen = this.mapRepository.Read(savename).EnemiesOnScreen;
            this.GameModel.FoodOnScreen = this.mapRepository.Read(savename).FoodOnScreen;
            this.GameModel.FishCollected = this.mapRepository.Read(savename).FishCollected;
            this.GameModel.Player.LivesTotal = this.mapRepository.Read(savename).Player.LivesTotal;
            this.GameModel.Player.LivesLeft = this.mapRepository.Read(savename).Player.LivesLeft;
            this.GameModel.Score = this.mapRepository.Read(savename).Score;
            this.GameModel.Level = this.mapRepository.Read(savename).Level;
            this.LoadHighscore();
            this.FlushModelLogicPairs();
            this.FillModelLogicPairs();
        }

        /// <inheritdoc/>
        public void SaveHighscore()
        {
            this.leaderboardRepository.Create(new LeaderboardEntryModel()
            {
                PlayerName = this.GetPlayerName(),
                Score = this.GameModel.Score,
            });
        }

        /// <inheritdoc/>
        public void SaveMap(string savename)
        {
            this.mapRepository.Create(this.GameModel, savename);
        }

        /// <inheritdoc/>
        public void SetHighscore(int highscore)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public string GetPlayerName()
        {
            return PlayerModel.PlayerName;
        }

        /// <inheritdoc/>
        public void SetPlayerName(string playername)
        {
            PlayerModel.PlayerName = playername;
        }

        /// <summary>
        /// Resets all model logic pairs for a reload.
        /// </summary>
        private void FlushModelLogicPairs()
        {
            this.PlayerModelLogicPair = default;
            this.EnemyModelLogicPairs = new Dictionary<IEnemyModel, IEnemyLogic>();
            this.FoodModelLogicPairs = new Dictionary<IFoodModel, IFoodLogic>();
        }

        /// <summary>
        /// Create the necessary logics for all GameElements.
        /// </summary>
        private void FillModelLogicPairs()
        {
            if (this.PlayerModelLogicPair.Key == null)
            {
                this.PlayerModelLogicPair =
                    new KeyValuePair<IPlayerModel, IPlayerLogic>(
                        this.GameModel.Player,
                        new PlayerLogic(this.GameModel.Player));
            }
            else if (!this.PlayerModelLogicPair.Key.Equals(this.GameModel.Player))
            {
                this.PlayerModelLogicPair =
                    new KeyValuePair<IPlayerModel, IPlayerLogic>(
                        this.GameModel.Player,
                        new PlayerLogic(this.GameModel.Player));
            }

            foreach (var item in this.GameModel.EnemiesOnScreen)
            {
                if (!this.EnemyModelLogicPairs.ContainsKey(item))
                {
                    this.EnemyModelLogicPairs.Add(item, new EnemyLogic(item));
                }
            }

            foreach (var item in this.GameModel.FoodOnScreen)
            {
                if (!this.FoodModelLogicPairs.ContainsKey(item))
                {
                    this.FoodModelLogicPairs.Add(item, new FoodLogic(item));
                }
            }
        }
    }
}
