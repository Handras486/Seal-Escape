// <copyright file="IFoodModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Describes properties applicable to Food elements.
    /// </summary>
    public interface IFoodModel : IApproachingElementModel
    {
        /// <summary>
        /// Gets or sets how much the collected food is worth.
        /// </summary>
        int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it should approach randomly.
        /// </summary>
        bool HasRandomApproach { get; set; }
    }
}
