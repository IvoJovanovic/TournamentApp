using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TournamentApp.Domain;

namespace TournamentApp.Presentation.Models
{
    public class MakeTeamController
    {
        public void IfChooseMakeTeam()
        {
            var teamRespository = new TeamRespository();

            Console.Clear();

            Console.WriteLine("Please enter: \n");

            Console.WriteLine("Name of team: ");
            string teamName = Console.ReadLine();

            Console.WriteLine("Logo animal name: ");
            string logoAnimalName = Console.ReadLine();

            if (!teamRespository.IsTeamInDb(teamName, logoAnimalName))
                teamRespository.MakeTeam(teamName, logoAnimalName);
            else
                Console.WriteLine("Team with that name or logo animal name is alredy in DB");

            Thread.Sleep(2000);

            Console.Clear();

            Console.WriteLine("make player | make team | team players | tournament | friendly match");
        }
    }
}
