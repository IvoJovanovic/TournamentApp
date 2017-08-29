using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TournamentApp.Domain;

namespace TournamentApp.Presentation.Models
{
    public class TournamentController
    {
        public void IfChooseTournament()
        {
            var teamRespository = new TeamRespository();
            var tournamentRespository = new TournamentRespository();

            Console.WriteLine("New tournament|");

            var choose = Console.ReadLine();

            if (choose == "New tournament")
            {
                Console.WriteLine("Name of tournament: ");
                string name = Console.ReadLine();

                if (tournamentRespository.IsMaked(name))
                {
                    Console.WriteLine("Choose 4 teams of thoose: ");
                    teamRespository.GetAllTeamsCanPlayTournament().ForEach(x => Console.WriteLine(x.Name + " " + x.LogoAnimalName));

                    Console.WriteLine("1.team: ");
                    tournamentRespository.AddTeamInTournament(name);
                    Console.WriteLine("2.team: ");
                    tournamentRespository.AddTeamInTournament(name);
                    Console.WriteLine("3.team: ");
                    tournamentRespository.AddTeamInTournament(name);
                    Console.WriteLine("4.team: ");
                    tournamentRespository.AddTeamInTournament(name);

                    tournamentRespository.Organizer(name);
                }
            }


            Thread.Sleep(5000);

            Console.Clear();

            Console.WriteLine("make player | make team | team players | tournament | friendly match");
        }
    }
}
