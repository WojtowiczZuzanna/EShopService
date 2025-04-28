using EShop.Domain.Seeders;
using EShop.Application;
using EShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDb"), ServiceLifetime.Transient); 

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ICreditCardService, CreditCardService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEShopSeeder, EShopSeeder>();
builder.Services.AddTransient<EShopSeeder>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IEShopSeeder>();
await seeder.Seed();


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



public partial class Program { }

