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
    public class DeleteModel : PageModel
    {
        private readonly teste.Data.MomentoDbContext _context;

        public DeleteModel(teste.Data.MomentoDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Momento = await _context.Momento.FindAsync(id);

            if (Momento != null)
            {
                _context.Momento.Remove(Momento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
