using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Data.Models;

namespace TournamentApp.Data
{
    public class TournamentAppContext : DbContext
    {
        public TournamentAppContext() : base("TournamentAppDb")
        {
            Database.SetInitializer(new TournamentAppDbSetInitializer());
        }

        virtual public DbSet<Player> Players { get; set; }

        virtual public DbSet<Team> Teams { get; set; }

        virtual public DbSet<Tournament> Tournaments { get; set; }

        virtual public DbSet<Match> Matches { get; set; }
    }
}
