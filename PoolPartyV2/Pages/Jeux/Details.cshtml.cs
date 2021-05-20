using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Data;
using PoolPartyV2.Models;

namespace PoolPartyV2.Pages.Jeux
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public DetailsModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Jeu Jeu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Jeu = await _context.Jeu.FirstOrDefaultAsync(m => m.ID == id);

            if (Jeu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
