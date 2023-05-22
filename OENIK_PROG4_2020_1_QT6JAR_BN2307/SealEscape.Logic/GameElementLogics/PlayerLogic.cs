// <copyright file="PlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Logic.GameElementLogics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model;

    /// <summary>
    /// Methods which are applicable to the Player.
    /// </summary>
    public class PlayerLogic : GameElementLogic, IPlayerLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerLogic"/> class.
        /// </summary>
        /// <param name="gameElement">The element to manipulate.</param>
        public PlayerLogic(IGameElementModel gameElement)
            : base(gameElement)
        {
            this.DescentSpeed = 1;
        }

        /// <summary>
        /// Gets or sets the player to manipulate.
        /// </summary>
        public IPlayerModel Player
        {
            get
            {
                return (IPlayerModel)this.GameElement;
            }

            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the speed of the fall.
        /// </summary>
        public double DescentSpeed { get; set; }

        /// <inheritdoc/>
        public void Ascend()
        {
            this.Player.YPosition -= this.Player.PlayerAscentSpeed;

            // Reset descent speed
            this.DescentSpeed = 1;
        }

        /// <inheritdoc/>
        public void Descend()
        {
            this.Player.YPosition += this.DescentSpeed;
            this.DescentSpeed += this.Player.GravityStrength;
        }

        /// <inheritdoc/>
        public void DecreaseLivesLeft(int value)
        {
            this.Player.LivesLeft -= value;
        }
    }
}
