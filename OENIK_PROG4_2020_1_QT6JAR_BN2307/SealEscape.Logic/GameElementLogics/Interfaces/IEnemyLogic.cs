// <copyright file="IEnemyLogic.cs" company="PlaceholderCompany">
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
    /// Describes methods which are applicable to Enemies.
    /// </summary>
    public interface IEnemyLogic : IApproachingElementLogic
    {
        /// <summary>
        /// Enter the game area on the right and aim for the player object.
        /// </summary>
        void AimBotApproach(double targetY);
    }
}
