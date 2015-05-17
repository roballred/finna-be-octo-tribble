using Orchard;
using Orchard.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAA.Base
{
    public class BaseController : Controller
    {


        private readonly IOrchardServices _orchardServices;




        public BaseController(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
        }

        public IOrchardServices OrchardServices
        {
            get { return _orchardServices; }
        } 

        ///-------------------------------------------------------------------------
        /// <summary>
        /// IsAuthorized
        /// </summary>
        /// 
        protected bool IsAuthorized()
        {
            // Authorizing the current user against a permission
            return _orchardServices.Authorizer.Authorize(Permissions.AccessMemberDashboard);
        }

        protected string GetUserEmail()
        {
            string szRetVal = string.Empty;

            IUser usertItem = _orchardServices.WorkContext.CurrentUser;
            if (usertItem is IUser)
            {
                szRetVal = usertItem.Email;
            }

            return szRetVal;
        }
    }
}