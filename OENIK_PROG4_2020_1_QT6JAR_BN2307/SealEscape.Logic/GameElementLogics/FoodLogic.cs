// <copyright file="FoodLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic
{
    using System;
    using SealEscape.Model;

    /// <summary>
    /// Methods which are applicable to Feed.
    /// </summary>
    public class FoodLogic : ApproachingElementLogic, IFoodLogic
    {
        /// <summary>
        /// This counter is used in RandomApproach() to determine whether a direction change is necessary.
        /// </summary>
        private int tickCounter = 0;

        /// <summary>
        /// Store the current state for RandomApproach().
        /// </summary>
        private int dice = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodLogic"/> class.
        /// </summary>
        /// <param name="approachingElement">The element to be manipulated.</param>
        public FoodLogic(IApproachingElementModel approachingElement)
            : base(approachingElement)
        {
        }

        /// <summary>
        /// Gets or sets the food to manipulate.
        /// </summary>
        public IFoodModel Food
        {
            get
            {
                return (IFoodModel)this.GameElement;
            }

            set
            {
            }
        }

        /// <inheritdoc/>
        public void RandomApproach()
        {
            if (this.tickCounter % 10 == 0)
            {
                this.dice = -this.dice;
            }

            switch (this.dice)
            {
                case 1:
                    this.Move(Direction.Up, this.ApproachingElement.Speed);
                    break;
                case -1:
                    this.Move(Direction.Down, this.ApproachingElement.Speed);
                    break;
                default:
                    break;
            }

            this.Move(Direction.Left, this.ApproachingElement.Speed);

            this.tickCounter++;
        }
    }
}
