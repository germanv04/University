// 1. Using de entity framewark
using Microsoft.EntityFrameworkCore;
using UniversityWebAPI.DataAccess;
using UniversityWebAPI.Services;
using UniversityWebAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 2. coneccion con sql server
const string connectionName = "UniversityBD";
var connection = builder.Configuration.GetConnectionString(connectionName);

// 3. add context
builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(connection));


// 7. TOD:  Add Services of JWT Autentication 
//builder.Services.AddJwtTokenServices(builder.Configuration);


// Add services to the container.
builder.Services.AddControllers();

// 4. Add services Custom services
builder.Services.AddScoped<IStudentServices, StudentServices>();
//TODO: Add the rest of services


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8. TODO: configurar swagger para encargarse de la autorización de jwt
builder.Services.AddSwaggerGen();

//Nota: viene por defecto asi: "builder.Services.AddSwaggerGen();"

//5. ADD CORS POLITY
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(name: "NameCors" ,builder =>
        {
            builder.AllowAnyOrigin(); //acepte cualquier aplicacion 
            builder.AllowAnyMethod(); //acepte cualquier metodo: Get, Post, Put, etc
            builder.AllowAnyHeader(); //acepte cualquier cabecera
        });
    }
);


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

// 6. Indicarle a la aplicaacion, que haga uso de Cors
app.UseCors("NameCors");

app.Run();
