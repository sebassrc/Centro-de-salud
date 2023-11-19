using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Hospitalizacions
{
    public class EditsModel : PageModel
    {
        private readonly ConsultaContext _context;

        public EditsModel(ConsultaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hospitalizacion Hospitalizacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hospitalizacions == null)
            {
                return NotFound();
            }

            var paymode = await _context.Hospitalizacions.FirstOrDefaultAsync(m => m.Id == id);
            if (paymode == null)
            {
                return NotFound();
            }
            Hospitalizacion = paymode;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hospitalizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayModeExists(Hospitalizacion.Id))
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

        private bool PayModeExists(int id)
        {
            return (_context.Hospitalizacions?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
