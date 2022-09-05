using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services
    .AddDbContext<StoreDbContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await using var scope = app.Services.CreateAsyncScope();

var service = scope.ServiceProvider;

var loggerFactory = service.GetRequiredService<ILoggerFactory>();
try
{
    var context = service.GetRequiredService<StoreDbContext>();
    await context.Database.MigrateAsync();
    await StoreDbContextSeed.SeedAsync(context, loggerFactory);
}
catch (Exception e)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(e, "An error occurred during migration");
}


app.Run();
