using Microsoft.EntityFrameworkCore;
using apiGymnasio.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BdgymnasioContext>(options =>
{ options.UseSqlServer(builder.Configuration.GetConnectionString("cnx")); }
);

builder.Services.AddCors(opciones => {
    opciones.AddPolicy("politicaGral", app => {
        app.AllowAnyOrigin();
        app.AllowAnyHeader();
        app.AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("politicaGral");

app.UseAuthorization();

app.MapControllers();

app.Run();