using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using teste.Data;
using teste.Models;

namespace teste.Pages.FotoCRUD
{
    public class ListarModel : PageModel
    {
        private readonly MomentoDbContext _context;

        public IList<Foto> Fotos { get; set; }

        public ListarModel(MomentoDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Fotos = await _context.Fotos.ToListAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ToDo: Persisitir os dados
            var result = await _context.Fotos.FindAsync(id);

            if (result != null)
            {
                _context.Fotos.Remove(result);
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
