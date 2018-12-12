using Practic.Infrastructure.Data;
using Practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practic.Unit
{
    public class UnitOfWork : IDisposable
    {
        private CarOrdersContext db = new CarOrdersContext();
        internal EFGenericRepository<Determine> DetermineRepo = new EFGenericRepository<Determine>(new CarOrdersContext());
        internal EFGenericRepository<JobType> JobTypeRepo = new EFGenericRepository<JobType>(new CarOrdersContext());
        internal EFGenericRepository<Material> MaterialRepo = new EFGenericRepository<Material>(new CarOrdersContext());
        internal EFGenericRepository<RouteType> RouteTypeRepo = new EFGenericRepository<RouteType>(new CarOrdersContext());
        internal EFGenericRepository<Route> RouteRepo = new EFGenericRepository<Route>(new CarOrdersContext());
        internal EFGenericRepository<Weigh> WeighRepo = new EFGenericRepository<Weigh>(new CarOrdersContext());
        //internal EFGenericRepository<RouteFrom> RouteFromRepo = new EFGenericRepository<RouteFrom>(new CarOrdersContext());
        //internal EFGenericRepository<RouteTo> RouteToRepo = new EFGenericRepository<RouteTo>(new CarOrdersContext());
        internal EFGenericRepository<Order> OrdersRepo = new EFGenericRepository<Order>(new CarOrdersContext());
        internal EFGenericRepository<Provider> ProviderRepo = new EFGenericRepository<Provider>(new CarOrdersContext());
        internal EFGenericRepository<Machine> MachineRepo = new EFGenericRepository<Machine>(new CarOrdersContext());

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}