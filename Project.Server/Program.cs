using Project.Infrastructure.Data.Repositories.Users;
using Project.Server.Services.Users;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;
using Project.Infrastructure.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//response compression
//builder.Services.AddResponseCompression(options =>
//{
//    options.EnableForHttps = true;
//    //default
//    options.Providers.Add<BrotliCompressionProvider>();
//    options.Providers.Add<GzipCompressionProvider>();
//    options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
//});

//Health Check
builder.Services.AddHealthChecks().AddCheck<SqlHealthCheck>("sqlserver", HealthStatus.Unhealthy);
builder.Services.AddHealthChecksUI().AddInMemoryStorage();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCors", builder =>
    {
        builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

//Dapper
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddScoped<SqlConnection>(option => new SqlConnection(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<Compiler, SqlServerCompiler>();
builder.Services.AddScoped(option =>
{
    var connection = option.GetRequiredService<SqlConnection>();
    var compiler = option.GetRequiredService<Compiler>();
    return new QueryFactory(connection, compiler);
});

//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Service
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("VueCors");
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    endpoints.MapHealthChecks(
        "/health",
        new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

    endpoints.MapHealthChecksUI(options =>
    {
        options.UIPath = "/health-ui";
    }).RequireHost($"*:{builder.Configuration["ManagementPort"]}");
});

app.UseAuthorization();

//Response Comporession
//app.UseResponseCompression();

//Health Check
//app.MapHealthChecks(
//    "/health",
//    new HealthCheckOptions
//    {
//        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//    });

//app.UseHealthChecksUI();

app.MapRazorPages();

app.Run();