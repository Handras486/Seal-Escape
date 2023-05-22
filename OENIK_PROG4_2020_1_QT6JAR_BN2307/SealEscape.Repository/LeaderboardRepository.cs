// <copyright file="LeaderboardRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Repository to store the leaderboard in.
    /// </summary>
    public class LeaderboardRepository : IRepoInterface<ILeaderboardEntryModel>
    {
        /// <summary>
        /// File containing leaderboard items.
        /// </summary>
        private readonly string leaderboardRepoPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + "\\SealEscape\\Leaderboard\\";

        /// <summary>
        /// Initializes a new instance of the <see cref="LeaderboardRepository"/> class.
        /// </summary>
        public LeaderboardRepository()
        {
            Directory.CreateDirectory(this.leaderboardRepoPath);
        }

        /// <inheritdoc/>
        public virtual void Create(ILeaderboardEntryModel data, [OptionalAttribute]string name)
        {
            if (!File.Exists(this.leaderboardRepoPath + "leaderboard.list"))
            {
                File.Create(this.leaderboardRepoPath + "leaderboard.list").Close();
            }

            if (!File.ReadAllLines(this.leaderboardRepoPath + "leaderboard.list").Contains(data.PlayerName + "," + data.Score))
            {
                StreamWriter sw = new StreamWriter(this.leaderboardRepoPath + "leaderboard.list", true);
                sw.WriteLine(data.PlayerName + "," + data.Score);
                sw.Close();
            }
        }

        /// <inheritdoc/>
        public void Delete(ILeaderboardEntryModel data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual ILeaderboardEntryModel Read(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads all leaderboard entries.
        /// </summary>
        /// <returns>A list of leaderboard entries.</returns>
        public virtual List<ILeaderboardEntryModel> ReadAll()
        {
            if (File.Exists(this.leaderboardRepoPath + "leaderboard.list"))
            {
                List<ILeaderboardEntryModel> leaderboardEntries = new List<ILeaderboardEntryModel>();
                StreamReader sr = new StreamReader(this.leaderboardRepoPath + "leaderboard.list");

                foreach (var item in sr.ReadToEnd().Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None))
                {
                    if (item != string.Empty)
                    {
                        string playerName = item.Split(',')[0];
                        int score = int.Parse(item.Split(',')[1]);
                        leaderboardEntries.Add(new LeaderboardEntryModel() { PlayerName = playerName, Score = score });
                    }
                }

                return leaderboardEntries;
            }
            else
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public void Update(ILeaderboardEntryModel existing, ILeaderboardEntryModel newdata)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get highest score.
        /// </summary>
        /// <returns>Highscore.</returns>
        public int GetHighscore()
        {
            if (this.ReadAll() == null)
            {
                return 0;
            }
            else
            {
                var entries = this.ReadAll();
                int highscore = 0;
                foreach (var item in entries)
                {
                    if (item.Score > highscore)
                    {
                        highscore = item.Score;
                    }
                }

                return highscore;
            }
        }
    }
}
