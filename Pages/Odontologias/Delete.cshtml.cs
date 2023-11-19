using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Odontologias
{
    public class DeleteModel : PageModel
    {
        public readonly ConsultaContext _context;

        public DeleteModel(ConsultaContext context)
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
            else
            {
                Odontologia = odontologia;
            }
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Odontologias == null)
            {
                return NotFound();
            }
            var odontologia = await _context.Odontologias.FindAsync(id);

            if (odontologia != null)
            {
                Odontologia = odontologia;
                _context.Odontologias.Remove(odontologia);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }

    }   }
