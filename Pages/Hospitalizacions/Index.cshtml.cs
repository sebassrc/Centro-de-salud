using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Hospitalizacions
{
    [Authorize]
    public class IndexModel : PageModel
    {

        private readonly ConsultaContext _context;

        public IndexModel(ConsultaContext context)
        {
            _context = context;
        }

        public IList<Hospitalizacion> Hospitalizacions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hospitalizacions != null)
            {
                Hospitalizacions = await _context.Hospitalizacions.ToListAsync();
            }
        }
    }
}
