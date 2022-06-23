using FleetInspection.DataAccess.Factories;
using FleetInspection.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetInspection.DataAccess.Stores
{
    public interface IVehicleInspectionsStore
    {
        Task InsertInspectionAsync(InspectionModel model);
    }

    public class VehicleInspectionsStore : IVehicleInspectionsStore
    {
        private readonly IDataAccessFactory _db;
        public VehicleInspectionsStore(IDataAccessFactory db)
        {
            _db = db;
        }
        public async Task InsertInspectionAsync(InspectionModel model)
        {
            await _db.SaveData<dynamic>("spVehicleInspections_Insert",
                new
                {
                    VehicleId = model.VehicleId,
                    CheckDate = model.CheckDate,
                    NextCheckDate = model.NextCheckDate,
                    IsCheckPassed = model.IsCheckPassed,
                });
        }
    }
}
