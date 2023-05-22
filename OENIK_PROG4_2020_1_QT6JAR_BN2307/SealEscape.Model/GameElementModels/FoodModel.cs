// <copyright file="FoodModel.cs" company="PlaceholderCompany">
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
    /// Methods and properties which are applicable to Food.
    /// </summary>
    public class FoodModel : GameElementModel, IFoodModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoodModel"/> class.
        /// </summary>
        /// <param name="xPosition">Food x position.</param>
        /// <param name="yPosition">Food y position.</param>
        /// <param name="value">Food worth value.</param>
        /// <param name="hasrandomapproach">Food approach value.</param>
        /// <param name="speed">Food speed value.</param>
        [JsonConstructor]
        public FoodModel(double xPosition, double yPosition, int value, bool hasrandomapproach, double speed)
            : base(xPosition, yPosition)
        {
            this.Value = value;
            this.HasRandomApproach = hasrandomapproach;
            this.Speed = speed;

            if (value == 3)
            {
                this.Name = "strong";
            }
            else
            {
                this.Name = "weak";
            }

            RectangleGeometry placeholderarea = new RectangleGeometry(new Rect(xPosition, yPosition, 50, 50));
            this.area = placeholderarea;
        }

        /// <inheritdoc/>
        public int Value { get; set; }

        /// <inheritdoc/>
        public bool HasRandomApproach { get; set; }

        /// <inheritdoc/>
        public double Speed { get; set; }

        /// <inheritdoc/>
        public string Name { get; set; }
    }
}
