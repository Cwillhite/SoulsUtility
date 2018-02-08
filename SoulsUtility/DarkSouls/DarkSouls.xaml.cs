﻿using System;
using System.Collections.Generic;
using SoulsUtility.Shared;

using Xamarin.Forms;

namespace SoulsUtility.DarkSouls
{
    public partial class DarkSouls : MasterDetailPage
    {
        public DarkSouls()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
