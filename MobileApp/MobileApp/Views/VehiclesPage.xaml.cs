using MobileApp.Services;
using MobileApp.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    public partial class VehiclesPage : ContentPage
    {
        public VehiclesPage()
        {
            InitializeComponent();
            BindingContext = new VehiclesViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}