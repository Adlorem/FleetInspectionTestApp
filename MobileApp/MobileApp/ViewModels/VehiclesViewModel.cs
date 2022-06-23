using FleetInspection.Shared.Models;
using MobileApp.Services;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class VehiclesViewModel : BaseViewModel
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesViewModel()
        {
            _vehicleService = DependencyService.Get<IVehicleService>();
            SearchVehiclesCommand = new Command(async () => await GetAllVehiclesAsync());
            Task.Run(async ()=> await GetAllVehiclesAsync());

            MessagingCenter.Subscribe<Application>(Application.Current, "Refresh", (sender) =>
            {
                Task.Run(async () => await GetAllVehiclesAsync());
            });
        }

        private async Task GetAllVehiclesAsync()
        {
            IsBusy = true;
            var result = await _vehicleService.GetAllVehiclesAsync(_search);
            if (result != null)
            {
                Vehicles = new ObservableCollection<VehicleModel>(result);
            }
            IsBusy = false;
        }

        private string _search = string.Empty;
        public string Search
        {
            get { return _search; }
            set
            {
                SetProperty(ref _search, value);
            }
        }

        private VehicleModel _selectedVehicle;
        public VehicleModel SelectedVehicle
        {
            get
            {
                return _selectedVehicle;
            }
            set
            {
                if (_selectedVehicle != value)
                {
                    _selectedVehicle = value;
                    ShowVehicleInspectionDialog();
                }
            }
        }

        private async void ShowVehicleInspectionDialog()
        {
            if (_selectedVehicle == null) return;
            await Application.Current.MainPage.Navigation.PushModalAsync(new NewInspectionPage(_selectedVehicle));
            SelectedVehicle = null;
        }

        private ObservableCollection<VehicleModel> _vehicles = new ObservableCollection<VehicleModel>();
        public ObservableCollection<VehicleModel> Vehicles
        {
            get { return _vehicles; }
            set
            {
                SetProperty(ref _vehicles, value);
            }
        }

        public ICommand SearchVehiclesCommand { get; }
    }
}