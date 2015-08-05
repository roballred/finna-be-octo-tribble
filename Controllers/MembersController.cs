using Orchard;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;
using Orchard.Users.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAA.Base;
using WAA.Models;
using WAA.Services;
using WAA.ViewModels;
using Orchard.Mvc.Extensions;

namespace WAA.Controllers
{
    public class MembersController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserEventHandler _userEventHandler;
        private readonly IMembersService _memberService;
        private readonly IAddressesService m_objAddressesService;
        private readonly IMemberLookupService m_objMemberLookupService;
        private readonly IMembershipService _membershipService;


        public MembersController(IOrchardServices orchardServices,
            IAuthenticationService authenticationService,
            IMembersService memberService,
            IAddressesService objAddressesService,
            IMemberLookupService objMemberLookupService,
            IMembershipService membershipService,
            IUserEventHandler userEventHandler)
            : base(orchardServices)
        {
            _authenticationService = authenticationService;
            _memberService = memberService;
            m_objAddressesService = objAddressesService;
            m_objMemberLookupService = objMemberLookupService;
            _userEventHandler = userEventHandler;
            _membershipService = membershipService;

        }

        [Themed]
        // GET: Flightdeck
        public ActionResult Index()
        {

            //get user id and pass to Prepare flight deck

            return View("loginpage");
        }

                
        [Themed]
        [HttpPost]
        [AlwaysAccessible]
        [ValidateInput(false)]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userNameOrEmail, string password)
        {
            var user = ValidateLogOn(userNameOrEmail, password);
            if (!ModelState.IsValid || user == null)
            {
                return View("loginpage");
            }

            _authenticationService.SignIn(user, true);
            _userEventHandler.LoggedIn(user);

            return this.RedirectToAction("FlightDeck");
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


        private IUser ValidateLogOn(string userNameOrEmail, string password)
        {
            bool validate = true;

            if (String.IsNullOrEmpty(userNameOrEmail))
            {
                ModelState.AddModelError("userNameOrEmail", "You must specify a username or e-mail.");
                validate = false;
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password", "You must specify a password.");
                validate = false;
            }

            if (!validate)
                return null;

            var user = _membershipService.ValidateUser(userNameOrEmail, password);
            if (user == null)
            {
                ModelState.AddModelError("_FORM","The username or e-mail or password provided is incorrect.");
            }

            return user;
        }


    }
}