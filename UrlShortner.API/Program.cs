using Microsoft.EntityFrameworkCore;
using UrlShortner.API.Data;
using UrlShortner.API.Repository.IRepository;
using UrlShortner.API.Repository;
using UrlShortner.API.Services;
using UrlShortner.API.Services.IServices;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlShorteningService,UrlShorteningService>();

// Add CORS services
builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Add the React app's origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Host.UseSerilog();


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();


var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

// Ensure the database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Apply any pending migrations and create the database if not exists
    dbContext.Database.Migrate();
}


app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
