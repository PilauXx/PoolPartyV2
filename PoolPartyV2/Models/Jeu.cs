using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models
{
    public class Jeu
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }

        public ICollection<Competition> Competitions { get; set; }

        public ICollection<Equipe> Equipes { get; set; }
    }
}
