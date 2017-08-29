using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentApp.Data.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndTime { get; set; }

        public List<Match> Matches { get; set; }
        public List<Team> Teams { get; set; }
    }
}
