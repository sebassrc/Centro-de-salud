using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiudadanosSanos.Pages.Urgencias
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
        public Urgencia Urgencia { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Urgencias == null || Urgencia == null)
            {
                return Page();
            }

            _context.Urgencias.Add(Urgencia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
