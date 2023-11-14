using DAL.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace N5NowChallenge.Modules
{
    public static class EmployeeModule
    {
        public static WebApplication AddEmployeeEndpoints(this WebApplication app)
        {
            app.MapPost("/employees/requestpermission", (PermissionType permissionType, [FromServices]IMediator mediator, [FromServices]ILogger logger) =>
            {
                try
                {
                    logger.LogInformation("Command: Request permission");
                    mediator.Send(new RequestPermissionCommand(permissionType));
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }
            });
            return app;
        }
    }
}
