using AREA.Membership.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.Services
{

    ///-------------------------------------------------------------------------
    /// <summary>
    /// IMembersService
    /// </summary>
    /// 
    public interface IMembersService : IDependency
    {

        MembersPart Factory();

    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// MembersService
    /// </summary>
    /// 
    public class MembersService : IMembersService
    {
        private IOrchardServices _orchardServices;
        public MembersService(IOrchardServices services)
        {
            _orchardServices = services;
        }



        ///-------------------------------------------------------------------------
        /// <summary>
        /// Factory
        /// </summary>
        /// 
        public MembersPart Factory()
        {
            var objServiceItem = _orchardServices.ContentManager.New("MembersServiceItem");

            _orchardServices.ContentManager.Create(objServiceItem, VersionOptions.Published);

            var objMemberPart = objServiceItem.As<MembersPart>();

            return objMemberPart;

        }


    }
}