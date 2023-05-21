using Dapper;
using Project.Server.Models;
using Project.Server.Repositories.Users;
using Project.Server.Services;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCors", builder =>
    {
        builder.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddScoped<SqlConnection>(option => new SqlConnection(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<Compiler, SqlServerCompiler>();
builder.Services.AddScoped(option =>
{
    var connection = option.GetRequiredService<SqlConnection>();
    var compiler = option.GetRequiredService<Compiler>();
    return new QueryFactory(connection, compiler);
});


builder.Services.AddScoped<IUserRepository, UserRepository>();
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
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
