using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Urgencias
{
    public class DeleteModel : PageModel
    {
        public readonly ConsultaContext _context;

        public DeleteModel(ConsultaContext context)
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
            else
            {
                Urgencia = urgencia;
            }
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Urgencias == null)
            {
                return NotFound();
            }
            var urgencia = await _context.Urgencias.FindAsync(id);

            if (urgencia != null)
            {
                Urgencia = urgencia;
                _context.Urgencias.Remove(urgencia);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

    }   }
