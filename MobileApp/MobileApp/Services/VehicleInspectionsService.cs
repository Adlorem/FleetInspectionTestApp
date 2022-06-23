using FleetInspection.Shared.Models;
using MobileApp.Helpers;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IVehicleInspectionsService
    {
        [Post("/v1/inspections")]
        Task SaveVehicleInspectionAsync([Body] InspectionModel model);
    }
    public class VehicleInspectionsService : IVehicleInspectionsService
    {
        public async Task SaveVehicleInspectionAsync([Body] InspectionModel model)
        {
            try
            {
#if DEBUG
                var api = RestService.For<IVehicleInspectionsService>(Session.UnsafeClient());
#else
                var api = RestService.For<IVehicleInspectionsService>(Session.ApiEndpoint);
#endif

                await api.SaveVehicleInspectionAsync(model);
                Toast.Show(ApiResponse.GetCompleted(), MessageType.Success);
            }
            catch (TaskCanceledException)
            {
                Toast.Show(ApiResponse.GetTimeout(), MessageType.Danger);
            }
            catch (ApiException ex)
            {
                var message = ApiResponse.GetErrorMessage(ex);
                Toast.Show(message, MessageType.Danger);
            }
            catch (Exception ex)
            {
                Toast.Show(ex.Message, MessageType.Danger);
            }
        }
    }
}
