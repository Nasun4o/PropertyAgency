namespace PropertyAgency.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PropertyAgency.Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<PropertyAgency.Data.PropertyAgencyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "PropertyAgency.Data.PropertyAgencyContext";
        }

        protected override void Seed(PropertyAgencyContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {
                //first we create Admin roll
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new User() { UserName = "admin", Email = "nasko@abv.bg" };
                string password = "Hardpass91@!";
                var checkUser = UserManager.Create(user, password);

                //Add default User to Role Admin
                if (checkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            // creating Creating Manager role 
            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);

            }
            // creating Creating Broker role 
            if (!roleManager.RoleExists("Broker"))
            {
                var role = new IdentityRole();
                role.Name = "Broker";
                roleManager.Create(role);

            }
        }
    }
}