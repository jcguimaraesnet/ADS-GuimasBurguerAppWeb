using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class EditModel : PageModel
    {
        private IHamburguerService _service;

        public EditModel(IHamburguerService service)
        {
            _service = service;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        public IActionResult OnGet(int id)
        {
            Hamburguer = _service.Obter(id);

            if (Hamburguer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //alteração
            _service.Alterar(Hamburguer);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            //exclusão
            _service.Excluir(Hamburguer.HamburguerId);

            return RedirectToPage("/Index");
        }
    }
}
