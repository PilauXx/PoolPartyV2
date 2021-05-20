using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models
{
    public class Competition
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Jeu jeu { get; set; }

        public ICollection<Equipe> Equipes { get; set; }

        public ICollection<Etape> Etapes { get; set; }

    }
}
