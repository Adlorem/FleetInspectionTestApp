using FleetInspection.DataAccess.Stores;
using FleetInspection.Shared.Models;

namespace FleetInspection.Api.Repositories
{
    internal interface IVehicleRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync(string? search);
    }
    internal class VehicleRepository : IVehicleRepository
    {
        private readonly IVehicleStore _vehicleStore;
        public VehicleRepository(IVehicleStore vehicleStore)
        {
            _vehicleStore = vehicleStore;
        }
        public async Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync(string? search)
        {
            return await _vehicleStore.GetAllVehiclesAsync(search);
        }
    }
}
