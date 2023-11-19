using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;

namespace CiudadanosSanos.Pages.Consultas
{
    public class DeleteModel : PageModel
    {
        public readonly ConsultaContext _context;

        public DeleteModel(ConsultaContext context)
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
            else
            {
                Consulta = consulta;
            }
            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Consultas == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta != null)
            {
                Consulta = consulta;
                _context.Consultas.Remove(consulta);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
