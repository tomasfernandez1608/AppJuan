using Microsoft.EntityFrameworkCore;
using ServerV1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppjuantestV1Context>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));//Se configura nuestro contexto con su cadena de coneccion

var ConfigCORS = "ConfigCORS";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: ConfigCORS, bluider =>
    {
        bluider.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
    
});
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder =>
//        {
//            builder.WithOrigins(" ")
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(ConfigCORS);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
