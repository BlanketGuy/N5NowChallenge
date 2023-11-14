using DAL.Commands;
using DAL.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace N5NowChallenge.Modules
{
    public static class PermissionModule
    {
        public static WebApplication AddPermissionEndpoints(this WebApplication app)
        {
            app.MapGet("/permissions", ([FromServices]IMediator mediator, [FromServices]ILogger logger) =>
            {
                try
                {
                    logger.LogInformation("Query: Get permission list");
                    mediator.Send(new GetPermissionListQuery());
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                }
            });
            app.MapPost("/permissions/modify", (Permission permission, [FromServices]IMediator mediator, [FromServices]ILogger logger) =>
            {
                try
                {
                    logger.LogInformation("Command: Modify permission");
                    mediator.Send(new ModifyPermissionCommand(permission));
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
