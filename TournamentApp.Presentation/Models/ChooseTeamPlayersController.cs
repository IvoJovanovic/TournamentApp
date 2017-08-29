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
    public class ChooseTeamPlayersController
    {
        public void IfChooseTeamPlayers()
        {
            var teamRespository = new TeamRespository();
            var playerRespository = new PlayerRespository();

            Console.Clear();

            using (var context = new TournamentAppContext())
            {
                Console.WriteLine("Choose your team: ");

                context.Teams.ToList().ForEach(x => Console.WriteLine(x.Name + " " + x.LogoAnimalName));

                Console.WriteLine("\nTeam name: ");
                string teamName = Console.ReadLine();

                Console.WriteLine("Team logo animal name: ");
                string logoAnimalNameName = Console.ReadLine();

                if (!teamRespository.TeamsForEdit(teamName, logoAnimalNameName))
                    Console.WriteLine("No team with that name in Db");
                else
                {

                    Console.Clear();

                    Console.WriteLine("Add | Remove | End");

                    string teamChoose = Console.ReadLine();

                    if (teamChoose == "Add")
                    {
                        if (context.Teams.Include("Players").Where(x => x.Name == teamName).First().Players.Count < 5)
                        {
                            Console.Clear();

                            Console.WriteLine("Free players: \n");
                            teamRespository.FreePlayers().ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));

                            Console.WriteLine("Player to add first name: ");
                            string teamPlayerFirstName = Console.ReadLine();

                            Console.WriteLine("Player to add last name: ");
                            string teamPlayerLastName = Console.ReadLine();

                            if (playerRespository.CanTeamAddPlayer(teamPlayerFirstName, teamPlayerLastName, teamName))
                                playerRespository.AddPlayerInTeam(teamPlayerFirstName, teamPlayerLastName, teamName);
                            else
                                Console.WriteLine("Problem.");
                        }
                        else
                            Console.WriteLine("Team have more than 5 players.");
                    }

                    else if (teamChoose == "Remove")
                    {
                        if (context.Teams.Include("Players").Where(x => x.Name == teamName).First().Players.Count == 0)
                            Console.WriteLine("You dont have players to remove");
                        else
                        {
                            Console.WriteLine("Team players: ");

                            teamRespository.AllPlayersFromTeam(teamName);

                            Console.WriteLine("First name: ");
                            string firstName = Console.ReadLine();
                            Console.WriteLine("Last name: ");
                            string lastName = Console.ReadLine();

                            if (teamRespository.IsPlayerInThisTeam(firstName, lastName, teamName))
                                teamRespository.RemovePlayerFromTeam(firstName, lastName, teamName);
                        }
                    }

                    else
                        teamChoose = "End";
                }
            }

            Thread.Sleep(2000);

            Console.Clear();

            Console.WriteLine("make player | make team | team players | tournament | friendly match");
        }
    }
}
