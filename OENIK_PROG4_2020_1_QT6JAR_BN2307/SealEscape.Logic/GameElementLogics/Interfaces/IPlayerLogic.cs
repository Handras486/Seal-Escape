// <copyright file="IPlayerLogic.cs" company="PlaceholderCompany">
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
    /// Describes methods which are applicable to the Player GameElement.
    /// </summary>
    public interface IPlayerLogic : IGameElementLogic
    {
        /// <summary>
        /// Gets or sets current descent speed.
        /// </summary>
        double DescentSpeed { get; set; }

        /// <summary>
        /// Descend with simulated gravitational force.
        /// </summary>
        void Descend();

        /// <summary>
        /// Ascend steadily.
        /// </summary>
        void Ascend();

        /// <summary>
        /// Descrease lives.
        /// </summary>
        /// <param name="value">Delta of decrement.</param>
        void DecreaseLivesLeft(int value);
    }
}
