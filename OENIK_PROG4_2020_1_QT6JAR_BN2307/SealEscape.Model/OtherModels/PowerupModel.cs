// <copyright file="PowerupModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model.OtherModels
{
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Power ups that can be purchased at the shop.
    /// </summary>
    public class PowerupModel : ShopItemModel, IPowerupModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerupModel"/> class.
        /// </summary>
        /// <param name="increasesLifeBy">Sets how many lives do we get from this powerup.</param>
        /// <param name="multipliesCollectedFoodBy">Sets how much this powerup increases food collected.</param>
        public PowerupModel(int increasesLifeBy, int multipliesCollectedFoodBy)
        {
            this.IncreasesLifeBy = increasesLifeBy;
            this.MultipliesCollectedFoodBy = multipliesCollectedFoodBy;
        }

        /// <inheritdoc/>
        public int IncreasesLifeBy { get; }

        /// <inheritdoc/>
        public int MultipliesCollectedFoodBy { get; }
    }
}
