using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Data;
using PoolPartyV2.Models;
using PoolPartyV2.Models.Views;

namespace PoolPartyV2.Pages.Licencies
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly PoolPartyV2.Data.ApplicationDbContext _context;

        public EditModel(PoolPartyV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Licencie Licencie { get; set; }

        public IList<IdentityRole> roles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Licencie = await _context.Licensie.FirstOrDefaultAsync(m => m.ID == id);

            if (Licencie == null)
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

            _context.Attach(Licencie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicencieExists(Licencie.ID))
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

        /*
         * Permet d'afficher les roles de l'utilisateur
         */
        public async Task<IActionResult> ManageUserRoles(int? userID)
        {
            var user = await _context.Licensie.FirstOrDefaultAsync(m => m.ID == userID);

            if (user == null)
            {
                return NotFound();
            }

            var model = new List<UserRolesViewModel>();

            roles = await _context.Roles.ToListAsync();

            foreach (var role in roles)
            {
                UserRolesViewModel userRole = new UserRolesViewModel();
                userRole.RoleId = role.Id;
                userRole.RoleName = role.Name;

                var asRole = await _context.UserRoles.Include(e => e.UserId)
                    .Where(e => e.RoleId.Contains(role.Id))
                    .Where(e => e.UserId.Contains((char)userID))
                    .ToListAsync();

                if (asRole != null)
                {
                    userRole.IsSelected = true;
                }
                else
                {
                    userRole.IsSelected = false;
                }

                model.Add(userRole);
            }

            return Page();
        }

        private bool LicencieExists(int id)
        {
            return _context.Licensie.Any(e => e.ID == id);
        }
    }
}
