namespace ListaDeTarefas.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ListaDeTarefas.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ListaDeTarefas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ListaDeTarefas.Models.ApplicationDbContext context)
        {
            AddUsers(context);
        }

        void AddUsers(ListaDeTarefas.Models.ApplicationDbContext context)
        {
            var user = new ApplicationUser { UserName = "user1@email.com" };
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            um.Create(user, "password");
        }
    }
}
