using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class DetailsModel : PageModel
    {
        private IHamburguerService _service;
        public string DescricaoMarca { get; set; }

        public DetailsModel(IHamburguerService service) 
        {
            _service = service;
        }

        public Hamburguer Hamburguer { get; private set; }

        public IActionResult OnGet(int id)
        {
            Hamburguer = _service.Obter(id);
            if (Hamburguer.MarcaId is not null)
            {
                DescricaoMarca = _service.ObterMarca(Hamburguer.MarcaId.Value).Descricao;
            }

            if (Hamburguer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
