using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new HamburgueriaDbContext();
            context.Categoria.AddRange(ObterCargaInicialCategoria());
            context.SaveChanges();
        }

        private IList<Categoria> ObterCargaInicialCategoria()
        {
            return new List<Categoria>()
            {
                new Categoria() { Descricao = "Sem Glúten" },
                new Categoria() { Descricao = "Apimentado" },
                new Categoria() { Descricao = "Zero Lactose" },
                new Categoria() { Descricao = "Vegano" },
            };
        }
    }
}
