using WAA.Base;
using WAA.Models;
using WAA.Services;
using WAA.ViewModels;
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

namespace WAA.Controllers
{
    public class RegistrationController : BaseController
    {
        private readonly IAddressesService m_objAddressesService;
        private readonly IMembersService m_objMembersService;
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;
        private readonly IMemberLookupService m_objMemberLookupService;


        public RegistrationController(IOrchardServices orchardServices,
            IAddressesService objAddressesService,
            IMembersService objMembersService,
            ITaxonomyService taxonomyService,
            IMemberLookupService objMemberLookupService)
            : base(orchardServices)
        {
            _orchardServices = orchardServices;
            m_objAddressesService = objAddressesService;
            m_objMembersService = objMembersService;
            _taxonomyService = taxonomyService;
            m_objMemberLookupService = objMemberLookupService;
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

            //if (!IsAuthorized()) return new HttpUnauthorizedResult();
            if (IsAuthorized())
            {

                var memberId = m_objMemberLookupService.FindMember(this.GetUserEmail());

                if (memberId > 0)
                {
                    //check to see if they  have registered in memberlookup
                    return RedirectToAction("Flightdeck", "Members");
                }

            }



            RegisterIndividualViewModel objRegisterProducerViewModel = new RegisterIndividualViewModel();
            objRegisterProducerViewModel.States = m_objAddressesService.GetStates();

            IUser userItem = this.OrchardServices.WorkContext.CurrentUser;
            if (userItem is IUser)
            {
                objRegisterProducerViewModel.ContactInfo.EmailAddress = userItem.Email;
            }

            var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategories");
                     
            if(taxonomy != null)
            {
                var terms = _taxonomyService.GetTerms(taxonomy.Id);

                List<CategoryViewModel> colCategories = new List<CategoryViewModel>();

                foreach (TermPart eachTerm in terms)
                {
                    CategoryViewModel objCategoryViewModel = new CategoryViewModel();

                    objCategoryViewModel.Name = eachTerm.Name;
                    colCategories.Add(objCategoryViewModel);

                }

                objRegisterProducerViewModel.Category = colCategories;

            }


            return View("Registration.Individual", objRegisterProducerViewModel);

        }



        ///-------------------------------------------------------------------------
        /// <summary>
        /// Index
        /// </summary>
        /// 
        [Themed]
        public ActionResult Business()
        {
            //if (!IsAuthorized()) return new HttpUnauthorizedResult();
            if (IsAuthorized())
            {
                return RedirectToAction("Flightdeck", "Business");
                //check to see if they  have registered in memberlookup
            }

            RegisterBusinessViewModel objRegisterBusinessViewModel = new RegisterBusinessViewModel();
            objRegisterBusinessViewModel.States = m_objAddressesService.GetStates();

            var taxonomy = _taxonomyService.GetTaxonomyByName("BusinessCategories");

            if (taxonomy != null)
            {
                var terms = _taxonomyService.GetTerms(taxonomy.Id);

                List<CategoryViewModel> colCategories = new List<CategoryViewModel>();

                foreach (TermPart eachTerm in terms)
                {
                    CategoryViewModel objCategoryViewModel = new CategoryViewModel();

                    objCategoryViewModel.Name = eachTerm.Name;
                    colCategories.Add(objCategoryViewModel);

                }

                objRegisterBusinessViewModel.Category = colCategories;

            }


            return View("Registration.Business", objRegisterBusinessViewModel);

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
                PersonsPart.MapData(member.Person, objRegisterProducerViewModel.Person);
                AddressesPart.MapData(member.Address, objRegisterProducerViewModel.Address);

                //member.ContactInformation.Copy(objRegisterProducerViewModel.ContactInfo);
                ContactInformationPart.Copy(member.ContactInformation, objRegisterProducerViewModel.ContactInfo);

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