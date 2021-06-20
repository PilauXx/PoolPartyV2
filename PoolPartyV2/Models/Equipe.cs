using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models
{
    public class Equipe
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }

        [Display(Name = "Membres de l'équipe")]
        public ICollection<MembreEquipe> Licensies { get; set; }
        public Jeu jeu { get; set; }
        public int? IDJeu { get; set; }
    }
}
