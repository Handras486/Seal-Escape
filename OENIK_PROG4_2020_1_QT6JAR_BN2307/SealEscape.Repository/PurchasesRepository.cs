// <copyright file="PurchasesRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SealEscape.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Store all purchased ShopItems including powerups and skins.
    /// </summary>
    public class PurchasesRepository : IRepoInterface<IShopItemModel>
    {
        /// <summary>
        /// File containing purchased items.
        /// </summary>
        private readonly string purchasesRepoPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + "\\SealEscape\\Purchases\\";

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchasesRepository"/> class.
        /// </summary>
        public PurchasesRepository()
        {
            Directory.CreateDirectory(this.purchasesRepoPath);
            if (!File.Exists(this.purchasesRepoPath + "purchases.list"))
            {
                File.Create(this.purchasesRepoPath + "purchases.list").Close();
            }
        }

        /// <inheritdoc/>
        public virtual void Create(IShopItemModel data, string name)
        {
            if (!File.ReadAllLines(this.purchasesRepoPath + "purchases.list").Contains(name))
            {
                StreamWriter sw = new StreamWriter(this.purchasesRepoPath + "purchases.list", true);
                sw.WriteLine(name);
                sw.Close();
            }
            else
            {
                throw new InvalidOperationException("You already own this item!");
            }
        }

        /// <inheritdoc/>
        public void Delete(IShopItemModel data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IShopItemModel Read(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if we have already purchased an item.
        /// </summary>
        /// <param name="name">The item.</param>
        /// <returns>Whether we purchased it.</returns>
        public bool Contains(string name)
        {
            try
            {
                if (File.ReadAllLines(this.purchasesRepoPath + "purchases.list").Contains(name))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a list of all purchased items.
        /// </summary>
        /// <returns>A list of all purchased items.</returns>
        public ObservableCollection<IShopItemModel> ReadAll()
        {
            ObservableCollection<IShopItemModel> purchases = new ObservableCollection<IShopItemModel>();
            StreamReader sr = new StreamReader(this.purchasesRepoPath + "purchases.list");

            foreach (var item in sr.ReadToEnd().Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None))
            {
                if (ShopRepository.Read(item) != null)
                {
                    purchases.Add(ShopRepository.Read(item));
                }
            }

            sr.Close();

            return purchases;
        }

        /// <inheritdoc/>
        public void Update(IShopItemModel existing, IShopItemModel newdata)
        {
            throw new NotImplementedException();
        }
    }
}
