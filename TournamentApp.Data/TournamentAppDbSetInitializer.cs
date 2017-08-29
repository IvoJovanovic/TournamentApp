using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentApp.Data.Models;

namespace TournamentApp.Data
{
    class TournamentAppDbSetInitializer : DropCreateDatabaseIfModelChanges<TournamentAppContext>
    {
        protected override void Seed(TournamentAppContext context)
        {
            var stipe = context.Players.Add(new Player()
            {
                FirstName = "Stipe",
                LastName = "Stipic",
                Email = "stipestipic@gmail.com",
                PhoneNumber = 098123125,
                Team = null
            });

            var mate = context.Players.Add(new Player()
            {
                FirstName = "Mate",
                LastName = "Matic",
                Email = "matematic@gmail.com",
                PhoneNumber = 099123123,
                Team = null
            });

            var luka = context.Players.Add(new Player()
            {
                FirstName = "Luka",
                LastName = "Lukic",
                Email = "lukalukic@gmail.com",
                PhoneNumber = 0981345325
            });

            var jure = context.Players.Add(new Player()
            {
                FirstName = "Jure",
                LastName = "Horvat",
                Email = "jhorvat@gmail.com",
                PhoneNumber = 09821125
            });

            var marin = context.Players.Add(new Player()
            {
                FirstName = "Marin",
                LastName = "Marin",
                Email = "mmarin@gmail.com",
                PhoneNumber = 0923123
            });

            var marko = context.Players.Add(new Player()
            {
                FirstName = "Marko",
                LastName = "Markovic",
                Email = "mamarkovic@gmail.com",
                PhoneNumber = 09984542
            });

            var ante = context.Players.Add(new Player()
            {
                FirstName = "Ante",
                LastName = "Juric",
                Email = "jjuric@gmail.com"
            });

            var jasmin = context.Players.Add(new Player()
            {
                FirstName = "Jasmin",
                LastName = "Horvat",
                Email = "jhorvat@gmail.com",
                PhoneNumber = 0981231223
            });

            var roko = context.Players.Add(new Player()
            {
                FirstName = "Roko",
                LastName = "Rokic",
                Email = "rrokic@gmail.com",
                PhoneNumber = 093123125
            });

            var jan = context.Players.Add(new Player()
            {
                FirstName = "Jan",
                LastName = "Kostelic",
                Email = "jkostelic@gmail.com",
                PhoneNumber = 09811254
            });

            var fran = context.Players.Add(new Player()
            {
                FirstName = "Fran",
                LastName = "Tudor",
                Email = "ftudor@gmail.com",
                PhoneNumber = 09123125
            });


            var Nepobjedivi = new Team
            {
                Name = "Nepobjedivi",
                LogoAnimalName = "Lav"
            };
            var Hrabri = new Team
            {
                Name = "Hrabri",
                LogoAnimalName = "Leopard"
            };
            var Hajduk = new Team
            {
                Name = "Hajduk",
                LogoAnimalName = "Magarac"
            };
            var NoName = new Team
            {
                Name = "NoName",
                LogoAnimalName = "Zmaj"
            };

            stipe.Team = Nepobjedivi;
            mate.Team = Nepobjedivi;
            luka.Team = Nepobjedivi;
            jure.Team = Hrabri;
            marin.Team = Hrabri;
            marko.Team = Hajduk;
            ante.Team = Hajduk;
            jasmin.Team = Hajduk;
            roko.Team = NoName;
            jan.Team = NoName;
            fran.Team = NoName;


            context.SaveChanges();

            base.Seed(context);
        }
    }
}