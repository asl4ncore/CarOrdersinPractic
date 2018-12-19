using Practic.Models;
using Practic.Models.Models.Lombard;
using System;
using System.Data.Entity;

namespace Practic.Infrastructure.Data
{
    public class CarOrdersContext : DbContext
    {
        #region LombardContext
        public DbSet<Pledge> Pledges { get; set; }
        public DbSet<PledgeType> PledgeTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operation> Operations { get; set; }
        #endregion

        #region CarOrders
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
        #endregion
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
