// <copyright file="ShopItemModel.cs" company="PlaceholderCompany">
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
    /// Contains properties representing an item that can be purchased at the shop.
    /// </summary>
    public class ShopItemModel : IShopItemModel
    {
        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public int Price { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public string ImagePath { get; set; }
    }
}
