using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace GuimasBurguerAppWeb.Pages
{
    public class EditModel : PageModel
    {
        public SelectList MarcaOptionItems { get; set; }
        private IHamburguerService _service;
        private IToastNotification _toastNotification;

        public EditModel(IHamburguerService service,
                         IToastNotification toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }

        [BindProperty]
        public Hamburguer Hamburguer { get; set; }

        public IActionResult OnGet(int id)
        {
            Hamburguer = _service.Obter(id);

            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));

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

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            //exclusão
            _service.Excluir(Hamburguer.HamburguerId);

            _toastNotification.AddSuccessToastMessage("Operação realizada com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}
