using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Data;
using PoolPartyV2.Models;

namespace PoolPartyV2.Pages.Jeux
{
    public class IndexModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public IndexModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Jeu> Jeu { get;set; }

        public async Task OnGetAsync()
        {
            Jeu = await _context.Jeu.ToListAsync();
        }
    }
}
