using FleetInspection.Shared.Models;
using MobileApp.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class NewInspectionViewModel : BaseViewModel
    {
        private readonly IVehicleInspectionsService _vehicleService;

        public NewInspectionViewModel(VehicleModel vehicleModel)
        {
            _vehicleService = DependencyService.Get<IVehicleInspectionsService>();
            Vehicle = vehicleModel;
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private void ValidateSave()
        {
            var value = CurrentDate < NextDate;
            CanSave = value;
        }

        private bool _canSave;
        public bool CanSave 
        {
            get { return _canSave; }
            set
            {
                SetProperty(ref _canSave, value);
            }
        }

        private VehicleModel _vehicle;
        public VehicleModel Vehicle
        {
            get { return _vehicle; }
            set
            {
                SetProperty(ref _vehicle, value);
            }
        }

        private DateTime _currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                SetProperty(ref _currentDate, value);
                ValidateSave();
            }
        }

        private DateTime _nextDate = DateTime.Now;
        public DateTime NextDate
        {
            get { return _nextDate; }
            set
            {
                SetProperty(ref _nextDate, value);
                ValidateSave();
            }
        }

        private bool _vehicleState;
        public bool VehicleState
        {
            get { return _vehicleState; } 
            set
            {
                SetProperty(ref _vehicleState, value);
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            if (IsModelValid() == false) return;
            await SaveInspectionAsync();
            MessagingCenter.Send<Application>(Application.Current, "Refresh");
            await Shell.Current.GoToAsync("..");
        }

        private async Task SaveInspectionAsync()
        {
            IsBusy = true;
            var model = BuidInspectionModel();
            await _vehicleService.SaveVehicleInspectionAsync(model);
            IsBusy = false;
        }

        private InspectionModel BuidInspectionModel()
        {
            return new InspectionModel
            {
                VehicleId = Vehicle.Id,
                CheckDate = CurrentDate,
                NextCheckDate = NextDate,
                IsCheckPassed = VehicleState
            };
        }

        /// <summary>
        /// Todo proper model validation
        /// </summary>
        /// <returns></returns>
        private bool IsModelValid()
        {
            var flag = true;
            if (CurrentDate > NextDate)
            {
                flag = false;
            }
            return flag;
        }
    }
}
