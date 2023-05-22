// <copyright file="GameElementModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using Newtonsoft.Json;

    /// <summary>
    /// Methods and properties which are applicable to GameElements.
    /// </summary>
    public abstract class GameElementModel : IGameElementModel
    {
        /// <summary>
        /// GameModel covered area.
        /// </summary>
        protected Geometry area;

        /// <summary>
        /// GameModel current rotational degree.
        /// </summary>
        protected double rotationalDegree;

        private readonly double cachedX = default;
        private readonly double cachedY = default;
        private readonly double cachedDegree = default;
        private Geometry cachedArea = default;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameElementModel"/> class.
        /// </summary>
        /// <param name="xPosition">GameModel x position.</param>
        /// <param name="yPosition">GameModel y position.</param>
        [JsonConstructor]
        public GameElementModel(double xPosition, double yPosition)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }

        /// <inheritdoc/>
        public double XPosition { get; set; }

        /// <inheritdoc/>
        public double YPosition { get; set; }

        /// <summary>
        /// Gets or sets rotational degree in radian of GameModel.
        /// </summary>
        public double Radian
        {
            get
            {
                return Math.PI * this.rotationalDegree / 180;
            }

            set
            {
                this.rotationalDegree = 180 * value / Math.PI;
            }
        }

        /// <inheritdoc/>
        public Geometry RealArea
        {
            get
            {
                if (this.cachedArea == null || (this.cachedX != this.XPosition || this.cachedY != this.YPosition || this.cachedDegree != this.rotationalDegree))
                {
                    TransformGroup tg = new TransformGroup();
                    tg.Children.Add(new TranslateTransform(this.XPosition, this.YPosition));
                    tg.Children.Add(new RotateTransform(this.rotationalDegree, this.XPosition, this.YPosition));
                    this.area.Transform = tg;
                    this.cachedArea = this.area;
                    return this.area.GetFlattenedPathGeometry();
                }
                else
                {
                    return this.cachedArea.GetFlattenedPathGeometry();
                }
            }
        }

        /// <inheritdoc/>
        public bool IsCollision(IGameElementModel other)
        {
            return Geometry.Combine(this.RealArea, other.RealArea, GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }
}
