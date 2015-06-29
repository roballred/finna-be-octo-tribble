using Orchard;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAA.Base;
using WAA.Models;
using WAA.Services;
using WAA.ViewModels;

namespace WAA.Controllers
{
    public class MembersController : BaseController
    {

        private readonly IMembersService _memberService;
        private readonly IAddressesService m_objAddressesService;
        private readonly IMemberLookupService m_objMemberLookupService;


        public MembersController(IOrchardServices orchardServices,
            IMembersService memberService,
            IAddressesService objAddressesService,
            IMemberLookupService objMemberLookupService)
            : base(orchardServices)
        {
            _memberService = memberService;
            m_objAddressesService = objAddressesService;
            m_objMemberLookupService = objMemberLookupService;
        }


        [Themed]
        // GET: Flightdeck
        public ActionResult Flightdeck()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            //get user id and pass to Prepare flight deck

            return View("Flightdeck.Individual");
        }


        [Themed]
        public ActionResult Edit()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            var memberId = m_objMemberLookupService.FindMember();
            return this.EditProfile(memberId);
        }

        [Themed]
        public ActionResult EditProfile(int Id)
        {
            RegisterIndividualViewModel objRegisterIndividualViewModel = new RegisterIndividualViewModel();
            var individualMember = _memberService.Get(Id);
            MembersPart.DeepCopy(objRegisterIndividualViewModel, individualMember);
            PersonsPart.DeepCopy(objRegisterIndividualViewModel.Person, individualMember.Person);
            AddressesPart.DeepCopy(objRegisterIndividualViewModel.Address, individualMember.Address);

            ContactInformationPart.DeepCopy(objRegisterIndividualViewModel.ContactInfo, individualMember.ContactInformation);

            objRegisterIndividualViewModel.States = m_objAddressesService.GetStates();

            objRegisterIndividualViewModel.PostBackUrl = Url.HttpRouteUrl("MembershipRoute", new { controller = "EditIndividualData" });
            objRegisterIndividualViewModel.RedirectUrl = Url.Action("Flightdeck", "Members", new { area = "WAA" });
            //var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategories");

            //if (taxonomy != null)
            //{
            //    var terms = _taxonomyService.GetTerms(taxonomy.Id);

            //    List<CategoryViewModel> colCategories = new List<CategoryViewModel>();

            //    foreach (TermPart eachTerm in terms)
            //    {
            //        CategoryViewModel objCategoryViewModel = new CategoryViewModel();

            //        objCategoryViewModel.Name = eachTerm.Name;
            //        colCategories.Add(objCategoryViewModel);

            //    }

            //    objRegisterIndividualViewModel.Category = colCategories;

            //}



            return View("User.EditIndividualMember", objRegisterIndividualViewModel);
        }



        private ActionResult PrepareFlightdeck(int nMemberId)
        {

            return View("Flightdeck.Individual");

        }


    }
}