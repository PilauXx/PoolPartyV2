using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoolPartyV2.Data;
using PoolPartyV2.Models;
using PoolPartyV2.Models.Views;

namespace PoolPartyV2.Pages.Equipes
{
    public class CreateModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;
        [BindProperty]
        public IList<LicencieParticipationViewModels> licencieParticipations { get; set; }
        [BindProperty]
        public Equipe Equipe { get; set; }

        public CreateModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["JEU"] = new SelectList(_context.Jeu, "ID", "Nom");
            licencieParticipations = new List<LicencieParticipationViewModels>();
            foreach (Licencie licencie in _context.Licensie)
            {
                if (licencie.LienceValidate)
                {
                    LicencieParticipationViewModels licencieParticipation = new LicencieParticipationViewModels();
                    licencieParticipation.idLiecencie = licencie.ID;
                    licencieParticipation.NomLicencie = licencie.Nom;
                    licencieParticipation.IsSelected = false;
                    licencieParticipations.Add(licencieParticipation);
                }
            }
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Jeu jeu = _context.Jeu.Find(Equipe.IDJeu);
            Equipe.jeu = jeu;

            _context.Equipe.Add(Equipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

