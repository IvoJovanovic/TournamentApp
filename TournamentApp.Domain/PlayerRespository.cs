using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Data;
using TournamentApp.Data.Models;

namespace TournamentApp.Domain
{
    public class PlayerRespository
    {
        public bool IsPlayerInDb(string firstName, string lastName)
        {
            using (var context = new TournamentAppContext())
            {
                if (context.Players.Where(x => x.FirstName == firstName && x.LastName == lastName).ToList().Count != 0)
                    return true;
                return false;
            }
        }

        public void MakePlayer(string firstName, string lastName, int phoneNumber, string email)
        {
            using (var context = new TournamentAppContext())
            {
                context.Players.Add(new Player()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Team = null
                });
                context.SaveChanges();

                Console.WriteLine("New player added to Db.");
            }
        }

        public bool CanTeamAddPlayer(string teamPlayerFirstName, string teamPlayerLastName, string teamName)
        {
            var teamRespository = new TeamRespository();

            using (var context = new TournamentAppContext())
            {
                if (IsPlayerInDb(teamPlayerFirstName, teamPlayerLastName) && teamRespository.FreePlayers().Find(x => x.FirstName == teamPlayerFirstName && x.LastName == teamPlayerLastName).Team == null) // dadat za 5 ljudi
                    return true;
                return false;
            }
        }

        public Player GetPlayerByFirstNameAndLastName(string firstName, string lastName)
        {
            using (var context = new TournamentAppContext())
            {
                return context.Players.Where(x => x.FirstName == firstName && x.LastName == lastName).First();
            }
        }

        public void AddPlayerInTeam(string firstName, string lastName, string teamName)
        {
            var teamRespository = new TeamRespository();

            using (var context = new TournamentAppContext())
            {
                context.Players.Find(GetPlayerByFirstNameAndLastName(firstName, lastName).Id).Team = context.Teams.Find(teamRespository.GetTeamByTeamName(teamName).Id);
                context.Teams.Find(teamRespository.GetTeamByTeamName(teamName).Id).Players.Add(context.Players.Find(GetPlayerByFirstNameAndLastName(firstName, lastName).Id));

                context.SaveChanges();

                Console.WriteLine("Player added in team.");
            }
        }
    }
}
