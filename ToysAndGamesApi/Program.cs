using Microsoft.EntityFrameworkCore;
using StockManagementPersistence;
using ToysAndGamesApi;
using ToysAndGamesBusiness;
using ToysAndGamesEntities;
using ToysAndGamesUtil;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

//SQL Server Connection

builder.Services.AddDbContext<ToysAndGamesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Setting
builder.Services.Configure<Settings>(builder.Configuration.GetSection(Settings.SETTING_NAME));

//Services
//TODO: Use Scopeed instead of Transient
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
builder.Services.AddScoped<ILocalStorage, LocalStorage>();
builder.Services.AddScoped<IProductImages, ProductImages>();



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


// global cors policy

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    //.AllowCredentials()
    ); // allow credentials


app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
