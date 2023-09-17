using HealthChecks.UI.Client;
using Infnet_DevOps_23E3_3_Docker_Project.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add HelthChecks
builder.Services.AddHealthChecks()
                .AddMySql(
                    connectionString: builder.Configuration.GetConnectionString("MySqlConnectionString"),
                    healthQuery: "SELECT 1;",
                    name: "MySql Server AWS RDS ",
                    failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy
                )
                .AddUrlGroup(new Uri("http://alexfariakof.com:42536/swagger"), "Api Health Checks DEV")
                .AddUrlGroup(new Uri("http://alexfariakof.com:42537/swagger"), "Api Health Checks PROD")
                .AddUrlGroup(new Uri("http://httpbin.org/status/200"), "Api Terceiro Nao Autenticada")
                .AddCheck<HealthCheckRandom>(name: "Api Terceiro Autenticada");

if (builder.Environment.IsProduction())
{
    builder.Services.AddHealthChecksUI(s =>
    {
        s.AddHealthCheckEndpoint("Infnet API HealthChecks", builder.Configuration.GetSection("HealthChecks:URI").Value);
    }).AddInMemoryStorage();
    builder.Services.AddApplicationInsightsTelemetry();
}
var app = builder.Build();

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsProduction())
{
    app.UseRouting()
   .UseEndpoints(config =>
   {
       config.MapHealthChecks("/healthz", new HealthCheckOptions
       {
           Predicate = _ => true,
           ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
       });

       config.MapHealthChecksUI();
   });
}

app.Run();
