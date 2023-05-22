// <copyright file="ShopRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model.OtherModels;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Repository to manage items which can be purchased at the shop.
    /// </summary>
    public static class ShopRepository
    {
        private static List<IShopItemModel> ShopItems
        {
            get
            {
                return new List<IShopItemModel>()
                {
                    new PowerupModel(1, 0)
                    {
                        Name = "Extra life 1",
                        Description = "Adds an extra life",
                        Price = 600,
                        ImagePath = "/Images/lifepowerup.png",
                    },
                    new PowerupModel(0, 2)
                    {
                        Name = "Extra fish 1",
                        Description = "Doubles collected fish",
                        Price = 1000,
                        ImagePath = "/Images/fishpowerup.png",
                    },
                    new PowerupModel(1, 0)
                    {
                        Name = "Extra life 2",
                        Description = "Adds an extra life",
                        Price = 1200,
                        ImagePath = "/Images/lifepowerup.png",
                    },
                    new PowerupModel(0, 2)
                    {
                        Name = "Extra fish 2",
                        Description = "Doubles collected fish",
                        Price = 2000,
                        ImagePath = "/Images/fishpowerup.png",
                    },
                };
            }
        }

        /// <summary>
        /// Returns a shop item based on a name.
        /// </summary>
        /// <param name="name">The identifier of the item to return.</param>
        /// <returns>The item.</returns>
        public static IShopItemModel Read(string name)
        {
            return ShopRepository.ShopItems.Find(x => x.Name == name);
        }

        /// <summary>
        /// Gets all elements that can be purchased.
        /// </summary>
        /// <returns>The list of elements that can be purchased.</returns>
        public static List<IShopItemModel> ReadAll()
        {
            return ShopRepository.ShopItems;
        }
    }
}
