using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using N5NowChallenge.Modules;
using Serilog;

namespace N5NowChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                Log.Information("Starting web application");
                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseSerilog();

                // Add services to the container.
                builder.Services.AddAuthorization();
                builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
                builder.Services.AddTransient<IPermissionRepository, PermissionRepository>();
                builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
                builder.Services.AddDbContext<ChallengeDbContext>();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();
                app.AddEmployeeEndpoints();
                app.AddPermissionEndpoints();
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}