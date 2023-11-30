using GuimasBurguerAppWeb.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuimasBurguerAppWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarDadosHamburguer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var context = new HamburgueriaDbContext();
            context.Hamburguer.AddRange(ObterCargaInicialHamburguer());
            context.SaveChanges();
        }

        private IList<Hamburguer> ObterCargaInicialHamburguer()
        {
            return new List<Hamburguer>()
            {
                new Hamburguer
                {
                    Nome = "Beef Burguer",
                    Descricao = "Saboreie nossa suculenta obra-prima: o hambúrguer de carne bovina, uma explosão de sabor!",
                    ImagemUri = "/images/beef-burger.jpg",
                    Preco = 19.00,
                    EntregaExpressa = true,
                    DataCadastro = DateTime.Now
                },
                new Hamburguer
                {
                    Nome = "Canoe Burger",
                    Descricao = "Nosso hambúrguer suculento com batatas canoa crocantes - a combinação perfeita!",
                    ImagemUri = "/images/beef-burger-canoe-potatoes.jpg",
                    Preco = 29.00,
                    EntregaExpressa = false,
                    DataCadastro = DateTime.Now
                },
                new Hamburguer
                {
                    Nome = "Pepper Burger",
                    Descricao = "Experimente o sabor picante e irresistível do nosso hambúrguer de pimentão!",
                    ImagemUri = "/images/beef-burger-peppers.jpg",
                    Preco = 39.00,
                    EntregaExpressa = false,
                    DataCadastro = DateTime.Now
                },
                new Hamburguer
                {
                    Nome = "Chickpea Burger",
                    Descricao = "Delicie-se com nosso hambúrguer de grão de bico - uma opção saudável e saborosa!",
                    ImagemUri = "/images/chickpea-burger.jpg",
                    Preco = 159.00,
                    EntregaExpressa = false,
                    DataCadastro = DateTime.Now
                },
            };
        }
    }
}
