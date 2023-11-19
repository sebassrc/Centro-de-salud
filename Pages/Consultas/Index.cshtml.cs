
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CiudadanosSanos.Data; 
using CiudadanosSanos.Models;

namespace CiudadanosSanos.Pages.Consultas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ConsultaContext _context;

        public IndexModel(ConsultaContext context)
        {   
            _context = context;
        }
        public IList<Consulta> Consultas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Consultas != null)
            {
                Consultas = await _context.Consultas.ToListAsync();
            }
        }
    }
}
