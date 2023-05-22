// <copyright file="IFoodLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes methods which are applicable to Feed.
    /// </summary>
    public interface IFoodLogic : IApproachingElementLogic
    {
        /// <summary>
        /// Enter the game area on the right and randomly change directions.
        /// </summary>
        void RandomApproach();
    }
}
