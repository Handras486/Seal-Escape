// <copyright file="IEnemyModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes properties applicable to Enemy elements.
    /// </summary>
    public interface IEnemyModel : IApproachingElementModel
    {
        /// <summary>
        /// Gets or sets the damage caused by this enemy.
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this enemy has aimbot.
        /// </summary>
        bool HasAimBot { get; set; }
    }
}
