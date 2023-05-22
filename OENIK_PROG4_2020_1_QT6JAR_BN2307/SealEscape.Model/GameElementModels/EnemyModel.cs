// <copyright file="EnemyModel.cs" company="PlaceholderCompany">
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
    /// Methods and properties which are applicable to Enemies.
    /// </summary>
    public class EnemyModel : GameElementModel, IEnemyModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyModel"/> class.
        /// </summary>
        /// <param name="xPosition">Enemy x position.</param>
        /// <param name="yPosition">Enemy y position.</param>
        /// <param name="damage">Enemy damage value.</param>
        /// <param name="hasaimbot">Enemy aimbot value.</param>
        /// <param name="speed">Enemy speed value.</param>
        [JsonConstructor]
        public EnemyModel(double xPosition, double yPosition, int damage, bool hasaimbot, double speed)
            : base(xPosition, yPosition)
        {
            this.Damage = damage;
            this.HasAimBot = hasaimbot;
            this.Speed = speed;

            if (damage == 3)
            {
                this.Name = "strong";
                RectangleGeometry placeholderarea = new RectangleGeometry(new Rect(xPosition, yPosition, 200, 150));
                this.area = placeholderarea;
            }
            else
            {
                this.Name = "weak";
                RectangleGeometry placeholderarea = new RectangleGeometry(new Rect(xPosition, yPosition, 150, 100));
                this.area = placeholderarea;
            }
        }

        /// <inheritdoc/>
        public int Damage { get; set; }

        /// <inheritdoc/>
        public bool HasAimBot { get; set; }

        /// <inheritdoc/>
        public double Speed { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }
    }
}
