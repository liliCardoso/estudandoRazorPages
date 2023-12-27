using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using teste.Models;

namespace teste.Pages
{
    public class IndexModel : PageModel
    {
        private const int tamanhoPagina = 12;

        private readonly ILogger<IndexModel> _logger;

        private readonly teste.Data.MomentoDbContext _context;

        //public int PaginaAtual { get; set; }
        //public int QuantidadePaginas { get; set; }

        public IndexModel(ILogger<IndexModel> logger, teste.Data.MomentoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Momento> Momentos { get; set; }

        public async Task OnGetAsync()
        {
            Momentos = await _context.Momento.ToListAsync<Momento>();
        }
    }
}

