using AREA.Membership.Base;
using AREA.Membership.Models;
using AREA.Membership.Services;
using AREA.Membership.ViewModels;
using Orchard;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AREA.Membership.Controllers
{
    public class RegistrationController : BaseController
    {
        private readonly IAddressesService m_objAddressesService;
        private readonly IMembersService m_objMembersService;

        public RegistrationController(IOrchardServices orchardServices,
            IAddressesService objAddressesService,
            IMembersService objMembersService)
            : base(orchardServices)
        {
            m_objAddressesService = objAddressesService;
            m_objMembersService = objMembersService;
        }

        ///-------------------------------------------------------------------------
        /// <summary>
        /// Index
        /// </summary>
        /// 
        [Themed]
        public ActionResult Individual()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            RegisterIndividualViewModel objRegisterProducerViewModel = new RegisterIndividualViewModel();
            objRegisterProducerViewModel.States = m_objAddressesService.GetStates();
            objRegisterProducerViewModel.Address.State = string.Empty;
            IUser userItem = this.OrchardServices.WorkContext.CurrentUser;
            if (userItem is IUser)
            {
                objRegisterProducerViewModel.ContactInfo.EmailAddress = userItem.Email;
            }

            return View("Registration.Individual", objRegisterProducerViewModel);

        }



        ///-------------------------------------------------------------------------
        /// <summary>
        /// Index
        /// </summary>
        /// 
        [Themed]
        [HttpPost]
        public ActionResult Individual(RegisterIndividualViewModel objRegisterProducerViewModel)
        {

            //if (!ModelState.IsValid)
            //{
            //    if (objRegisterProducerViewModel.States == null)
            //    {
            //        objRegisterProducerViewModel.States = m_objAddressesService.GetStates();
            //    }

            //    return View("Registration", objRegisterProducerViewModel);
            //}
            if(objRegisterProducerViewModel != null)
            {
                var member = m_objMembersService.Factory();
                member.Person.Copy(objRegisterProducerViewModel.Person);
                member.Address.Copy(objRegisterProducerViewModel.Address);
                member.ContactInformation.Copy(objRegisterProducerViewModel.ContactInfo);

                IUser userItem = this.OrchardServices.WorkContext.CurrentUser;
                if (userItem is IUser)
                {
                    var test = userItem.Email;
                }

            }


            return RedirectToAction("Index", "Dashboard");
        }


	}
}