using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Odontologias
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ConsultaContext _context;

        public IndexModel(ConsultaContext context)
        {
            _context = context;
        }
        public IList<Odontologia> Odontologias { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Odontologias != null)
            {
                Odontologias = await _context.Odontologias.ToListAsync();
            }
        }
    }
}