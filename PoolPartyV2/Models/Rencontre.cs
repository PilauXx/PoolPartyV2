using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PoolPartyV2.Models
{
    public class Rencontre
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Jeu jeu { get; set; }

        [Required]
        public Etape Etape { get; set; }
        public int EtapeID { get; set; }

        public Equipe EquipeA { get; set; }
        public Equipe EquipeB { get; set; }

        public int ScoreA { get; set; }
        public int ScoreB { get; set; }

        public Equipe getWinner()
        {
            if (ScoreA > ScoreB)
                return EquipeA;
            else
                return EquipeB;
        }
    }
}
