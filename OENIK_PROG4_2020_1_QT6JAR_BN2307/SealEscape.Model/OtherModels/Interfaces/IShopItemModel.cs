// <copyright file="IShopItemModel.cs" company="PlaceholderCompany">
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
    /// Describes properties representing an item that can be purchased at the shop.
    /// </summary>
    public interface IShopItemModel
    {
        /// <summary>
        /// Gets or sets the short name of the item.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount of fish it is worth.
        /// </summary>
        int Price { get; set; }

        /// <summary>
        /// Gets or sets the long description of the item.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets powerup image location.
        /// </summary>
        string ImagePath { get; set; }
    }
}
