using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Hospitalizacions
{
    public class DeleteModel : PageModel
    {
        public readonly ConsultaContext _context;

        public DeleteModel(ConsultaContext context)
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
            else
            {
                Hospitalizacion = paymode;
            }
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hospitalizacions == null)
            {
                return NotFound();
            }
            var paymode = await _context.Hospitalizacions.FindAsync(id);

            if (paymode != null)
            {
                Hospitalizacion = paymode;
                _context.Hospitalizacions.Remove(paymode);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
