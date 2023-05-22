// <copyright file="IPlayerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes properties applicable to Player elements.
    /// </summary>
    public interface IPlayerModel : IGameElementModel
    {
        /// <summary>
        /// Gets or sets Player current life.
        /// </summary>
        int LivesLeft { get; set; }

        /// <summary>
        /// Gets or sets Player total life.
        /// </summary>
        int LivesTotal { get; set; }

        /// <summary>
        /// Gets Player ascending speed.
        /// </summary>
        int PlayerAscentSpeed { get; }

        /// <summary>
        /// Gets or sets a value storing the strength of gravity.
        /// </summary>
        double GravityStrength { get; set; }
    }
}
