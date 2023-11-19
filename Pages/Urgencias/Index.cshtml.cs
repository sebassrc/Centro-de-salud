using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Urgencias
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ConsultaContext _context;

        public IndexModel(ConsultaContext context)
        {
            _context = context;
        }
        public IList<Urgencia> Urgencias { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Urgencias != null)
            {
                Urgencias = await _context.Urgencias.ToListAsync();
            }
        }
    }
}