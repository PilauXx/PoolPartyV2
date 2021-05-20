using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Data;
using PoolPartyV2.Models;

namespace PoolPartyV2.Pages.Licencies
{
    public class IndexModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public IndexModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Licencie> Licencie { get;set; }

        public async Task OnGetAsync()
        {
            Licencie = await _context.Licensie.ToListAsync();
        }
    }
}
