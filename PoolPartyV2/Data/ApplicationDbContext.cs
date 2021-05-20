using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PoolPartyV2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoolPartyV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Etape>()
                .HasOne(a => a.Rencontre)
                .WithOne(b => b.Etape)
                .HasForeignKey<Rencontre>(b => b.EtapeID);
        }
        public DbSet<Competition> Competition { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Etape> Etape { get; set; }
        public DbSet<Jeu> Jeu { get; set; }
        public DbSet<Licencie> Licensie { get; set; }
        public DbSet<Rencontre> Rencontre { get; set; }
    }
}
