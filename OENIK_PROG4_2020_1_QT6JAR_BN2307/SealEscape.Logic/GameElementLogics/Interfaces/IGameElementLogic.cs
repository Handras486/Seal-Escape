// <copyright file="IGameElementLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model;

    /// <summary>
    /// Describes methods which are applicable to all GameElements.
    /// </summary>
    public interface IGameElementLogic
    {
        /// <summary>
        /// Set XPosition to a given value.
        /// </summary>
        /// <param name="x">Set XPosition to this value.</param>
        void SetX(double x);

        /// <summary>
        /// Set YPosition to a given value.
        /// </summary>
        /// <param name="y">Set YPosition to this value.</param>
        void SetY(double y);

        /// <summary>
        /// Manipulate XPosition and YPosition with a given direction and a delta.
        /// </summary>
        /// <param name="direction">Direction to move in.</param>
        /// <param name="amount">This much to move.</param>
        void Move(Direction direction, double amount);
    }
}
