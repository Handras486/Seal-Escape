// <copyright file="IRepoInterface.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes methods and properties which are responsible for data storage.
    /// </summary>
    /// <typeparam name="T">Type of data stored by repository.</typeparam>
    public interface IRepoInterface<T>
    {
        /// <summary>
        /// Append to storage.
        /// </summary>
        /// <param name="data">The data structure to append.</param>
        /// <param name="name">Identifier of data.</param>
        void Create(T data, string name);

        /// <summary>
        /// Get stored data.
        /// </summary>
        /// <returns>The data.</returns>
        /// <param name="name">Identifier of data.</param>
        T Read(string name);

        /// <summary>
        /// Overwrite existing data.
        /// </summary>
        /// <param name="existing">Data structure to overwrite.</param>
        /// <param name="newdata">Data structure to write.</param>
        void Update(T existing, T newdata);

       /// <summary>
       /// Delete existing data from repository.
       /// </summary>
       /// <param name="data">Data to delete.</param>
        void Delete(T data);
    }
}
