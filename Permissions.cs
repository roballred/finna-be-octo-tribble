﻿using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership
{
    public class Permissions : IPermissionProvider
    {

        //// Everything's pretty self-explanatory
        //public static readonly Permission EditPersonList = new Permission { Description = "Edit Person List items", Name = "EditPersonList" };
        //// ImpliedBy means that everybody who has the EditPersonList permission also automatically possesses the AccessPersonListDashboard permission
        //// as well. Be aware that because of this AccessPersonListDashboard should be written after EditPersonList.
        //public static readonly Permission AccessPersonListDashboard = new Permission { Description = "Access the Person List dashboard", Name = "AccessPersonListDashboard", ImpliedBy = new[] { EditPersonList } };

        public static readonly Permission AccessMemberDashboard = new Permission { Description = "Access the Member dashboard", Name = "AccessMemberDashboard" };


        public IEnumerable<Permission> GetPermissions()
        {
            return new[]
            {
                AccessMemberDashboard
                //AccessPlayerDashboard
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            // Giving some defaults: which user groups should possess which permissions
            return new[]
            {
                //new PermissionStereotype
                //{
                //    // Administrators will have all the permissions by default.
                //    Name = "Administrator",
                //    // Since AccessPersonListDashboard is implied by EditPersonList we don't have to list the former here.
                //    Permissions = new[] { EditPersonList }
                //},
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