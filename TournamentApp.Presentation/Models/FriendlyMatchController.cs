using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TournamentApp.Data;
using TournamentApp.Domain;

namespace TournamentApp.Presentation.Models
{
    public class FriendlyMatchController
    {
        public void IfChooseFriendlyMatch()
        {
            using (var context = new TournamentAppContext())
            {
                var teamRespository = new TeamRespository();
                var matchRespository = new MatchRespository();

                Console.Clear();

                if (context.Teams.Where(x => x.Match == null && x.Players.Count >= 1).ToList().Count >= 2)
                {
                    Console.WriteLine("Give name for this friendly match: ");

                    var name = Console.ReadLine();

                    while (context.Matches.Where(x => x.Name == name).ToList().Count != 0)
                    {
                        Console.WriteLine("Problem.");

                        Console.WriteLine("Give name for this friendly match: ");

                        name = Console.ReadLine();
                    }

                    Console.WriteLine("Choose 2 teams for friendly match: ");

                    context.Teams.Where(x => x.Match == null).ToList().ForEach(x => Console.WriteLine(x.Name));

                    Console.WriteLine("Team 1:\nTeam name: ");
                    var team1Name = Console.ReadLine();

                    while (context.Teams.Where(x => x.Match == null && x.Players.Count > 0 && x.Name == team1Name).ToList().Count == 0)
                    {
                        Console.WriteLine("Wrong name.");
                        Console.WriteLine("Team 1:\nTeam name: ");
                        team1Name = Console.ReadLine();
                    }

                    Console.WriteLine("Team 2:\nTeam name: ");
                    var team2Name = Console.ReadLine();

                    while (context.Teams.Where(x => x.Match == null && x.Players.Count > 0 && x.Name == team2Name && team1Name != team2Name).ToList().Count == 0)
                    {
                        Console.WriteLine("Wrong name.");
                        Console.WriteLine("Team 2:\nTeam name: ");
                        team2Name = Console.ReadLine();
                    }

                    matchRespository.MakeNewFriendlyMatch(name, team1Name, team2Name);
                }
                else
                    Console.WriteLine("No min number of teams.");

                Thread.Sleep(2000);

                Console.Clear();

                Console.WriteLine("make player | make team | team players | tournament | friendly match");
            }
        }

    }
}
