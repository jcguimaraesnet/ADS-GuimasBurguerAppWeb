using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuimasBurguerAppWeb.Pages
{
    public class CreateModel : PageModel
    {
        private IHamburguerService _service;

        public CreateModel(IHamburguerService service) 
        {
            _service = service;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //inclusão
            _service.Incluir(Hamburguer);

            return RedirectToPage("/Index");
        }
    }
}
