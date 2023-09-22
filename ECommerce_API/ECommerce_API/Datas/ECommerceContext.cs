using Microsoft.EntityFrameworkCore;
using ECommerce_API.Models;

namespace ECommerce_API.Datas
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> opts) : base(opts) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // FK 1:1 {
                // FK 1 Estoque 1 Endereco
                builder.Entity<Endereco>()
                    .HasOne(end => end.Estoque)
                    .WithOne(stock => stock.Endereço_Estoque)
                    // Comando para deletar o endereco caso o estoque seja deletado
                    .OnDelete(DeleteBehavior.Restrict);
            // }
            // FK 1:N {
                // FK 1 Cliente N Avaliações
                builder.Entity<Avaliacao>()
                    .HasOne(rate => rate.Cliente)
                    .WithMany(client => client.Avaliacoes_Client)
                    .HasForeignKey(rate => rate.ClienteId);
            
                // FK 1 Usuario N Compras
                builder.Entity<Compra>()
                    .HasOne(buy => buy.Usuario_Compra)
                    .WithMany(user => user.Compras_User)
                    .HasForeignKey(buy => buy.UsuarioId);

                // FK 1 Produto N Avaliações
                builder.Entity<Avaliacao>()
                    .HasOne(rate => rate.Produto)
                    .WithMany(prod => prod.Avalicoes_Prod)
                    .HasForeignKey(rate => rate.ProdutoId);

                // FK 1 Produto N Imgs
                builder.Entity<ImgProd>()
                    .HasOne(img => img.Produto_Img)
                    .WithMany(prod => prod.Imgs_Prod)
                    .HasForeignKey(img => img.ProdutoId);

                // FK 1 Estoque N Produtos
                builder.Entity<Produto>()
                    .HasOne(prod => prod.Estoque_Prod)
                    .WithMany(stock => stock.Produtos_Estoque)
                    .HasForeignKey(prod => prod.EstoqueId);

                // FK 1 Estoque N Fornecedores
                builder.Entity<Fornecedor>()
                    .HasOne(forn => forn.Estoque)
                    .WithMany(stock => stock.Fornecedores_Estoque)
                    .HasForeignKey(forn => forn.EstoqueId);

                // FK 1 Categoria N Produtos
                builder.Entity<Produto>()
                    .HasOne(prod => prod.Categoria)
                    .WithMany(cat => cat.Produtos_Cat)
                    .HasForeignKey(prod => prod.CategoriaId)
                    // Comando para deletar os produtos caso a categoria seja deletada
                    .OnDelete(DeleteBehavior.Restrict);

                // FK 1 Fornecedor N Produtos
                builder.Entity<Produto>()
                    .HasOne(prod => prod.Fornecedor)
                    .WithMany(forn => forn.Produtos_Fornecedor)
                    .HasForeignKey(prod => prod.FornecedorId)
                    // Comando para deletar os produtos caso o fornecedor seja deletado
                    .OnDelete(DeleteBehavior.Restrict);

                // FK 1 Histórico N Compras
                builder.Entity<Compra>()
                    .HasOne(buy => buy.Historico_Compra)
                    .WithMany(his => his.Compras_Historico)
                    .HasForeignKey(buy => buy.HistoricoId)
                    // Comando para deletar as compras caso o histórico seja deletado
                    .OnDelete(DeleteBehavior.Restrict);

                // FK 1 Cliente N Compra
                builder.Entity<Compra>()
                    .HasOne(compra => compra.Cliente_Compra)
                    .WithMany(client => client.Compras_Client)
                    .HasForeignKey(compra => compra.ClienteId)
                    // Comando para deletar as compras caso o cliente seja deletado
                    .OnDelete(DeleteBehavior.Restrict);
            // }
            // FK N:N {
                // FK N Compras N Produtos {
                builder.Entity<ProdComp>()
                    .HasKey(nn => new
                    {
                        nn.ProdutoId,
                        nn.CompraId
                    });

                // FK 1 ProComp N Produtos
                builder.Entity<ProdComp>()
                    .HasOne(nn => nn.Produto)
                    .WithMany(prod => prod.Compras_Prod)
                    .HasForeignKey(nn => nn.ProdutoId);

                // FK 1 ProdComp N Compras
                builder.Entity<ProdComp>()
                    .HasOne(nn => nn.Compra)
                    .WithMany(buy => buy.Produtos_Compra)
                    .HasForeignKey(nn => nn.CompraId);
                // }

                // FK N Históricos N Produtos {
                builder.Entity<HistoricoProd>()
                        .HasKey(nn => new
                        {
                            nn.HistoricoId,
                            nn.ProdutoId
                        });

                // FK 1 HistoricoProd N Historicos
                builder.Entity<HistoricoProd>()
                    .HasOne(nn => nn.Historico)
                    .WithMany(his => his.Produtos_Historico)
                    .HasForeignKey(nn => nn.HistoricoId);

                // FK 1 HistoricoProd N Produtos
                builder.Entity<HistoricoProd>()
                    .HasOne(nn => nn.Produto)
                    .WithMany(prod => prod.Historicos_Prod)
                    .HasForeignKey(nn => nn.ProdutoId);
                // }
            // }
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ImgProd> ImgProds { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<HistoricoProd> HistoricosProds { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProdComp> ProdutosCompras { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
