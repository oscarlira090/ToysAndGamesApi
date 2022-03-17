using Microsoft.EntityFrameworkCore;
using StockManagementPersistence;
using ToysAndGamesBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//SQL Server Connection

builder.Services.AddDbContext<ToysAndGamesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Services

builder.Services.AddTransient<IProductBusiness, ProductBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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