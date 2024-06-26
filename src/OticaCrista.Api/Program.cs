using Microsoft.EntityFrameworkCore;
using OticaCrista.Application.UseCases.Brand;
using OticaCrista.Application.UseCases.Client;
using OticaCrista.Application.UseCases.Product;
using OticaCrista.Infra.DataBase;
using OticaCrista.Infra.DataBase.Repository.Brand;
using OticaCrista.Infra.DataBase.Repository.Client;
using OticaCrista.Infra.DataBase.Repository.Payment;
using OticaCrista.Infra.DataBase.Repository.Product;
using OticaCrista.Infra.DataBase.Repository.Sale;
using OticaCrista.Infra.DataBase.Repository.Service;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(LogEventLevel.Debug)
    .WriteTo.File("logs/log.txt",
        LogEventLevel.Warning,
        rollingInterval: RollingInterval.Day));

// CreateBrandAsync services to the container.

builder.Services.AddDateOnlyTimeOnlyStringConverters();

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContextFactory<OticaCristaContext>(o 
    => o.UseMySQL(builder.Configuration.GetConnectionString("MysqlConnection")));
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddCors(options =>
            options.AddPolicy("oticacrista", builder =>
            {
                builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            }));


//Dependecy Service

// ->Brand
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<CreateBrandUseCase>();
builder.Services.AddScoped<GetAllBrandsPaginadedUseCase>();
builder.Services.AddScoped<GetBrandByIdUseCase>();
builder.Services.AddScoped<UpdateBrandUseCase>();
builder.Services.AddScoped<DeleteBrandUseCase>();

// -> Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<GetAllProductsPagedUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();

// -> Service
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

// -> Client
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<CreateClientUseCase>();
builder.Services.AddScoped<GetClientByIdUseCase>();
builder.Services.AddScoped<GetAllClientsPaginadedUseCase>();
builder.Services.AddScoped<UpdateClientUseCase>();
builder.Services.AddScoped<DeleteClientUseCase>();

// -> Payment
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

// -> Sale
builder.Services.AddScoped<ISaleRepository, SaleRepository>();


var app = builder.Build();

// Configure the HTTP input pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("oticacrista");
app.MapControllers();

Log.Information($"Rodando API em {DateTime.Now}");
app.Run();
