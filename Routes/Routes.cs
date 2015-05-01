using Orchard.Mvc.Routes;
using Orchard.WebApi.Routes;
using System.Collections.Generic;
using System.Web.Http;


namespace WAA.Routes
{
    public class HttpRoutes : IHttpRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
            new HttpRouteDescriptor {
                Name = "MembershipRoute",
                Priority = 5,
                RouteTemplate = "api/membership/{controller}/{id}",
                Defaults = new {
                    area = "WAA",
                    id = RouteParameter.Optional
                }
            }
        };
           // return new[] {
           //     new HttpRouteDescriptor {

           //        Name = "MembershipRoute", // if named route, see Test 3 below
           //        Priority = -9, // can be ommited, but if used, needs to be > -10
           //         RouteTemplate = "api/membership/{controller}/{id}",
           //         Defaults = new { area = "Membership", id = RouteParameter.Optional },
           //     }

           //     //new HttpRouteDescriptor {

           //     //   Name = "ProducerRouteInvoke", // if named route, see Test 3 below
           //     //   Priority = -9, // can be ommited, but if used, needs to be > -10
           //     //    RouteTemplate = "api/Producer/{controller}/invoke",
           //     //    Defaults = new { area = "Producer", id = RouteParameter.Optional },

           //     //}
           //};

        }

    }
}