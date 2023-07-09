using Api.Data;
using Api.Services;
using Api.Services.DataServices;
using Api.Services.Logging;
using Microsoft.EntityFrameworkCore;
using NLog;

// load log configuration
LogManager.Setup().LoadConfigurationFromFile("./Config/nlog.config");

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureIis();
builder.Services.ConfigureCors();

// adding logger to services
builder.Services.AddSingleton<ILogService, LogService>();

// Configuring DbContext
builder.Services.AddDbContext<NorthwindContext>(opt =>
{
    opt.UseMySQL(builder.Configuration.GetConnectionString("DatabaseConnectionString")!);
});

builder.Services.ConfigureDataServices();

var jwtConfig = builder.Configuration.GetSection("JwtConfiguration");

builder.Services.ConfigureJwtService(jwtConfig);
builder.Services.ConfigureAuthServices();

builder.Services.AddAutoMapper(typeof(DataMapperService));

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var logger = app.Services.GetRequiredService<ILogService>();
app.ConfigureExceptionHandler(logger);

// HTTP -> HTTPS
// app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

// Disabled for now
app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();