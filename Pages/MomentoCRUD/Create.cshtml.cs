using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using teste.Data;
using teste.Models;

namespace teste.Pages.MomentoCRUD
{
    public class CreateModel : PageModel
    {
        private readonly teste.Data.MomentoDbContext _context;

        public CreateModel(teste.Data.MomentoDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Momento Momento { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Momento.Add(Momento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
