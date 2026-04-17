using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Helpers;
using Serilog;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>()!;
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddTransient<IDbConnection>(_ => new SqlConnection(appSettings.ConnectionString));
builder.Services.AddTransient<IArticuloDataProvider, ArticuloDataProvider>();
builder.Services.AddTransient<IClienteDataProvider, ClienteDataProvider>();
builder.Services.AddTransient<IVendedorDataProvider, VendedorDataProvider>();
builder.Services.AddTransient<IPedidoDataProvider, PedidoDataProvider>();
builder.Services.AddTransient<IProvinciaDataProvider, ProvinciaDataProvider>();
builder.Services.AddTransient<ILocalidadDataProvider, LocalidadDataProvider>();
builder.Services.AddTransient<ICondicionIvaDataProvider, CondicionIvaDataProvider>();

builder.Services.AddHttpClient();
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Plasticuer API",
        Version = "v1",
        Description = "API Plasticuer"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "Plasticuer API V1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

app.Run();
