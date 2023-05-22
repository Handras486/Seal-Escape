// <copyright file="MapRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using Newtonsoft.Json.Linq;
    using SealEscape.Model;

    /// <summary>
    /// Repository to manage saved maps.
    /// </summary>
    public class MapRepository : IRepoInterface<IGameModel>
    {
        /// <summary>
        /// Files containing saved maps.
        /// </summary>
        private readonly string mapRepoPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + "\\SealEscape\\Maps\\";

        /// <summary>
        /// Initializes a new instance of the <see cref="MapRepository"/> class.
        /// </summary>
        public MapRepository()
        {
            Directory.CreateDirectory(this.mapRepoPath);
        }

        /// <summary>
        /// Gets the path of the repo directory.
        /// </summary>
        public string MapRepoPath => this.mapRepoPath;

        /// <inheritdoc/>
        public void Create(IGameModel data, string savename)
        {
            StreamWriter sw = new StreamWriter(this.MapRepoPath + savename + ".json");
            List<object> enemiesOnScreen = new List<object>();
            List<object> foodOnScreen = new List<object>();
            foreach (var item in data.EnemiesOnScreen)
            {
                enemiesOnScreen.Add(
                    new
                    {
                        item.XPosition,
                        item.YPosition,
                        item.Damage,
                        item.HasAimBot,
                        item.Speed,
                    });
            }

            foreach (var item in data.FoodOnScreen)
            {
                foodOnScreen.Add(
                    new
                    {
                        item.XPosition,
                        item.YPosition,
                        item.Value,
                        item.HasRandomApproach,
                        item.Speed,
                    });
            }

            var save = new
            {
                Player = new
                {
                    data.Player.XPosition,
                    data.Player.YPosition,
                    data.Player.LivesLeft,
                    data.Player.LivesTotal,
                },
                EnemiesOnScreen = enemiesOnScreen,
                FoodOnScreen = foodOnScreen,
                data.GameHeight,
                data.GameWidth,
                PlayerModel.PlayerName,
                data.Highscore,
                data.Score,
                data.Difficulty,
                data.FishCollected,
                data.Level,
            };

            sw.WriteLine(new JavaScriptSerializer().Serialize(save));

            sw.Close();
        }

        /// <inheritdoc/>
        public void Delete(IGameModel data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IGameModel Read(string savename)
        {
            StreamReader sw = new StreamReader(this.MapRepoPath + savename + ".json");
            JObject save = JObject.Parse(sw.ReadToEnd());

            // Get player
            JToken playerToken = save["Player"];

            // Get enemies
            IList<JToken> enemyTokens = save["EnemiesOnScreen"].Children().ToList();
            List<IEnemyModel> enemies = new List<IEnemyModel>();
            foreach (var item in enemyTokens)
            {
                enemies.Add(item.ToObject<EnemyModel>());
            }

            // Get food
            IList<JToken> foodTokens = save["FoodOnScreen"].Children().ToList();
            List<IFoodModel> food = new List<IFoodModel>();
            foreach (var item in foodTokens)
            {
                food.Add(item.ToObject<FoodModel>());
            }

            sw.Close();

            return new GameModel(
                double.Parse(save["GameHeight"].Value<string>()),
                double.Parse(save["GameWidth"].Value<string>()),
                int.Parse(save["Highscore"].Value<string>()),
                int.Parse(save["Difficulty"].Value<string>()))
            {
                EnemiesOnScreen = enemies,
                FoodOnScreen = food,
                FishCollected = int.Parse(save["FishCollected"].Value<string>()),
                Level = int.Parse(save["Level"].Value<string>()),
                Player = playerToken.ToObject<PlayerModel>(),
                Score = int.Parse(save["Score"].Value<string>()),
            };
        }

        /// <inheritdoc/>
        public void Update(IGameModel existing, IGameModel newdata)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get names of all saved maps.
        /// </summary>
        /// <returns>A list containing all saved maps.</returns>
        public List<string> ListSaves()
        {
            return Directory.GetFiles(this.MapRepoPath, "*.json")
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }
    }
}
