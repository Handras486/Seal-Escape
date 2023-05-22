// <copyright file="ShopPage.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_QT6JAR_BN2307.Navigation
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using SealEscape.Model.OtherModels.Interfaces;

    /// <summary>
    /// Interaction logic for ShopPage.xaml.
    /// </summary>
    public partial class ShopPage : Page
    {
        private MenuControl control;
        private ObservableCollection<IPowerupModel> shopitems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopPage"/> class.
        /// </summary>
        public ShopPage()
        {
            this.InitializeComponent();
            this.control = new MenuControl();
            this.shopitems = this.control.LoadShop();

            this.totalfish.Content = "Total Fish Count:" + this.control.GetCollectedFish();
            this.loadshop.ItemsSource = this.shopitems;
            this.loaddesc.ItemsSource = this.shopitems;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if (this.loadshop.SelectedItem != null)
            {
                if (this.control.GetCollectedFish() < this.shopitems.ElementAt(this.loadshop.SelectedIndex).Price)
                {
                    this.responsetext.Content = "Not enough fish!";
                }
                else
                {
                    this.control.PurchaseShopItem(this.shopitems.ElementAt(this.loadshop.SelectedIndex).Name);
                    this.totalfish.Content = "Total Fish Count:" + this.control.GetCollectedFish();
                    this.responsetext.Content = "Successful Purchase!";
                    this.shopitems.RemoveAt(this.loadshop.SelectedIndex);
                }
            }
        }
    }
}
