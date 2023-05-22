// <copyright file="IApproachingElementModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes properties which are applicable to all elements that are approaching from the right.
    /// </summary>
    public interface IApproachingElementModel : IGameElementModel
    {
        /// <summary>
        /// Gets or sets horizontal speed for moving the GameElement.
        /// </summary>
        double Speed { get; set; }

        /// <summary>
        /// Gets or sets name of GameElement.
        /// </summary>
        string Name { get; set; }
    }
}
