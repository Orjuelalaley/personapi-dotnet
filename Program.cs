using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<PersonaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PersonaDbContext")));
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddScoped<IEstudioRepository, EstudioRepository>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laboratiorio 1 Arquitectura de software");
    c.RoutePrefix = "swagger"; // To serve the Swagger UI at a relative path
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
