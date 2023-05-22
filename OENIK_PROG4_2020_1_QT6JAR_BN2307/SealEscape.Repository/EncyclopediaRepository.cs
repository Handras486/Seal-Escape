// <copyright file="EncyclopediaRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model.OtherModels;

    /// <summary>
    /// Stores descriptions of game items.
    /// </summary>
    public static class EncyclopediaRepository
    {
        private static List<EncyclopediaEntryModel> enemies = new List<EncyclopediaEntryModel>()
        {
            new EncyclopediaEntryModel()
            {
                Name = "Swordfish",
                Description = "\nThis fish lives in the arctic oceans.\nThey might try to stab you but are quite dumb so won't follow you anywhere.",
                Image = "/Images/Encyclopedia/weakenemy1.png",
            },
            new EncyclopediaEntryModel()
            {
                Name = "Shark",
                Description = "\nYou might encounter some sharks that got lost on their way to the Mediterranian Sea.\nThey are tired, hungry and would do anything for some fresh seal flesh. Beware!",
                Image = "/Images/Encyclopedia/strongenemy1.png",
            },
            new EncyclopediaEntryModel()
            {
                Name = "Parrot",
                Description = "\nBe careful when flying over the city! The parrots got released from the local zoo by a mischevious worker.\nThey are flying over the streets and might hurt the seal with their peckers!",
                Image = "/Images/Encyclopedia/weakenemy2.png",
            },
            new EncyclopediaEntryModel()
            {
                Name = "Helicopter",
                Description = "\nAs soon as an airborne seal was seen hovering in the city, the military was immediately deployed.\nThey sent their chopper to capture you and are very determined to do so. Navy seals vs real seal!",
                Image = "/Images/Encyclopedia/strongenemy2.png",
            },
        };

        private static List<EncyclopediaEntryModel> food = new List<EncyclopediaEntryModel>()
        {
            new EncyclopediaEntryModel()
            {
                Name = "Fishbone",
                Description = "\nMight be dead for a couple of years but still delecious desserts for the seal.\nThey are everywhere for some misterious reason.",
                Image = "/Images/Encyclopedia/weakfood1.png",
            },
            new EncyclopediaEntryModel()
            {
                Name = "Cod",
                Description = "\nFish that are still alive! How precious! This means three times more calories than fishbones.\nThey strive at the arctic.",
                Image = "/Images/Encyclopedia/strongfood1.png",
            },
            new EncyclopediaEntryModel()
            {
                Name = "Flying Cod",
                Description = "\nLuckily evolution taught cods how to fly so seals can enjoy them even when going on adventures above sea level.",
                Image = "/Images/Encyclopedia/strongfood2.png",
            },
        };

        private static List<EncyclopediaEntryModel> levels = new List<EncyclopediaEntryModel>()
        {
            new EncyclopediaEntryModel()
            {
                Name = "Arctic Seas",
                Description = "\nCold and lonely, but not for this seal! This is his home, everything starts here.",
                Image = "/Images/Encyclopedia/background1.png",
            },
            new EncyclopediaEntryModel()
            {
                Name = "The City",
                Description = "\nIf you swim long enough to develop wings, you will reach the city!\nQuite busy and full of dangers so always pay attention!",
                Image = "/Images/Encyclopedia/background2.png",
            },
        };

        /// <summary>
        /// Gets enemies.
        /// </summary>
        public static List<EncyclopediaEntryModel> Enemies { get => enemies; }

        /// <summary>
        /// Gets food.
        /// </summary>
        public static List<EncyclopediaEntryModel> Food { get => food; }

        /// <summary>
        /// Gets levels.
        /// </summary>
        public static List<EncyclopediaEntryModel> Levels { get => levels; }
    }
}
