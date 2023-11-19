using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Odontologias
{
    public class EdidiModel : PageModel
    {
        private readonly ConsultaContext _context;

        public EdidiModel(ConsultaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Odontologia Odontologia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Odontologias == null)
            {
                return NotFound();
            }

            var odontologia = await _context.Odontologias.FirstOrDefaultAsync(m => m.Id == id);
            if (odontologia == null)
            {
                return NotFound();
            }
            Odontologia = odontologia;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Odontologia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(Odontologia.Id))
                {
                    return Page();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProviderExists(int id)
        {
            return (_context.Odontologias?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}