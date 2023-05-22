// <copyright file="EnemyLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using SealEscape.Model;

    /// <summary>
    /// Methods which are applicable to Enemies.
    /// </summary>
    public class EnemyLogic : ApproachingElementLogic, IEnemyLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyLogic"/> class.
        /// </summary>
        /// <param name="approachingElement">The element to be manipulated.</param>
        public EnemyLogic(IApproachingElementModel approachingElement)
            : base(approachingElement)
        {
        }

        /// <summary>
        /// Gets or sets the enemy to manipulate.
        /// </summary>
        public IEnemyModel Enemy
        {
            get
            {
                return (IEnemyModel)this.GameElement;
            }

            set
            {
            }
        }

        /// <inheritdoc/>
        public void AimBotApproach(double targetY)
        {
            this.Move(Direction.Left, this.ApproachingElement.Speed);
            if (this.Enemy.RealArea.Bounds.Bottom > targetY)
            {
                this.Move(Direction.Up, this.ApproachingElement.Speed / 3);
            }

            if (this.Enemy.RealArea.Bounds.Top < targetY)
            {
                this.Move(Direction.Down, this.ApproachingElement.Speed / 3);
            }
        }
    }
}
