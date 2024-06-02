using ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ClassroomContext>(options =>
{
    options.UseMySQL(connectionString);

    if (builder.Environment.IsDevelopment())
    {
        options.LogTo(Console.WriteLine, LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
    else if (builder.Environment.IsProduction())
    {
        options.LogTo(Console.WriteLine, LogLevel.Error)
               .EnableDetailedErrors();
    }
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ROCKET.RocketOrganizeBackend.Classroom",
        Version = "v1",
        Description = "ROCKET RocketOrganizeBackend Classroom API",
        Contact = new OpenApiContact
        {
            Name = "ROCKET Studios",
            Email = "contact@rocket.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        }
    });
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<ClassroomRepository>();
builder.Services.AddScoped<ClassroomCommandService>();
builder.Services.AddScoped<ClassroomQueryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ClassroomContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();