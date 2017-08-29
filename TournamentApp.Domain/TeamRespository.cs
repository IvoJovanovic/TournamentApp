using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Data;
using TournamentApp.Data.Models;

namespace TournamentApp.Domain
{
    public class TeamRespository
    {
        public bool IsTeamInDb(string name, string animalLogoName)
        {
            using (var context = new TournamentAppContext())
            {
                if (context.Teams.Where(x => x.Name == name || x.LogoAnimalName == animalLogoName).ToList().Count > 0)
                    return true;
                return false;
            }
        }

        public bool TeamsForEdit(string name, string animalLogoName)
        {
            using (var context = new TournamentAppContext())
            {
                if (context.Teams.Where(x => x.Name == name && x.LogoAnimalName == animalLogoName).ToList().Count > 0)
                    return true;
                return false;
            }
        }

        public bool IsTeamInDbTournament(string torunamentname, string name, string animalLogoName)
        {
            var tournamentRespository = new TournamentRespository();

            using (var context = new TournamentAppContext())
            {
                if (context.Teams.Where(x => x.Name == name && x.LogoAnimalName == animalLogoName).ToList().Count > 0 && !tournamentRespository.IsTeamInTournament(torunamentname, name))
                    return true;
                return false;
            }
        }

        public void MakeTeam(string name, string animalLogoName)
        {
            using (var context = new TournamentAppContext())
            {
                context.Teams.Add(new Team()
                {
                    Name = name,
                    LogoAnimalName = animalLogoName,
                    TournamentsWon = new List<Tournament>(),
                    Match = null,
                    Players = new List<Player>()
                });
                context.SaveChanges();

                Console.WriteLine("You made team.");
            }
        }

        public List<Player> FreePlayers()
        {
            using (var context = new TournamentAppContext())
            {
                return context.Players.Where(x => x.Team == null).ToList();
            }
        }

        public void AllPlayersFromTeam(string teamName)
        {
            using (var context = new TournamentAppContext())
            {
                if (context.Teams.Find(GetTeamByTeamName(teamName).Id) == null)
                    Console.WriteLine("No players");
                else
                    context.Teams.Include("Players").Where(x => x.Name == teamName).First().Players.ForEach(player => Console.WriteLine(player.FirstName + " " + player.LastName));
            }
        }

        public Team GetTeamByTeamName(string teamName)
        {
            using (var context = new TournamentAppContext())
            {
                return context.Teams.Where(x => x.Name == teamName).FirstOrDefault();
            }
        }

        public List<Team> GetAllTeamsCanPlayTournament()
        {
            using (var context = new TournamentAppContext())
            {
                return context.Teams.Where(x => x.Players.Count >= 1).ToList();
            }
        }

        public void IsTeamInTournament(string tournamentName, string teamName)
        {
            var tournamentRespository = new TournamentRespository();

            using (var context = new TournamentAppContext())
            {
                context.Tournaments.Include("Teams").ToList().ForEach(x => Console.WriteLine(x.Teams.Count));
            }
        }

        public void RemovePlayerFromTeam(string firstName, string lastName, string teamName)
        {
            var playerRespository = new PlayerRespository();
            var teamRespository = new TeamRespository();

            using (var context = new TournamentAppContext())
            {
                context.Players.Find(playerRespository.GetPlayerByFirstNameAndLastName(firstName, lastName).Id).Team = null;
                context.Teams.Find(teamRespository.GetTeamByTeamName(teamName).Id).Players.Remove(context.Players.Find(playerRespository.GetPlayerByFirstNameAndLastName(firstName, lastName).Id));

                context.SaveChanges();

                Console.WriteLine("Player removed.");
            }
        }

        public bool IsPlayerInThisTeam(string firstName, string lastName, string teamName)
        {
            var playerRespository = new PlayerRespository();

            using (var context = new TournamentAppContext())
            {
                return (context.Teams.Include("Players").Where(x => x.Name == teamName).First().Players.Where(player => player.FirstName == firstName && player.LastName == lastName).ToList().Count != 0);
            }
        }
    }
}
