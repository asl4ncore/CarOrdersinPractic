using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Practic.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var admin = new IdentityRole { Name = "admin" };
            var user = new IdentityRole { Name = "user" };
            var controller = new IdentityRole { Name = "controller" };
            var master = new IdentityRole { Name = "master" };

            // добавляем роли в бд
            roleManager.Create(admin);
            roleManager.Create(user);
            roleManager.Create(controller);
            roleManager.Create(master);

            // создаем пользователей
            var user_admin = new ApplicationUser { Email = "aakhmetzhan@kazzinc.kz", UserName = "aakhmetzhan@kazzinc.kz" };
            string password = "Asl4ncore1337";
            var result = userManager.Create(user_admin, password);

            var user_user = new ApplicationUser { Email = "megorov@kazzinc.kz", UserName = "megorov@kazzinc.kz" };
            string user_password = "Qwerty2020";
            var result2 = userManager.Create(user_user, user_password);

            var user3 = new ApplicationUser { Email = "apetrov@kazzinc.kz", UserName = "apetrov@kazzinc.kz" };
            string password3 = "Qwerty2020";
            var result3 = userManager.Create(user3, password3);

            var user4 = new ApplicationUser { Email = "pupkinv@kazzinc.kz", UserName = "pupkinv@kazzinc.kz" };
            string password4 = "Qwerty2020";
            var result4 = userManager.Create(user4, password4);

            base.Seed(context);
        }
    }
}