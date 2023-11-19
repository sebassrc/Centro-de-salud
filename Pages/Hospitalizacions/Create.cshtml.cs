using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiudadanosSanos.Pages.Hospitalizacions
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
        public Hospitalizacion Hospitalizacion { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Hospitalizacions == null || Hospitalizacion == null)
            {
                return Page();
            }

            _context.Hospitalizacions.Add(Hospitalizacion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
