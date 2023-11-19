using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Urgencias
{
    public class EdidiModel : PageModel
    {
        private readonly ConsultaContext _context;

        public EdidiModel(ConsultaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Urgencia Urgencia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Urgencias == null)
            {
                return NotFound();
            }

            var urgencia = await _context.Urgencias.FirstOrDefaultAsync(m => m.Id == id);
            if (urgencia == null)
            {
                return NotFound();
            }
            Urgencia = urgencia;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Urgencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderExists(Urgencia.Id))
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
            return (_context.Urgencias?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}