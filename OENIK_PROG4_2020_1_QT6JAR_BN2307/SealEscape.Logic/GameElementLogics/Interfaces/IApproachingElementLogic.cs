// <copyright file="IApproachingElementLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model;

    /// <summary>
    /// Describes methods which are applicable to all elements that are approaching from the right.
    /// </summary>
    public interface IApproachingElementLogic : IGameElementLogic
    {
        /// <summary>
        /// Gets or sets the element to be manipulated.
        /// </summary>
        IApproachingElementModel ApproachingElement { get; set; }

        /// <summary>
        /// Enter the game area from the right and move to the left without changing direction.
        /// </summary>
        void HorizontalApproach();
    }
}
