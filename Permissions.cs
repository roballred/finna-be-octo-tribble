using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA
{
    public class Permissions : IPermissionProvider
    {

        //// Everything's pretty self-explanatory
        //public static readonly Permission EditPersonList = new Permission { Description = "Edit Person List items", Name = "EditPersonList" };
        //// ImpliedBy means that everybody who has the EditPersonList permission also automatically possesses the AccessPersonListDashboard permission
        //// as well. Be aware that because of this AccessPersonListDashboard should be written after EditPersonList.
        //public static readonly Permission AccessPersonListDashboard = new Permission { Description = "Access the Person List dashboard", Name = "AccessPersonListDashboard", ImpliedBy = new[] { EditPersonList } };

        public static readonly Permission AccessMemberDashboard = new Permission { Description = "Access the Member dashboard", Name = "AccessMemberDashboard" };
        public static readonly Permission AccessWaaDashboard = new Permission { Description = "Access the WAA dashboard", Name = "AccessWaaDashboard" };


        public IEnumerable<Permission> GetPermissions()
        {
            return new[]
            {
                AccessMemberDashboard,
                AccessWaaDashboard
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            // Giving some defaults: which user groups should possess which permissions
            return new[]
            {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {AccessWaaDashboard}
                },
                new PermissionStereotype
                {
                    Name = "Authenticated",
                    Permissions = new[] { AccessMemberDashboard }
                }
            };
        }

        public Feature Feature { get; set; }
    }
}