using Practic.Models;
using System;
using System.Data.Entity;

namespace Practic.Infrastructure.Data
{
    public class CarOrdersContext : DbContext
    {
        public DbSet<Weigh> Weighs { get; set; }
        public DbSet<Determine> Determines { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Route> Routes { get; set; }
        //public DbSet<RouteTo> RouteToes { get; set; }
        //public DbSet<RouteFrom> RouteFroms { get; set; }
        public DbSet<RouteType> RouteTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        
    }
    public class CarOrdersDbInitializer : DropCreateDatabaseIfModelChanges<CarOrdersContext>
    {
        protected override void Seed(CarOrdersContext db)
        {
            db.RouteTypes.Add(new RouteType { Name = "Усть-Каменогорск" });
            db.Determines.Add(new Determine { Name = "1 раз" ,AuditDate= DateTime.Now });
            //db.JobTypes.Add(new JobType { Name = "" });
            //db.Routes.Add(new Route { Name = "" });
            //db.RouteToes.Add(new RouteTo { Name = "" });
            //db.RouteFroms.Add(new RouteFrom { Name = "" });
            //db.Determines.Add(new Determine { Name = "" });
            //db.Materials.Add(new Material { Name = "" });
            //db.Orders.Add(new Order { Name = "" });
            //db.Providers.Add(new Provider { Name = "" });
            db.SaveChanges();
        }
    }
}
