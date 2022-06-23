using FleetInspection.Shared.Models;
using MobileApp.ViewModels;
using Xamarin.Forms;

namespace MobileApp.Views
{
    public partial class NewInspectionPage : ContentPage
    {
        public NewInspectionPage(VehicleModel vehicleModel)
        {
            InitializeComponent();
            BindingContext = new NewInspectionViewModel(vehicleModel);
        }
    }
}