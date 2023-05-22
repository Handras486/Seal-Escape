// <copyright file="IGameElementModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// Describes properties applicable to all GameElements.
    /// </summary>
    public interface IGameElementModel
    {
        /// <summary>
        /// Gets or sets horizontal position of GameElement.
        /// </summary>
        double XPosition { get; set; }

        /// <summary>
        /// Gets or sets vertical position of GameElement.
        /// </summary>
        double YPosition { get; set; }

        /// <summary>
        /// Gets the current area of GameElement.
        /// </summary>
        Geometry RealArea { get; }

        /// <summary>
        /// Checks if GameElement is colliding with another GameElement.
        /// </summary>
        /// <param name="other">Instance of other GameElement.</param>
        /// <returns>Collision value.</returns>
        bool IsCollision(IGameElementModel other);
    }
}
