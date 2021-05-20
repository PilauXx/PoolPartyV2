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

        public ICollection<Licencie> Licensies { get; set; }

        public Jeu jeu;
    }
}
