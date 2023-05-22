// <copyright file="GameElementLogic.cs" company="PlaceholderCompany">
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
    /// Methods which are applicable to all GameElements.
    /// </summary>
    public abstract class GameElementLogic : IGameElementLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameElementLogic"/> class.
        /// </summary>
        /// <param name="gameElement">The GameElement to be manipulated.</param>
        public GameElementLogic(IGameElementModel gameElement)
        {
            this.GameElement = gameElement;
        }

        /// <summary>
        /// Gets or sets the GameElement to be manipulated.
        /// </summary>
        protected IGameElementModel GameElement { get; set; }

        /// <inheritdoc/>
        public void Move(Direction direction, double amount)
        {
            switch (direction)
            {
                case Direction.Left:
                    this.GameElement.XPosition -= amount;
                    break;
                case Direction.Right:
                    this.GameElement.XPosition += amount;
                    break;
                case Direction.Up:
                    this.GameElement.YPosition -= amount;
                    break;
                case Direction.Down:
                    this.GameElement.YPosition += amount;
                    break;
                default:
                    break;
            }
        }

        /// <inheritdoc/>
        public void SetX(double x)
        {
            this.GameElement.XPosition = x;
        }

        /// <inheritdoc/>
        public void SetY(double y)
        {
            this.GameElement.YPosition = y;
        }
    }
}