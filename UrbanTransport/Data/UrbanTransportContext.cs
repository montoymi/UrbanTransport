using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UrbanTransport.Models
{
    public class UrbanTransportContext : DbContext
    {
        public UrbanTransportContext(DbContextOptions<UrbanTransportContext> options)
            : base(options)
        {
        }

        public DbSet<UrbanTransport.Models.Bus> Bus { get; set; }
        public DbSet<UrbanTransport.Models.BusRoute> BusRoute { get; set; }
        public DbSet<UrbanTransport.Models.CheckPoint> CheckPoint { get; set; }
        public DbSet<UrbanTransport.Models.ControlRecord> ControlRecord { get; set; }
        public DbSet<UrbanTransport.Models.Role> Role { get; set; }
        public DbSet<UrbanTransport.Models.Route> Route { get; set; }
        public DbSet<UrbanTransport.Models.User> User { get; set; }

        // Specifying ON DELETE NO ACTION in Entity Framework 7
        // Evita error: Introducing FOREIGN KEY constraint ... may cause cycles or multiple cascade paths.
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }
    }
}
