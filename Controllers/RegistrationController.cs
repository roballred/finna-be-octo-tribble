﻿using AREA.Membership.Base;
using AREA.Membership.Models;
using AREA.Membership.Services;
using AREA.Membership.ViewModels;
using Orchard;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;
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
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;


        public RegistrationController(IOrchardServices orchardServices,
            IAddressesService objAddressesService,
            IMembersService objMembersService,
            ITaxonomyService taxonomyService)
            : base(orchardServices)
        {
            m_objAddressesService = objAddressesService;
            m_objMembersService = objMembersService;
            _taxonomyService = taxonomyService;
        }


        [Themed]
        public string Index()
        {

            m_objMembersService.Testing();
            return"junk";

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

            var taxonomy = _taxonomyService.GetTaxonomyByName("Category");
                        
            var terms =_taxonomyService.GetTerms(taxonomy.Id);

            List<CategoryViewModel> colCategories = new List<CategoryViewModel>();

            foreach(TermPart eachTerm in terms)
            {
                CategoryViewModel objCategoryViewModel = new CategoryViewModel();

                objCategoryViewModel.Name = eachTerm.Name;
                colCategories.Add(objCategoryViewModel);

            }

            objRegisterProducerViewModel.Category = colCategories;


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

                //save taxonomy


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