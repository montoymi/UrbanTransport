using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrbanTransport.Models;

namespace UrbanTransport.Data
{
    public class DbInitializer
    {
        public static void Initialize(UrbanTransportContext context)
        {
            context.Database.EnsureCreated();

            if (context.Role.Any())
            {
                return;
            }

            // Roles

            var roles = new Role[]
            {
                new Role{Name="Gestor"},
                new Role{Name="Conductor"}
            };

            foreach (Role role in roles)
            {
                context.Role.Add(role);
            }

            // Buses

            var buses = new Bus[]
            {
                new Bus{LicencePlate="A4I-773"},
                new Bus{LicencePlate="R4I-345"},
                new Bus{LicencePlate="HRT-793"}
            };

            foreach (Bus bus in buses)
            {
                context.Bus.Add(bus);
            }

            // Rutas

            var routes = new Route[]
            {
                new Route{Name="A"},
                new Route{Name="B"}
            };

            foreach (Route route in routes)
            {
                context.Route.Add(route);
            }

            context.SaveChanges();

            // Puntos de control

            var checkPoints = new CheckPoint[]
            {
                new CheckPoint{RouteId=1, Name="Punto de control 1-1", /*Latitude="-12.103026", Longitude="-77.031666"*/},
                new CheckPoint{RouteId=1, Name="Punto de control 1-2", /*Latitude="-12.091604", Longitude="-77.032876"*/},
                new CheckPoint{RouteId=1, Name="Punto de control 1-3", /*Latitude="-12.059471", Longitude="-77.037581"*/},
                new CheckPoint{RouteId=1, Name="Punto de control 1-4", /*Latitude="-12.049245", Longitude="-77.038633"*/},

                new CheckPoint{RouteId=2, Name="Punto de control 2-1", /*Latitude="-12.090390", Longitude="-77.028312"*/},
                new CheckPoint{RouteId=2, Name="Punto de control 2-2", /*Latitude="-12.088669", Longitude="-77.005094"*/},
                new CheckPoint{RouteId=2, Name="Punto de control 2-3", /*Latitude="-12.084934", Longitude="-76.985482"*/},
                new CheckPoint{RouteId=2, Name="Punto de control 2-4", /*Latitude="-12.085630", Longitude="-76.992799"*/},
            };

            foreach (CheckPoint checkPoint in checkPoints)
            {
                context.CheckPoint.Add(checkPoint);
            }

            context.SaveChanges();
        }
    }
}
