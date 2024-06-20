using ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Shared.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection String
/*var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");*/
var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
var DB_PORT = Environment.GetEnvironmentVariable("DB_PORT");
var DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
var DB_USER = Environment.GetEnvironmentVariable("DB_USER");
var DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD");

var connectionString =
    $"database={DB_NAME};host={DB_HOST};port={DB_PORT};user={DB_USER};password={DB_PASSWORD};";

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

builder.Services.AddDbContext<CourseContext>(options =>
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

builder.Services.AddDbContext<AttendanceContext>(options =>
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

builder.Services.AddDbContext<GradeContext>(options =>
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

builder.Services.AddDbContext<TeacherContext>(options =>
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

builder.Services.AddDbContext<AdministratorContext>(options =>
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

builder.Services.AddDbContext<InventoryContext>(options =>
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

builder.Services.AddDbContext<InfrastructureReportContext>(options =>
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

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseCommandService>();
builder.Services.AddScoped<CourseQueryService>();

builder.Services.AddScoped<AttendanceRepository>();
builder.Services.AddScoped<AttendanceCommandService>();
builder.Services.AddScoped<AttendanceQueryService>();

builder.Services.AddScoped<GradeRepository>();
builder.Services.AddScoped<GradeCommandService>();
builder.Services.AddScoped<GradeQueryService>();

builder.Services.AddScoped<TeacherQueryService>();
builder.Services.AddScoped<TeacherCommandService>();
builder.Services.AddScoped<TeacherRepository>();

builder.Services.AddScoped<AdministratorQueryService>();
builder.Services.AddScoped<AdministratorCommandService>();
builder.Services.AddScoped<AdministratorRepository>();

builder.Services.AddScoped<InventoryQueryService>();
builder.Services.AddScoped<InventoryCommandService>();
builder.Services.AddScoped<InventoryRepository>();

builder.Services.AddScoped<InfrastructureReportQueryService>();
builder.Services.AddScoped<InfrastructureReportCommandService>();
builder.Services.AddScoped<InfrastructureReportRepository>();

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
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();