using ModuloAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Passa a conexão para o DBContext
// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexaoPadrao")
        )
    );

//Outras formas: 
// builder.Services.AddDbContext<AgendaContext>(
//     options => {
//         options.UseSqlServer(
//             builder.Configuration.GetConnectionString("ConexaoPadrao")
//         );
//     }
// );

// builder.Services.AddDbContext<AgendaContext>(delegate(DbContextOptionsBuilder options) {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"));
// });

// builder.Services.AddDbContext<AgendaContext>(options => {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao"));
// });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
