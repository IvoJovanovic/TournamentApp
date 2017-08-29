using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Data;
using TournamentApp.Data.Models;

namespace TournamentApp.Domain
{
    public class TournamentRespository
    {
        public bool IsMaked(string name)
        {
            using (var context = new TournamentAppContext())
            {
                if (context.Tournaments.Where(x => x.Name == name).ToList().Count == 0)
                {
                    context.Tournaments.Add(new TournamentApp.Data.Models.Tournament()
                    {
                        Name = name,
                        Teams = new List<Team>(),
                        StartDate = DateTime.Now,
                        Matches = new List<Match>()
                    });

                    context.SaveChanges();

                    Console.WriteLine("Tournament is maked.");
                    return true;
                }
                else
                    Console.WriteLine("Tournament with that name is in Db");
                return false;
            }
        }

        public void AddTeamInTournament(string name)
        {
            var teamRespository = new TeamRespository();

            Console.WriteLine("Name of team: ");
            string teamForTournamet = Console.ReadLine();

            Console.WriteLine("Animal logo name: ");
            string animalLogoName = Console.ReadLine();

            while (!teamRespository.IsTeamInDbTournament(name, teamForTournamet, animalLogoName))
            {
                Console.WriteLine("Wrong.");
                Console.WriteLine("Name of team: ");
                teamForTournamet = Console.ReadLine();
                Console.WriteLine("Animal logo name: ");
                animalLogoName = Console.ReadLine();
            }

            using (var context = new TournamentAppContext())
            {
                context.Tournaments.Include("Teams").Where(x => x.Name == name).First().Teams.Add(context.Teams.Where(team => team.Name == teamForTournamet).First());
                Console.WriteLine("Team " + teamForTournamet + " added in tournament");

                context.SaveChanges();

                Console.WriteLine();
            }
        }

        public Tournament GetTournamentByTorunamentName(string name)
        {
            using (var context = new TournamentAppContext())
            {
                return context.Tournaments.Where(x => x.Name == name).First();
            }
        }

        public bool IsTeamInTournament(string name, string teamForTournament)
        {
            var teamRespository = new TeamRespository();

            using (var context = new TournamentAppContext())
            {
                return context.Tournaments.Include("Teams").Where(x => x.Name == name).First().Teams.Exists(team => team.Name == teamForTournament);
            }
        }

        public void Organizer(string tournamentName)
        {
            var random = new Random();

            var randomTeam = random.Next(1, 4);

            Console.WriteLine("First match:");

            using (var context = new TournamentAppContext())
            {
                var teamRespository = new TeamRespository();

                List<int> listOfIds = context.Tournaments.Include("Teams").Where(x => x.Name == tournamentName).First().Teams.ToList().Select(team => team.Id).ToList();

                var team1 = context.Tournaments.Include("Teams").Where(x => x.Name == tournamentName).First().Teams.Where(team => team.Id == listOfIds[randomTeam - 1]).First();

                listOfIds.RemoveAt(randomTeam - 1);

                var randomTeam2 = random.Next(1, 3);

                var team2 = context.Tournaments.Include("Teams").Where(x => x.Name == tournamentName).First().Teams.Where(team => team.Id == listOfIds[randomTeam2 - 1]).First();

                listOfIds.RemoveAt(randomTeam2 - 1);

                Console.WriteLine("Semifinale:\nFirst match:");

                Console.WriteLine(team1.Name + " v " + team2.Name);

                context.Matches.Add(new Match()
                {
                    Name = "Semifinale",
                    IsTournamentMatch = true,
                    Round = Round.Semifinal,
                    Teams = new List<Team>()
                    {
                        team1,
                        team2
                    },
                    Tournament = context.Tournaments.Find(GetTournamentByTorunamentName(tournamentName).Id)
                });

                var team3 = context.Tournaments.Include("Teams").Where(x => x.Name == tournamentName).First().Teams.Where(team => team.Id == listOfIds.First()).First();
                var team4 = context.Tournaments.Include("Teams").Where(x => x.Name == tournamentName).First().Teams.Where(team => team.Id == listOfIds.Last()).Last();

                context.Matches.Add(new Match()
                {
                    Name = "Semifinale",
                    IsTournamentMatch = true,
                    Round = Round.Semifinal,
                    Teams = new List<Team>()
                    {
                        team3,
                        team4
                    },
                    Tournament = context.Tournaments.Find(GetTournamentByTorunamentName(tournamentName).Id)
                });

                Console.WriteLine("Second match: " + team3.Name + " v " + team4.Name);

                context.SaveChanges();

            }
        }
    }
}
