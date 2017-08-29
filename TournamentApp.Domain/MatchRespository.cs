using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Data;
using TournamentApp.Data.Models;

namespace TournamentApp.Domain
{
    public class MatchRespository
    {
        public void MakeNewFriendlyMatch(string name, string team1Name, string team2Name)
        {
            using (var context = new TournamentAppContext())
            {
                var team1 = context.Teams.Where(x => x.Name == team1Name).First();

                var team2 = context.Teams.Where(x => x.Name == team2Name).First();

                context.Matches.Add(new Match()
                {
                    Name = name,
                    IsTournamentMatch = false,
                    Teams = new List<Team>() {
                        team1,
                        team2
                    },
                    Tournament = null
                });

                context.SaveChanges();

                Console.WriteLine("Friendly match: " + name + ": " + team1.Name + " v " + team2.Name);
            }
        }
    }
}
