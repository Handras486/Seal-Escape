// <copyright file="MenuLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic.OtherLogics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO.Packaging;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;
    using SealEscape.Repository;

    /// <summary>
    /// Methods which are used in the menu.
    /// </summary>
    public class MenuLogic : IMenuLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuLogic"/> class.
        /// </summary>
        /// <param name="gameModel">The model to manipulate.</param>
        public MenuLogic(IGameModel gameModel)
        {
            this.GameModel = gameModel ?? throw new ArgumentNullException(nameof(gameModel));
            this.PurchasesRepository = new PurchasesRepository();
            this.LeaderboardRepository = new LeaderboardRepository();
            this.FishRepository = new CollectedFishRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuLogic"/> class.
        /// </summary>
        /// <param name="gameModel">The model.</param>
        /// <param name="purchasesRepository">The purchase repo.</param>
        /// <param name="leaderboardRepository">The leaderboard repo.</param>
        /// <param name="fishRepository">The fish repo.</param>
        public MenuLogic(
            IGameModel gameModel,
            PurchasesRepository purchasesRepository,
            LeaderboardRepository leaderboardRepository,
            CollectedFishRepository fishRepository)
        {
            this.GameModel = gameModel ?? throw new ArgumentNullException(nameof(gameModel));
            this.PurchasesRepository = purchasesRepository;
            this.LeaderboardRepository = leaderboardRepository;
            this.FishRepository = fishRepository;
        }

        /// <inheritdoc/>
        public IGameModel GameModel { get; set; }

        private PurchasesRepository PurchasesRepository { get; }

        private LeaderboardRepository LeaderboardRepository { get; }

        private CollectedFishRepository FishRepository { get; }

        /// <inheritdoc/>
        public List<EncyclopediaEntryModel> DisplayEncyclopedia()
        {
            var list = new List<EncyclopediaEntryModel>();
            list.AddRange(EncyclopediaRepository.Enemies);
            list.AddRange(EncyclopediaRepository.Food);
            list.AddRange(EncyclopediaRepository.Levels);

            return list;
        }

        /// <inheritdoc/>
        public List<ILeaderboardEntryModel> DisplayLeaderboard()
        {
            return this.LeaderboardRepository.ReadAll().OrderByDescending(x => x.Score).ToList();
        }

        /// <inheritdoc/>
        public int GetCollectedFish()
        {
            return this.FishRepository.Read();
        }

        /// <inheritdoc/>
        public string GetPlayerName()
        {
            return PlayerModel.PlayerName;
        }

        /// <inheritdoc/>
        public ObservableCollection<IPowerupModel> ListPowerUps()
        {
            ObservableCollection<IPowerupModel> powerups = new ObservableCollection<IPowerupModel>();

            foreach (var powerup in ShopRepository.ReadAll())
            {
                if (powerup is IPowerupModel && !this.PurchasesRepository.Contains(powerup.Name))
                {
                    powerups.Add(powerup as IPowerupModel);
                }
            }

            return powerups;
        }

        /// <inheritdoc/>
        public void PurchaseShopItem(string itemName)
        {
            if (this.FishRepository.Read() < ShopRepository.Read(itemName).Price)
            {
                throw new InvalidOperationException("Not enough money!");
            }
            else
            {
                IShopItemModel item = ShopRepository.Read(itemName);
                this.FishRepository.Remove(item.Price);
                this.PurchasesRepository.Create(item, itemName);
            }
        }

        /// <inheritdoc/>
        public void SetPlayerName(string playername)
        {
            PlayerModel.PlayerName = playername;
        }
    }
}
