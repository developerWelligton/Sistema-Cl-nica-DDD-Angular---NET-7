using Domain.Interfaces.Generics;
using Domain.Interfaces.IAnimal;
using Domain.Interfaces.IClientes;
using Domain.Interfaces.IConsulta;
using Domain.Interfaces.IConsulta_Exame; 
using Domain.Interfaces.IExame;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISecretarias;
using Domain.Interfaces.IUsuarioSistemaClinica;
using Domain.Interfaces.IVeterinario;
using Domain.Servicos;
using Entities.Entidades;
using Entities.Notificacoes;
using Infra.Configuracao;
using Infra.Repositorio;
using Infra.Repositorio.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Token;
/**/
using Microsoft.OpenApi.Models;
using System.Reflection;
using Domain.Interfaces.ISegmento;
using Domain.Interfaces.IFamilia;
using Domain.Interfaces.IClasse;
using Domain.Interfaces.IMercadoria;
using Domain.Interfaces.IUnspscCode;
using Domain.Interfaces.IServico;
using Domain.Interfaces.IEstoque;
using Domain.Interfaces.ICompra;
using Domain.Interfaces.IiTemCompraProduto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CLÍNICA PETZ API",
        Description = "API DAS FUNCIONALIDADES DO WEBAPP",   
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//TO DEVELOPER
var devEnvironmentDataBase = builder.Configuration.GetConnectionString("DefaultConnection");

//TO DEPLOY IN AZURE
var prodEnvironmentDataBase = builder.Configuration.GetConnectionString("ProdConnection");

//PRODUTION ON HERE
builder.Services.AddDbContext<ContextBase>(options =>
    options.UseSqlServer(devEnvironmentDataBase));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ContextBase>();
 
 

//INTERFACE E REPOSITORIO
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceAnimal, RepositorioAnimal>();
builder.Services.AddSingleton<InterfaceClientes, RepositorioClientes>();
builder.Services.AddSingleton<InterfaceConsulta, RepositorioConsulta>();
builder.Services.AddSingleton<InterfaceConsultaExame, RepositorioConsultaExame>(); 
builder.Services.AddSingleton<InterfaceExame, RepositorioExame>();
builder.Services.AddSingleton<InterfaceSecretarias, RepositorioSecretarias>();
builder.Services.AddSingleton<InterfaceVeterinario, RepositorioVeterinario>(); 
builder.Services.AddSingleton<InterfaceUsuarioSistemaClinica, RepositorioUsuarioSistemaClinica>(); 
//novos interfcaces e repositorios
builder.Services.AddSingleton<InterfaceSegmento, RepositorioSegmento>();
builder.Services.AddSingleton<InterfaceFamilia, RepositorioFamilia>();
builder.Services.AddSingleton<InterfaceClasse, RepositorioClasses>();
builder.Services.AddSingleton<InterfaceMercadoria, RepositorioMercadoria>();
//add code Unspsc
builder.Services.AddSingleton<InterfaceUnspscCode, RepositorioUnspscCode>();
//add produtos
builder.Services.AddSingleton<InterfaceProduto, RepositorioProduto>();
//add servico
builder.Services.AddSingleton<InterfaceServico, RepositorioServico>();
//add estoque
builder.Services.AddSingleton<InterfaceEstoque, RepositorioEstoque>();
//add produtoEstoque
builder.Services.AddSingleton<InterfaceItemProdutoEstoque, RepositorioItemProdutosEstoques>();
//add fornecedor
builder.Services.AddSingleton<InterfaceFornecedor, RepositorioFornecedores>();
//add compra
builder.Services.AddSingleton<InterfaceCompra, RepositorioCompra>();
//add itemCompraProduto
builder.Services.AddSingleton<InterfaceItemCompraProduto, RepositorioItemComprasProdutos>();





//INTERFACE DOMINIO
builder.Services.AddSingleton<IAnimalServico, AnimalServico>();
builder.Services.AddSingleton<IClienteServico, ClienteServico>(); 
builder.Services.AddSingleton<IConsultaServico, ConsultaServico>();
builder.Services.AddSingleton<IConsultaExameServico, ConsultaExameServico>();  
builder.Services.AddSingleton<IExameServico, ExameServico>(); 
builder.Services.AddSingleton<ISecretariaServico, SecretariaServico>(); 
builder.Services.AddSingleton<IVeterinarioServico, VeterinarioServico>(); 
builder.Services.AddSingleton<IUsuarioSistemaClinicaServico, UsuarioSistemaClinicaServico>(); 
//novos dominios estoque,venda,compra,produto,serviço,unspsc
builder.Services.AddSingleton<ISegmentoServico, SegmentoServico>();
builder.Services.AddSingleton<IFamiliaServico, FamiliaServico>();
builder.Services.AddSingleton<IClasseServico, ClasseServico>();
builder.Services.AddSingleton<IMercadoriaServico, MercadoriaServico>(); 
//add code Unspsc
builder.Services.AddSingleton<IUnspscCodeServico, UnspscCodeServico>();
//add produtos
builder.Services.AddSingleton<IProdutoServico, ProdutoServico>();
//add servico
builder.Services.AddSingleton<IServicoServico, ServicoServico>();
//add estoque
builder.Services.AddSingleton<IEstoqueServico,EstoqueServico>();
//add produtoEstoque
builder.Services.AddSingleton<IitemProdutoEstoqueServico, ItemProdutoEstoqueServico>();
//add fornecedor
builder.Services.AddSingleton<IFornecedorServico, FornecedorServico>();
//add fornecedor
builder.Services.AddSingleton<ICompraServico, CompraServico>();
//add itemCompraProduto
builder.Services.AddSingleton<IitemProdutoCompraServico, ItemProdutoCompraServico>();



builder.Services.AddTransient<ValidacaoServico>();
  

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

//CORS
builder.Services.AddCors();


    var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//CORS      

var devProduction = "https://app-client-clinica-petz.azurewebsites.net";
var frontendOrigin = "http://localhost:4200";
var redirectOrigin = "https://localhost:7131";

app.UseCors(policy => policy
    .WithOrigins(frontendOrigin, redirectOrigin, devProduction)
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
