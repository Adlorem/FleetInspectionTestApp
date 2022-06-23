using FleetInspection.DataAccess.Factories;
using FleetInspection.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.DataAccess.Stores
{
    public interface IVehicleStore
    {
        public Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync (string? search);
    }

    public class VehicleStore : IVehicleStore
    {
        private readonly IDataAccessFactory _db;
        public VehicleStore(IDataAccessFactory db)
        {
            _db = db;
        }
        public async Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync(string? search)
        {
            return await _db.LoadData<VehicleModel, dynamic>("spVehicle_GetAll", new { Search = search });
        }
    }
}
