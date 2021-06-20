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
    public class DeleteModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public DeleteModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembreEquipe MembreEquipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembreEquipe = await _context.MembreEquipes.FirstOrDefaultAsync(m => m.ID == id);

            if (MembreEquipe == null)
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

            MembreEquipe = await _context.MembreEquipes.FindAsync(id);

            if (MembreEquipe != null)
            {
                _context.MembreEquipes.Remove(MembreEquipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
