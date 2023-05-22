// <copyright file="ApproachingElementLogic.cs" company="PlaceholderCompany">
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
    /// Methods which are applicable to all elements that are approaching from the right.
    /// </summary>
    public class ApproachingElementLogic : GameElementLogic, IApproachingElementLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApproachingElementLogic"/> class.
        /// </summary>
        /// <param name="approachingElement">The element to be manipulated.</param>
        public ApproachingElementLogic(IApproachingElementModel approachingElement)
            : base(approachingElement)
        {
        }

        /// <inheritdoc/>
        public IApproachingElementModel ApproachingElement
        {
            get
            {
                return (IApproachingElementModel)this.GameElement;
            }

            set
            {
            }
        }

        /// <inheritdoc/>
        public void HorizontalApproach()
        {
            this.Move(Direction.Left, this.ApproachingElement.Speed);
        }
    }
}
