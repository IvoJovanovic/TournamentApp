using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Domain;
using TournamentApp.Presentation.Models;

namespace TournamentApp.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var makePlayerController = new MakePlayerController();
            var makeTeamController = new MakeTeamController();
            var chooseTeamPlayersController = new ChooseTeamPlayersController();
            var tournamentController = new TournamentController();
            var friendlyMatchController = new FriendlyMatchController();

            Console.WriteLine("make player | make team | team players | tournament | friendly match");

            while (true)
            {
                var choose = Console.ReadLine();

                if (choose == "make player")
                    makePlayerController.IfChooseMakePlayer();

                else if (choose == "make team")
                    makeTeamController.IfChooseMakeTeam();

                else if (choose == "team players")
                    chooseTeamPlayersController.IfChooseTeamPlayers();

                else if (choose == "tournament")
                    tournamentController.IfChooseTournament();

                else if (choose == "friendly match")
                    friendlyMatchController.IfChooseFriendlyMatch();
            }
        }
    }
}
