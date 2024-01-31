using Microsoft.EntityFrameworkCore;
using RepositoryPatternDemo.Database;
using RepositoryPatternDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Hämta connection string
string? connectionString = builder.Configuration.GetConnectionString("DbConnection");

// 2. Lägga till databasen i DI container som en service
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// 3 olika sätt att lägga till i DI-container
// 1. Transient
//      - Livstiden är per användning
// 2. Scoped
//      - Livstiden är per REQUEST
// 3. Singleton
//      - Det finns endast 1, lite som static
//      - Livstiden är appens liv

builder.Services.AddScoped<IProductsRepository, MegaProductsRepository>();

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

app.Run();
