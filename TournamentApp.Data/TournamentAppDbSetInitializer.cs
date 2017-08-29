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


            context.SaveChanges();

            base.Seed(context);
        }
    }
}