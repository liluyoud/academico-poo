using Academico.Api.Endpoints;
using Academico.Shared.Contexts;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

// adicionei o banco de dados ao builder
builder.Services.AddDbContext<AcademicoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("POOConection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); 
}

app.MapAcademicoEndpoints();

app.Run();

