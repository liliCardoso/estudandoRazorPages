using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Pages.MomentoCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly teste.Data.MomentoDbContext _context;

        public DetailsModel(teste.Data.MomentoDbContext context)
        {
            _context = context;
        }

        public Momento Momento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Momento = await _context.Momento.FirstOrDefaultAsync(m => m.IdMomento == id);

            if (Momento == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
