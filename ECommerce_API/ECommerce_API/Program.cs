using ECommerce_API.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services with paht request to the API.
builder.Services.AddControllers().AddNewtonsoftJson();

// Add Automapper and Services to the API
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add DbContext to the API
var connectString = builder.Configuration.GetConnectionString("ECommerce_Con");

builder.Services.AddDbContext<ECommerceContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(connectString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ECommerce_API",
        Version = "1.01",
        Contact = new OpenApiContact
        {
            Name = "Hugo André Lucena",
            Email = "hugo.andre.lucena@outlook.com",
            Url = new Uri("https://www.linkedin.com/in/hugo-andré-lucena-968a42207/")
        }
    });

    var xmlFile = "ECommerce_API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
