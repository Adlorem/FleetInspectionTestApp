using FleetInspection.Api.Extensions;
using FleetInspection.Api.Repositories;
using FleetInspection.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace FleetInspection.Api.EndpointDefinitions
{
    public class VehicleInspectionsEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/v1/inspections",
                (IVehicleInspectionsRepository repo, InspectionModel model) => SaveInspectionAsync(repo, model))
                    .ProducesProblem(StatusCodes.Status400BadRequest)
                    .ProducesProblem(StatusCodes.Status500InternalServerError)
                    .Produces(StatusCodes.Status200OK)
                    .Accepts<InspectionModel>("application/json");
        }

        private async Task<IResult> SaveInspectionAsync(IVehicleInspectionsRepository repo, InspectionModel model)
        {
            try
            {
                var errors = ValidateModel(model);
                if (errors.Count() > 0)
                {
                    return Results.BadRequest(errors);
                }
                else
                {
                    await repo.SaveInspectionAsync(model);
                    return Results.Ok();
                }
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private IEnumerable<string> ValidateModel(InspectionModel model)
        {
            var errors = new List<string>();

            if (model.CheckDate > DateTime.Now)
            {
                errors.Add("Nie można zarejestrować inspekcji w przyszłości.");
            }
            if (model.CheckDate.Date >= model.NextCheckDate.Date)
            {
                errors.Add("Data następnej inspekcji musi być większa od daty obecnej inspekcji.");
            }
            return errors;
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IVehicleInspectionsRepository, VehicleInspectionsRepository>();
        }
    }
}
