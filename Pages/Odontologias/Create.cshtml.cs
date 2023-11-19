using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiudadanosSanos.Pages.Odontologias
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
        public Odontologia Odontologia { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Odontologias == null || Odontologia == null)
            {
                return Page();
            }

            _context.Odontologias.Add(Odontologia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
