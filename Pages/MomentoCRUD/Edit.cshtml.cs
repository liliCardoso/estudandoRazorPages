using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using teste.Data;
using teste.Models;

namespace teste.Pages.MomentoCRUD
{
    public class EditModel : PageModel
    {
        private readonly teste.Data.MomentoDbContext _context;

        public EditModel(teste.Data.MomentoDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Momento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MomentoExists(Momento.IdMomento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MomentoExists(int id)
        {
            return _context.Momento.Any(e => e.IdMomento == id);
        }
    }
}
