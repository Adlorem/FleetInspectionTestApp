using FleetInspection.Api.Extensions;
using FleetInspection.Api.Repositories;
using FleetInspection.Shared.Models;

namespace FleetInspection.Api.EndpointDefinitions
{
    public class VehicleEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/v1/vehicles/{search?}",
            (IVehicleRepository repo, string? search) => GetVehiclesAsync(repo, search))
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .Produces<IEnumerable<VehicleModel>>();

            app.MapGet("/v1/vehicles",
            (IVehicleRepository repo) => GetVehiclesAsync(repo, null))
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status500InternalServerError)
                .Produces<IEnumerable<VehicleModel>>();

        }

        private async Task<IResult> GetVehiclesAsync(IVehicleRepository repo, string? search)
        {
            try
            {
                var result = await repo.GetAllVehiclesAsync(search);
                if (result != null)
                {
                    return Results.Ok(result);
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IVehicleRepository, VehicleRepository>();
        }
    }
}
