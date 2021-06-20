using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Data;
using PoolPartyV2.Models;

namespace PoolPartyV2.Pages.MembreDeEquipe
{
    public class EditModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public EditModel(PoolPartyV2.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MembreEquipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembreEquipeExists(MembreEquipe.ID))
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

        private bool MembreEquipeExists(int id)
        {
            return _context.MembreEquipes.Any(e => e.ID == id);
        }
    }
}
