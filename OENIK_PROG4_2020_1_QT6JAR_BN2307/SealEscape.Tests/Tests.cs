// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using SealEscape.Logic.OtherLogics;
    using SealEscape.Model;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;
    using SealEscape.Repository;

    /// <summary>
    /// Unit tests.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Tests that SetPlayerName() really sets the correct player name.
        /// </summary>
        [Test]
        public void SetPlayerNameWorksCorrectly()
        {
            GameLogic gl = new GameLogic(new GameModel(1, 1, 1, 1));
            gl.SetPlayerName("dummy");
            Assert.That(PlayerModel.PlayerName == "dummy");
        }

        /// <summary>
        /// Tests that GetPlayerName() really reads the correct player name.
        /// </summary>
        [Test]
        public void GetPlayerNameWorksCorrectly()
        {
            GameLogic gl = new GameLogic(new GameModel(1, 1, 1, 1));
            PlayerModel.PlayerName = "dummy2";
            Assert.That(gl.GetPlayerName() == "dummy2");
        }

        /// <summary>
        /// Tests that MenuLogic's SaveHighscore() calls repo's create method exactly once.
        /// </summary>
        [Test]
        public void SaveHighscoreCreatesOnce()
        {
            Mock<LeaderboardRepository> mockedLeaderboardRepository = new Mock<LeaderboardRepository>();
            mockedLeaderboardRepository.Setup(m => m.Create(null, null));
            GameLogic gl = new GameLogic(new GameModel(1, 1, 1, 1), null, null, mockedLeaderboardRepository.Object, null);
            PlayerModel.PlayerName = "dummy";
            gl.GameModel.Score = 100;
            gl.SaveHighscore();

            mockedLeaderboardRepository.Verify(
                m => m.Create(It.IsAny<LeaderboardEntryModel>(), null),
                Times.Once);
        }

        /// <summary>
        /// Tests that MenuLogic's LoadHighscore() calls repo's ReadAll() method exactly once.
        /// </summary>
        [Test]
        public void LoadHighscoreReadsOnce()
        {
            Mock<LeaderboardRepository> mockedLeaderboardRepository = new Mock<LeaderboardRepository>();
            mockedLeaderboardRepository.Setup(m => m.ReadAll());
            GameLogic gl = new GameLogic(new GameModel(1, 1, 1, 1), null, null, mockedLeaderboardRepository.Object, null);
            gl.LoadHighscore();

            mockedLeaderboardRepository.Verify(m => m.ReadAll(), Times.Once);
        }

        /// <summary>
        /// Check if buying is not allowed if we do not have enough money.
        /// </summary>
        [Test]
        public void PurchaseShopItemBlocksPurchase()
        {
            Mock<PurchasesRepository> mockedPurcasesRepository = new Mock<PurchasesRepository>();
            Mock<CollectedFishRepository> mockedFishRepository = new Mock<CollectedFishRepository>();
            mockedPurcasesRepository.Setup(m => m.Create(null, null));
            mockedFishRepository.Setup(m => m.Read()).Returns(100);
            MenuLogic ml = new MenuLogic(
                new GameModel(1, 1, 1, 1),
                mockedPurcasesRepository.Object,
                null,
                mockedFishRepository.Object);

            Assert.Throws<InvalidOperationException>(() => ml.PurchaseShopItem("Extra life 1"));
        }

        /// <summary>
        /// Check if buying is allowed if we have enough money.
        /// </summary>
        [Test]
        public void PurchaseShopItemAllowsPurchase()
        {
            Mock<PurchasesRepository> mockedPurcasesRepository = new Mock<PurchasesRepository>();
            Mock<CollectedFishRepository> mockedFishRepository = new Mock<CollectedFishRepository>();
            mockedPurcasesRepository.Setup(m => m.Create(null, null));
            mockedFishRepository.Setup(m => m.Read()).Returns(1000);
            MenuLogic ml = new MenuLogic(
                new GameModel(1, 1, 1, 1),
                mockedPurcasesRepository.Object,
                null,
                mockedFishRepository.Object);

            Assert.DoesNotThrow(() => ml.PurchaseShopItem("Extra life 1"));
        }

        /// <summary>
        /// Check if GetCollectedFish() reads the repo exactly once.
        /// </summary>
        [Test]
        public void GetCollectedFishReadsOnce()
        {
            Mock<CollectedFishRepository> mockedFishRepository = new Mock<CollectedFishRepository>();
            mockedFishRepository.Setup(m => m.Read());
            MenuLogic ml = new MenuLogic(
               new GameModel(1, 1, 1, 1),
               null,
               null,
               mockedFishRepository.Object);

            ml.GetCollectedFish();

            mockedFishRepository.Verify(m => m.Read(), Times.Once);
        }

        /// <summary>
        /// Check if GetCollectedFish() reads the correct value.
        /// </summary>
        [Test]
        public void GetCollectedFishReturnsCorrect()
        {
            Mock<CollectedFishRepository> mockedFishRepository = new Mock<CollectedFishRepository>();
            mockedFishRepository.Setup(m => m.Read()).Returns(15000);
            MenuLogic ml = new MenuLogic(
               new GameModel(1, 1, 1, 1),
               null,
               null,
               mockedFishRepository.Object);

            Assert.That(ml.GetCollectedFish() == 15000);
        }

        /// <summary>
        /// Check that StoreFoodCollected() method writes exactly once.
        /// </summary>
        [Test]
        public void StoreFoodCollectedCreatesOnce()
        {
            Mock<CollectedFishRepository> mockedFishRepository = new Mock<CollectedFishRepository>();
            mockedFishRepository.Setup(m => m.Add(0));
            GameLogic gl = new GameLogic(new GameModel(1, 1, 1, 1), null, null, null, mockedFishRepository.Object);
            gl.StoreFoodCollected();

            mockedFishRepository.Verify(m => m.Add(0), Times.Once);
        }

        /// <summary>
        /// Test if IncreaseScore() works correctly.
        /// </summary>
        [Test]
        public void IncreaseScoreWorksCorrectly()
        {
            GameLogic gl = new GameLogic(new GameModel(1, 1, 1, 1), null, null, null, null);
            gl.IncreaseScore(10);

            Assert.That(gl.GameModel.Score == 10);
        }
    }
}
