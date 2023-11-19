using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CiudadanosSanos.Models;

namespace CiudadanosSanos.Pages.Consultas
{
    public class CreateModel : PageModel
    {
        private readonly ConsultaContext _context;

        public CreateModel(ConsultaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consulta Consulta { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Consultas == null || Consulta == null)
            {
                return Page();
            }

            _context.Consultas.Add(Consulta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
