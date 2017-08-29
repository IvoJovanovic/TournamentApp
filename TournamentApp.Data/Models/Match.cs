using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Round Round { get; set; }
        public bool IsTournamentMatch { get; set; }

        public List<Team> Teams { get; set; }
        public Tournament Tournament { get; set; }
    }
}
