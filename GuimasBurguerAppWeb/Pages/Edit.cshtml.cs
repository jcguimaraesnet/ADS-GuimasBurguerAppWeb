using GuimasBurguerAppWeb.Models;
using GuimasBurguerAppWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;

namespace GuimasBurguerAppWeb.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        public SelectList MarcaOptionItems { get; set; }
        public SelectList CategoriaOptionItems { get; set; }
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

        [BindProperty]
        public IList<int> CategoriaIds { get; set; }

        public IActionResult OnGet(int id)
        {
            Hamburguer = _service.Obter(id);

            CategoriaIds = Hamburguer.Categorias.Select(item => item.CategoriaId).ToList();

            MarcaOptionItems = new SelectList(_service.ObterTodasMarcas(),
                                                nameof(Marca.MarcaId),
                                                nameof(Marca.Descricao));

            CategoriaOptionItems = new SelectList(_service.ObterTodasCategorias(),
                                    nameof(Categoria.CategoriaId),
                                    nameof(Categoria.Descricao));

            if (Hamburguer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Hamburguer.Categorias = _service.ObterTodasCategorias()
                                            .Where(item => CategoriaIds.Contains(item.CategoriaId))
                                            .ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //altera��o
            _service.Alterar(Hamburguer);

            _toastNotification.AddSuccessToastMessage("Opera��o realizada com sucesso!");

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExclusao()
        {
            //exclus�o
            _service.Excluir(Hamburguer.HamburguerId);

            _toastNotification.AddSuccessToastMessage("Opera��o realizada com sucesso!");

            return RedirectToPage("/Index");
        }
    }
}
