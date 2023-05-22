// <copyright file="ILeaderboardEntryModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model.OtherModels.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes properties representing a leaderboard entry.
    /// </summary>
    public interface ILeaderboardEntryModel
    {
        /// <summary>
        /// Gets or sets the name of our player.
        /// </summary>
        string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets how much did they score.
        /// </summary>
        int Score { get; set; }
    }
}
