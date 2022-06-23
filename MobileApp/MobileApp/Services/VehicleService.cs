using FleetInspection.Shared.Models;
using MobileApp.Helpers;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public interface IVehicleService
    {
        [Get("/v1/vehicles/{search}")]
        Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync(string search);
    }
    public class VehicleService : IVehicleService
    {
        public async Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync(string search)
        {
            try
            {
#if DEBUG
                var api = RestService.For<IVehicleService>(Session.UnsafeClient());
#else
                var api = RestService.For<IVehicleService>(Session.ApiEndpoint);
#endif
                return await api.GetAllVehiclesAsync(search);
            }
            catch (TaskCanceledException)
            {
                Toast.Show(ApiResponse.GetTimeout(), MessageType.Danger);
            }
            catch (ApiException ex)
            {
                Toast.Show(ApiResponse.GetErrorMessage(ex), MessageType.Danger);
            }
            catch (Exception ex)
            {
                Toast.Show(ex.Message, MessageType.Danger);
            }
            return Enumerable.Empty<VehicleModel>();
        }

    }
}
