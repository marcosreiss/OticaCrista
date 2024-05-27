using Microsoft.EntityFrameworkCore;
using OticaCrista.Application.UseCases.Product;
using OticaCrista.Application.UseCases.Product.Create;
using OticaCrista.Application.UseCases.Product.Get;
using OticaCrista.Application.UseCases.Product.Update;
using OticaCrista.Infra.DataBase;
using OticaCrista.Infra.DataBase.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<OticaCristaContext>(o => o.UseMySQL(builder.Configuration.GetConnectionString("MysqlConnection")));
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

//Dependecy Service
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<CreateBrandUseCase>();
builder.Services.AddScoped<GetBrandUseCase>();
builder.Services.AddScoped<UpdateBrandUseCase>();

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
