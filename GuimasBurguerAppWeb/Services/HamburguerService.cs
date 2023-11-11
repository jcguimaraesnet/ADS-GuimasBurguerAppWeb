using GuimasBurguerAppWeb.Models;

namespace GuimasBurguerAppWeb.Services;

public class HamburguerService : IHamburguerService
{
    public HamburguerService()
        => CarregarListaInicial();

    private IList<Hamburguer> _hamburguers;

    private void CarregarListaInicial()
    {
        _hamburguers = new List<Hamburguer>()
        {
            new Hamburguer
            {
                HamburguerId = 1,
                Nome = "Beef Burguer",
                Descricao = "Saboreie nossa suculenta obra-prima: o hambúrguer de carne bovina, uma explosão de sabor em cada mordida!",
                ImagemUri = "/images/beef-burger.jpg",
                Preco = 19.00,
                EntregaExpressa = true,
                DataCadastro = DateTime.Now
            },
            new Hamburguer
            {
                HamburguerId = 2,
                Nome = "Canoe Burger",
                Descricao = "Nosso hambúrguer suculento com batatas canoa crocantes - a combinação perfeita para saciar sua fome!",
                ImagemUri = "/images/beef-burger-canoe-potatoes.jpg",
                Preco = 29.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
            new Hamburguer
            {
                HamburguerId = 3,
                Nome = "Pepper Burger",
                Descricao = "Experimente o sabor picante e irresistível do nosso hambúrguer de pimentão. Uma explosão de sabores em cada mordida!",
                ImagemUri = "/images/beef-burger-peppers.jpg",
                Preco = 39.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
            new Hamburguer
            {
                HamburguerId = 4,
                Nome = "Chickpea Burger",
                Descricao = "Delicie-se com nosso hambúrguer de grão de bico - uma opção saudável e saborosa para os amantes de hambúrguer!",
                ImagemUri = "/images/chickpea-burger.jpg",
                Preco = 159.00,
                EntregaExpressa = false,
                DataCadastro = DateTime.Now
            },
        };
    }

    public IList<Hamburguer> ObterTodos()
        => _hamburguers;

    public Hamburguer Obter(int id) 
        => ObterTodos().SingleOrDefault(item => item.HamburguerId == id);

    public void Incluir(Hamburguer hamburguer)
    {
        var proximoId = _hamburguers.Max(item => item.HamburguerId) + 1;
        hamburguer.HamburguerId = proximoId;
        _hamburguers.Add(hamburguer);
    }

    public void Alterar(Hamburguer hamburguer)
    {
        var hamburguerEncontrado = _hamburguers.SingleOrDefault(item => item.HamburguerId == hamburguer.HamburguerId);
        hamburguerEncontrado.Nome = hamburguer.Nome;
        hamburguerEncontrado.Descricao = hamburguer.Descricao;
        hamburguerEncontrado.Preco = hamburguer.Preco;
        hamburguerEncontrado.EntregaExpressa = hamburguer.EntregaExpressa;
        hamburguerEncontrado.DataCadastro = hamburguer.DataCadastro;
        hamburguerEncontrado.ImagemUri = hamburguer.ImagemUri;
    }

    public void Excluir(int id)
    {
        var hamburguerEncontrado = Obter(id);
        _hamburguers.Remove(hamburguerEncontrado);
    }
}
