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
using PoolPartyV2.Models.Views;

namespace PoolPartyV2.Pages.Equipes
{
    public class EditModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;
        private IList<Licencie> licencies { get; set; }
        public IList<LicencieParticipationViewModels> licencieParticipations { get; set; }

        public EditModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Equipe Equipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            licencieParticipations = new List<LicencieParticipationViewModels>();
            Equipe = await _context.Equipe
                .Include(u => u.jeu).FirstOrDefaultAsync(m => m.ID == id);
            
            if (Equipe == null)
            {
                return NotFound();
            }

            ViewData["JEU"] = new SelectList(_context.Jeu, "ID", "Nom");

            licencies = await _context.Licensie.ToListAsync();
            foreach(Licencie licencie in licencies)
            {
                var selected = _context.MembreEquipes
                    .Where(e => e.IDEquipe.Equals(id) && e.IDLicencie.Equals(licencie.ID))
                    .FirstOrDefaultAsync();
                LicencieParticipationViewModels licencieParti = new LicencieParticipationViewModels();
                licencieParti.idLiecencie = licencie.ID;
                licencieParti.NomLicencie = licencie.Nom;
                if (selected != null)
                {
                    licencieParti.IsSelected = true;
                }else
                {
                    licencieParti.IsSelected = false;
                }
                licencieParticipations.Add(licencieParti);
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

            _context.Attach(Equipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExists(Equipe.ID))
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

        private bool EquipeExists(int id)
        {
            return _context.Equipe.Any(e => e.ID == id);
        }
    }
}
