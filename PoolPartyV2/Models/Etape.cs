using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models
{
    public class Etape
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Rencontre Rencontre { get; set; }
        public int RencontreID { get; set; }

        public Etape EtapeSuivante { get; set; }

        public ICollection<Etape> EtapesPrecedantes { get; set; }

        public Competition Competition { get; set; }

    }
}
