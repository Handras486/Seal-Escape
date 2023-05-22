// <copyright file="IPowerupModel.cs" company="PlaceholderCompany">
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
    /// Describes properties representing power ups that can be purchased at the shop.
    /// </summary>
    public interface IPowerupModel : IShopItemModel
    {
        /// <summary>
        /// Gets how many lives do we get from this powerup.
        /// </summary>
        int IncreasesLifeBy { get; }

        /// <summary>
        /// Gets how much this powerup increases food collected.
        /// </summary>
        int MultipliesCollectedFoodBy { get; }
    }
}
