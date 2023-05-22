// <copyright file="PlayerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using Newtonsoft.Json;

    /// <summary>
    /// Methods and properties which are applicable to Players.
    /// </summary>
    public class PlayerModel : GameElementModel, IPlayerModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerModel"/> class.
        /// </summary>
        /// <param name="xPosition">Player x position.</param>
        /// <param name="yPosition">Player y position.</param>
        /// <param name="livesTotal">Player total lives.</param>
        [JsonConstructor]
        public PlayerModel(double xPosition, double yPosition, int livesTotal)
            : base(xPosition, yPosition)
        {
            this.LivesTotal = livesTotal;
            this.LivesLeft = this.LivesTotal;

            this.PlayerAscentSpeed = 20;
            this.GravityStrength = 1;

            RectangleGeometry placeholderarea = new RectangleGeometry(new Rect(xPosition, yPosition, 150, 75));
            this.area = placeholderarea;
        }

        /// <summary>
        /// Gets or sets name of Player.
        /// </summary>
        public static string PlayerName { get; set; } = "Anonymus";

        /// <inheritdoc/>
        public int LivesLeft { get; set; }

        /// <inheritdoc/>
        public int LivesTotal { get; set; }

        /// <inheritdoc/>
        public int PlayerAscentSpeed { get; }

        /// <inheritdoc/>
        public double GravityStrength { get; set; }
    }
}
