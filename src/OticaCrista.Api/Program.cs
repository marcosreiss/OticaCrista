using Microsoft.EntityFrameworkCore;
using OticaCrista.Application.Mapping;
using OticaCrista.Application.UseCases.Client;
using OticaCrista.Application.UseCases.Product.Create;
using OticaCrista.Application.UseCases.Product.Delete;
using OticaCrista.Application.UseCases.Product.Get;
using OticaCrista.Application.UseCases.Product.Update;
using OticaCrista.Infra.DataBase;
using OticaCrista.Infra.DataBase.Repository.Client;
using OticaCrista.Infra.DataBase.Repository.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDateOnlyTimeOnlyStringConverters();

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<OticaCristaContext>(o => o.UseMySQL(builder.Configuration.GetConnectionString("MysqlConnection")));
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

//Dependecy Service

// ->Brand
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<CreateBrandUseCase>();
builder.Services.AddScoped<GetBrandUseCase>();
builder.Services.AddScoped<UpdateBrandUseCase>();
builder.Services.AddScoped<DeleteBrandUseCase>();

// -> Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<GetProductUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();

// -> Client
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<CreateClientUseCase>();
builder.Services.AddScoped<GetClientUseCase>();
builder.Services.AddScoped<UpdateClientUseCase>();
builder.Services.AddScoped<DeleteClientUseCase>();
builder.Services.AddAutoMapper(typeof(ClientToResponse));


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
