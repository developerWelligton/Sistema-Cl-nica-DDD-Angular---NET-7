using Domain.Interfaces.Generics;
using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IClientes;
using Domain.Interfaces.IConsulta;
using Domain.Interfaces.IConsulta_Exame;
using Domain.Interfaces.IEspecie;
using Domain.Interfaces.IExame;
using Domain.Interfaces.ISecretarias;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Domain.Interfaces.IVeterinario;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();
var app = builder.Build();


//INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceAnimal, RepositorioAnimal>();
builder.Services.AddSingleton<InterfaceClientes, RepositorioClientes>();
builder.Services.AddSingleton<InterfaceConsulta, RepositorioConsulta>();
builder.Services.AddSingleton<InterfaceConsultaExame, RepositorioConsultaExame>();
builder.Services.AddSingleton<InterfaceEspecie, RepositorioEspecie>();
builder.Services.AddSingleton<InterfaceExame, RepositorioExame>();
builder.Services.AddSingleton<InterfaceSecretarias, RepositorioSecretarias>();
builder.Services.AddSingleton<InterfaceVeterinario, RepositorioVeterinario>();
builder.Services.AddSingleton<InterfaceUsuarioSistemaClinica, RepositorioUsuarioSistemaClinica>();


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
