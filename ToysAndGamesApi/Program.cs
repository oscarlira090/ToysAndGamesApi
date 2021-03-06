using Microsoft.EntityFrameworkCore;
using StockManagementPersistence;
using ToysAndGamesApi;
using ToysAndGamesBusiness;
using ToysAndGamesBusiness.Services;
using ToysAndGamesEntities;
using ToysAndGamesServices.Contracts;
using ToysAndGamesUtil;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

//SQL Server Connection

builder.Services.AddDbContext<ToysAndGamesDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction :sqlOptions =>
    {

        sqlOptions.EnableRetryOnFailure(
            maxRetryCount:10,
            maxRetryDelay:TimeSpan.FromSeconds(5),
            errorNumbersToAdd:null);
    })); ;

//Setting
builder.Services.Configure<Settings>(builder.Configuration.GetSection(Settings.SETTING_NAME));

//Services
//TODO: Use Scopeed instead of Transient
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ILocalStorage, LocalStorage>();
builder.Services.AddScoped<IProductImagesService, ProductImagesService>();



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
