using FleetInspection.DataAccess.Stores;
using FleetInspection.Shared.Models;

namespace FleetInspection.Api.Repositories
{
    internal interface IVehicleInspectionsRepository
    {
        Task SaveInspectionAsync(InspectionModel model);
    }
    internal class VehicleInspectionsRepository : IVehicleInspectionsRepository
    {
        private readonly IVehicleInspectionsStore _vehicleInspectionsStore;
        public VehicleInspectionsRepository(IVehicleInspectionsStore vehicleInspectionsStore)
        {
            _vehicleInspectionsStore = vehicleInspectionsStore;
        }
        public async Task SaveInspectionAsync(InspectionModel model)
        {
            await _vehicleInspectionsStore.InsertInspectionAsync(model);
        }
    }
}
