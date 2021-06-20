using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoolPartyV2.Data;
using PoolPartyV2.Models;

namespace PoolPartyV2.Pages.MembreDeEquipe
{
    public class CreateModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        [BindProperty]
        public Equipe Equipe { get; set; }

        [BindProperty]
        public MembreEquipe MembreEquipe { get; set; }

        public CreateModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipe = await _context.Equipe.FindAsync(id);

            ViewData["IDLicencie"] = new SelectList(_context.Licensie, "ID", "Nom");

            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.MembreEquipes.Add(MembreEquipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = MembreEquipe.IDEquipe });
        }
    }
}
