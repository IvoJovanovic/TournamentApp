using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TournamentApp.Domain;

namespace TournamentApp.Presentation.Models
{
    public class MakePlayerController
    {
        public void IfChooseMakePlayer()
        {
            var playerRespository = new PlayerRespository();

            Console.Clear();

            Console.WriteLine("Please enter: \n");

            Console.WriteLine("First name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Phone number: ");
            int phoneNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            if (!playerRespository.IsPlayerInDb(firstName, lastName))
                playerRespository.MakePlayer(firstName, lastName, phoneNumber, email);
            else
                Console.WriteLine("Player with that first name or last name is in DB.");

            Thread.Sleep(2000);

            Console.Clear();

            Console.WriteLine("make player | make team | team players | tournament | friendly match");
        }
    }
}
