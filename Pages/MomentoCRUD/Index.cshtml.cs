using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.Pages.MomentoCRUD
{
    public class IndexModel : PageModel
    {
        private readonly teste.Data.MomentoDbContext _context;

        public IndexModel(teste.Data.MomentoDbContext context)
        {
            _context = context;
        }

        public IList<Momento> Momento { get;set; }

        public async Task OnGetAsync()
        {
            Momento = await _context.Momento.ToListAsync();
        }
    }
}
