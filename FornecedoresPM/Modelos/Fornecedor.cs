using Microsoft.EntityFrameworkCore;

namespace FornecedoresPM.Modelos
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? CNPJ { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataAbertura { get; set; }
        public string? RazaoSocial { get; set; }
        public string? NomeFantasia { get; set; }
    }

    public class FornecedoresDB : DbContext
    {
        public FornecedoresDB(DbContextOptions<FornecedoresDB> options) : base(options) { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
