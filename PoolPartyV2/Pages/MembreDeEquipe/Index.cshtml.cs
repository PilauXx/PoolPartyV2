using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Data;
using PoolPartyV2.Models;

namespace PoolPartyV2.Pages.MembreDeEquipe
{
    public class IndexModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;
        public IList<MembreEquipe> MembreEquipe { get; set; }
        private Equipe equipe;
        public int EquipeID { get; set; } 
        public IndexModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EquipeID = (int)id;
            equipe = _context.Equipe.Find(id);

            MembreEquipe = await _context.MembreEquipes.Include(e => e.Equipe).Where(e => e.Equipe.ID.Equals(id))
                .Include(e => e.Licencie).ToListAsync();

            if (MembreEquipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
