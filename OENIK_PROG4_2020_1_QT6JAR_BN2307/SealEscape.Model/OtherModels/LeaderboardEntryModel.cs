// <copyright file="LeaderboardEntryModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model.OtherModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Properties representing a leaderboard entry.
    /// </summary>
    public class LeaderboardEntryModel : ILeaderboardEntryModel
    {
        /// <inheritdoc/>
        public string PlayerName { get; set; }

        /// <inheritdoc/>
        public int Score { get; set; }
    }
}
