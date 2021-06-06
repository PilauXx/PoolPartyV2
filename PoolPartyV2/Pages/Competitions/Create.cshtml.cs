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

namespace PoolPartyV2.Pages.Competitions
{
    public class CreateModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public IList<EquipeParticipationViewModels> equipesParticipation { get; set; }

        public CreateModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["JEU"] = new SelectList(_context.Jeu, "ID", "Nom");
            equipesParticipation = new List<EquipeParticipationViewModels>();
            foreach(Equipe equipe in _context.Equipe)
            {
                EquipeParticipationViewModels equipeParticipationViewModels = new EquipeParticipationViewModels();
                equipeParticipationViewModels.idEquipe = equipe.ID;
                equipeParticipationViewModels.nomEquipe = equipe.Nom;
                equipeParticipationViewModels.IsSelected = false;
                equipeParticipationViewModels.idJeuEquipe = equipe.jeu.ID;
                equipesParticipation.Add(equipeParticipationViewModels);
            }
            return Page();
        }

        [BindProperty]
        public Competition Competition { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Competition.Add(Competition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
