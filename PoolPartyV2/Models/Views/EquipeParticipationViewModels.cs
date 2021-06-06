using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models.Views
{
    public class EquipeParticipationViewModels
    {
        public string nomEquipe { get; set; }
        public int idEquipe { get; set; }
        public int idJeuEquipe { get; set; }
        public bool IsSelected { get; set; }
    }
}
