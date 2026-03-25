using ApiProduct.Application.Services.Product;
using ApiProduct.Domain.Repository;
using ApiProduct.Infraestructura.Repositories;
using ApiProduct.Middleware;
using ApiProduct.Shared.AutoMapper.AutoMapper;
using ApiProduct.Shared.Configuration.Connection;
using AutoMapper;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [Services]

#region [AddRegistration]
builder.Services.AddScoped<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

#region [Log]

builder.Services.AddLogging(l =>
{
    l.SetMinimumLevel(LogLevel.Information);
    l.AddNLog("NLog.config");
});

#endregion

#region [Cors]

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

#endregion

#region [Swagger]

builder.Services.AddSwaggerGen(options =>
{
    var groupName = "v1";

    options.SwaggerDoc(groupName, new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = $"API Product {groupName}",
        Version = groupName,
        Description = "API Product",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "API Product",
            Email = string.Empty,
            Url = new System.Uri("https://foo.com/"),
        }
    });
});

#endregion

#region [Jwt]

#endregion

#region [AutoMapper]

//Mapper
var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new MapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
