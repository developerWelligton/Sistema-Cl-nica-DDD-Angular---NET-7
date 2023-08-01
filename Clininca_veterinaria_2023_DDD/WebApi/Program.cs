using Domain.Interfaces.Generics;
using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IClientes;
using Domain.Interfaces.IConsulta;
using Domain.Interfaces.IConsulta_Exame;
using Domain.Interfaces.IEspecie;
using Domain.Interfaces.IExame;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISecretarias;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Domain.Interfaces.IVeterinario;
using Domain.Servicos;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;

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

//INTERFACE DOMINIO
builder.Services.AddSingleton<IAnimalServico, AnimalServico>();
builder.Services.AddSingleton<IClienteServico, ClienteServico>(); 
builder.Services.AddSingleton<IConsultaServico, ConsultaServico>();
builder.Services.AddSingleton<IConsultaExameServico, ConsultaExameServico>(); 
builder.Services.AddSingleton<IEspecieServico, EspecieServico>(); 
builder.Services.AddSingleton<IExameServico, ExameServico>(); 
builder.Services.AddSingleton<ISecretariaServico, SecretariaServico>(); 
builder.Services.AddSingleton<IVeterinarioServico, VeterinarioServico>(); 
builder.Services.AddSingleton<IUsuarioSistemaClinicaServico, UsuarioSistemaClinicaServico>(); 
 



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Teste.Security.Bearer",
            ValidAudience = "Teste.Security.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
        };

        option.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
