using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    #pragma warning disable CS1591
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options) {
        
        }

        public DbSet<UsuarioSistemaClinica> UsuarioSistemaClinicas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; } 
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta_Exame> Consulta_Exames { get; set; }

        //MODULO PAGAMENTO,VENDA,COMPRA,SERVIÇO
        public DbSet<UsuarioSistemaClinica> Usuarios { get; set; }
        public DbSet<Mercadoria> Mercadorias { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<UnspscCode> UnspscCodes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<PedidoServicos> PedidoServicos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaServicoPagamento> VendaServicoPagamentos { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<ItemProdutoEstoque> ItensProdutoEstoques { get; set; } 
        public DbSet<ItemProdutoCompra> ItensProdutoCompras { get; set; }
        public DbSet<ItemProdutoVenda> ItensPordutoVendas { get; set; } 
        public DbSet<PedidoServicosRelacao> PedidoServicosRelacoes { get; set; }


        //public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //PRODUTION OFF 
                optionsBuilder.UseSqlServer(ObterStringConexaoProductionAzure());
                base.OnConfiguring(optionsBuilder);
            }
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            builder.Entity<Consulta_Exame>()
                .HasKey(c => new { c.ID_Consulta, c.ID_Exame });

            // Aqui é onde você configura a precisão e a escala para a propriedade 'Custo'
            builder.Entity<Exame>()
                .Property(e => e.Custo)
            .HasPrecision(8, 2);

            builder.Entity<Consulta>()
                .HasOne(c => c.Veterinario)
                .WithMany()
                .HasForeignKey(c => c.ID_Veterinario)
                .OnDelete(DeleteBehavior.NoAction); // Modificar para NoAction

            builder.Entity<Consulta>()
                .HasOne(c => c.Animal)
                .WithMany()
                .HasForeignKey(c => c.ID_Animal)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Cliente>()
         .HasMany(c => c.Exames)
         .WithOne(e => e.Cliente)
         .HasForeignKey(e => e.ClienteId)
         .OnDelete(DeleteBehavior.Cascade);  // Ou DeleteBehavior.Restrict, dependendo de suas necessidades

            //cliente ter varios animais
            builder.Entity<Cliente>()
             .HasMany(c => c.Animais)  // Supondo que 'Animais' seja o nome da ICollection em 'Cliente'
             .WithOne(a => a.Cliente)
             .HasForeignKey(a => a.ID_Cliente)
             .OnDelete(DeleteBehavior.Cascade);  // Deletando o cliente deletará todos os seus animais

            //cadastrar consulta com UsuarioId
            builder.Entity<Consulta>()
            .HasOne(c => c.UsuarioSistemaClinica)
            .WithMany() // or .WithMany(u => u.Consultas) if UsuarioSistemaClinica has a list of Consultas
            .HasForeignKey(c => c.ID_Usuario)
            .OnDelete(DeleteBehavior.NoAction);  // Specify no action on delete



            // Configurar a entidade como keyless  
            builder.Entity<ItemProdutoVenda>().HasNoKey();
            builder.Entity<ItemProdutoCompra>().HasNoKey();



            // Configura o relacionamento entre Compra e UsuarioSistemaClinica
            builder.Entity<Compra>()
                .HasOne(p => p.Usuario)  // Indica que uma Compra tem um Usuario
                .WithMany()              // Indica que um Usuario pode ter várias Compras
                .HasForeignKey(p => p.ID_Usuario)  // Define a chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);  // Define o comportamento na exclusão para "Restrict"

            // Configura o relacionamento entre Compra e Fornecedor
            builder.Entity<Compra>()
                .HasOne(p => p.Fornecedor)  // Indica que uma Compra tem um Fornecedor
                .WithMany()                 // Indica que um Fornecedor pode ter várias Compras
                .HasForeignKey(p => p.IdFornecedor)  // Define a chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);  // Define o comportamento na exclusão para "Restrict"

            //
            builder.Entity<UnspscCode>()
                .HasOne(p => p.Familia)
                .WithMany()
                .HasForeignKey(p => p.IdFamilia)
                .OnDelete(DeleteBehavior.NoAction);  // ou DeleteBehavior.Restrict

            builder.Entity<UnspscCode>()
                .HasOne(p => p.Mercadoria)
                .WithMany()
                .HasForeignKey(p => p.IdMercadoria)
                .OnDelete(DeleteBehavior.NoAction);  // ou DeleteBehavior.Restrict

            builder.Entity<UnspscCode>()
                .HasOne(p => p.Classe)
                .WithMany()
                .HasForeignKey(p => p.IdClasse)
                .OnDelete(DeleteBehavior.NoAction);  // ou DeleteBehavior.Restrict

            builder.Entity<UnspscCode>()
                .HasOne(p => p.Segmento)
                .WithMany()
                .HasForeignKey(p => p.IdSegmento)
                .OnDelete(DeleteBehavior.NoAction);  // ou DeleteBehavior.Restrict
            //
            builder.Entity<Produto>()
                .HasOne(p => p.UnspscCode)
                .WithMany()
                .HasForeignKey(p => p.IdUnspsc)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction

            builder.Entity<Produto>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.ID_Usuario)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction
            //
            builder.Entity<Servico>()
                .HasOne(s => s.UnspscCode)
                .WithMany()
                .HasForeignKey(s => s.IdUnspsc)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction

            builder.Entity<Servico>()
                .HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.ID_Usuario)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction
            //
            builder.Entity<ItemProdutoEstoque>()
                .HasOne(i => i.Estoque)
                .WithMany()
                .HasForeignKey(i => i.IdEstoque)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction

            builder.Entity<ItemProdutoEstoque>()
                .HasOne(i => i.Produto)
                .WithMany()
                .HasForeignKey(i => i.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction

            builder.Entity<ItemProdutoEstoque>()
                .HasOne(i => i.Usuario)
                .WithMany()
                .HasForeignKey(i => i.ID_Usuario)
                .OnDelete(DeleteBehavior.Restrict);  // ou DeleteBehavior.NoAction
                                                     //
            //serviço
            builder.Entity<VendaServicoPagamento>()
          .HasOne(v => v.Usuario)
          .WithMany()
          .HasForeignKey(v => v.ID_Usuario)
          .IsRequired()
          .OnDelete(DeleteBehavior.Restrict);
 

            builder.Entity<VendaServicoPagamento>()
                .HasOne(v => v.Venda)
                .WithMany()
                .HasForeignKey(v => v.IdVenda)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict); 
        

            builder.Entity<Servico>()
                .HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.ID_Usuario)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Servico>()
                .HasOne(s => s.UnspscCode) // Assume UnspscCode is the entity for UNSPSC_CODE table
                .WithMany()
                .HasForeignKey(s => s.IdUnspsc)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            
            
            // Composite key    

            // Configuração para PedidoServicos e PedidoServicosRelacao
            builder.Entity<PedidoServicosRelacao>()
                .HasKey(ps => new { ps.IdPedidoServicos, ps.IdServico });

            // Sua configuração de ItemProdutoEstoque
            builder.Entity<ItemProdutoEstoque>()
                .HasKey(ip => new { ip.IdProduto, ip.IdEstoque });
            // Composite key for ItemProdutoVenda
            builder.Entity<ItemProdutoVenda>()
                .HasKey(ipv => new { ipv.IdVenda, ipv.IdProduto });
            // Composite key for ItemProdutoCompra
            builder.Entity<ItemProdutoCompra>()
                .HasKey(ipc => new { ipc.IdCompra, ipc.IdProduto });





            //cascata, quando excluir estoque consequentemente exclue o ItemProdutoEstoque
            builder.Entity<ItemProdutoEstoque>()
          .HasOne(p => p.Estoque)
          .WithMany()
          .HasForeignKey(p => p.IdEstoque)
          .OnDelete(DeleteBehavior.Cascade);

            //Você não será capaz de excluir um fornecedor enquanto houver compras associadas a ele. No entanto, você pode excluir uma compra individual sem afetar o fornecedor.
            builder.Entity<Compra>()
            .HasOne(p => p.Fornecedor)
            .WithMany()
            .HasForeignKey(p => p.IdFornecedor)
            .OnDelete(DeleteBehavior.Restrict);


            //itemcompraproduto
            // Relationship between Compra and ItemProdutoCompra
            builder.Entity<Compra>()
                .HasMany(c => c.ItemProdutoCompras)
                .WithOne(ipc => ipc.Compra)
                .HasForeignKey(ipc => ipc.IdCompra);

            // Relationship between Produto and ItemProdutoCompra
            builder.Entity<Produto>()
                .HasMany(p => p.ItemProdutoCompras)
                .WithOne(ipc => ipc.Produto)
                .HasForeignKey(ipc => ipc.IdProduto);


            //itemcompravenda

            // Relationship between Venda and ItemProdutoVenda
            builder.Entity<Venda>()
                .HasMany(v => v.ItemProdutoVendas)
                .WithOne(ipv => ipv.Venda)
                .HasForeignKey(ipv => ipv.IdVenda);

            // Relationship between Produto and ItemProdutoVenda
            builder.Entity<Produto>()
                .HasMany(p => p.ItemProdutoVendas)
                .WithOne(ipv => ipv.Produto)
                .HasForeignKey(ipv => ipv.IdProduto);






            base.OnModelCreating(builder);
        }

        public string ObterStringConexaoProductionAzure()
        {   //base cloud
            return "Data Source=serverdatabasesolution.database.windows.net;Initial Catalog=db-entity-clinica;User ID=welligtoncos;Password=@Well32213115;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";



         }

        public string ObterStringConexaoDeveloperLocal()
        {

            //base local
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_identity_clinica;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

    }
    #pragma warning restore CS1591
}
