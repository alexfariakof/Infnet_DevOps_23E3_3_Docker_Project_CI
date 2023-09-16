using Amazon.XRay.Recorder.Core;
using HealthChecks.UI.Client;
using Infnet_DevOps_23E3_3_Docker_Project.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Application Insights X-Ray AWS
AWSXRayRecorder.InitializeInstance(builder.Configuration);

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

builder.Services.AddHealthChecksUI(s =>
{
    s.AddHealthCheckEndpoint("Infnet API HealthChecks", builder.Configuration.GetSection("HealthChecks:URI").Value);
}).AddInMemoryStorage();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

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

//app.Run();

if (app.Environment.IsDevelopment())
{
    app.Run("http://0.0.0.0:42536");
}
else
{
    app.Run("http://0.0.0.0:42537");
}