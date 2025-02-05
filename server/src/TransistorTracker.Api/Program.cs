using TransistorTracker.Api;
using TransistorTracker.Dal.Contexts;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Server.Interfaces;
using TransistorTracker.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(config => config.AllowNullCollections = true, typeof(Program).Assembly,
    typeof(UserService).Assembly);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITransitorTrackerDatabase, TransistorTrackerContext>(_ =>
    new TransistorTrackerContext(EnvironmentVariables.DbConnectionString));
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<ISoftwareService, SoftwareService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    o => o
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
);

app.MapControllers();
app.Run();
