using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;

namespace CiudadanosSanos.Pages.Consultas
{
    public class EditsModel : PageModel
    {
        private readonly ConsultaContext _context;

        public EditsModel(ConsultaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consulta Consulta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            Consulta = consulta;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Consulta.Id))
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

        private bool CategoryExists(int id)
        {
            return (_context.Consultas?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
