using GuimasBurguerAppWeb.Data;
using GuimasBurguerAppWeb.Models;

namespace GuimasBurguerAppWeb.Services.Data;

public class HamburguerService : IHamburguerService
{
    private HamburgueriaDbContext _context;

    public HamburguerService(HamburgueriaDbContext context)
    {
        _context = context;
    }

    public void Alterar(Hamburguer hamburguer)
    {
        var hamburguerEncontrado = Obter(hamburguer.HamburguerId);
        hamburguerEncontrado.Nome = hamburguer.Nome;
        hamburguerEncontrado.Descricao = hamburguer.Descricao;
        hamburguerEncontrado.Preco = hamburguer.Preco;
        hamburguerEncontrado.ImagemUri = hamburguer.ImagemUri;
        hamburguerEncontrado.EntregaExpressa = hamburguer.EntregaExpressa;
        hamburguerEncontrado.DataCadastro = hamburguer.DataCadastro;
        hamburguerEncontrado.MarcaId = hamburguer.MarcaId;

        _context.SaveChanges();
    }

    public void Excluir(int id)
    {
        var hamburguerEncontrado = Obter(id);
        _context.Hamburguer.Remove(hamburguerEncontrado);
        _context.SaveChanges();
    }

    public void Incluir(Hamburguer hamburguer)
    {
        _context.Hamburguer.Add(hamburguer);
        _context.SaveChanges();
    }

    public Hamburguer Obter(int id)
    {
        return _context.Hamburguer.SingleOrDefault(item => item.HamburguerId == id);
    }

    public IList<Hamburguer> ObterTodos()
    {
        return _context.Hamburguer.ToList();
    }

    public IList<Marca> ObterTodasMarcas()
        => _context.Marca.ToList();

    public Marca ObterMarca(int id)
        => _context.Marca.SingleOrDefault(item => item.MarcaId == id);
}
