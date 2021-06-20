using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models
{
    public class MembreEquipe
    {
        public int ID { get; set; }

        public int IDEquipe { get; set; }
        public Equipe Equipe { get; set; }

        public int IDLicencie { get; set; }
        public Licencie  Licencie { get; set; }

        public bool Confirmed { get; set; }
    }
}
