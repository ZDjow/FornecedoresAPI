using FornecedoresPM.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FornecedoresDB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexaoFornecedoresDB")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Catálogo de APIs Playmove",
        Version = "v1",

        Contact = new OpenApiContact
        {
            Name = "Playmove",
            Url = new Uri("https://playmove.com.br")
        }

    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
