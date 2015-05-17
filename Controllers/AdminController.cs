using WAA.Models;
using WAA.Services;
using WAA.ViewModels;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAA.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMembersService _memberService;
        private readonly IContactInformationService _contactInformationService;

        public AdminController(IMembersService memberService, IContactInformationService contactInformationService)
        {
            _memberService = memberService;
            _contactInformationService = contactInformationService;
        }

        [Themed]
        // GET: Admin
        public ActionResult Index()
        {
            return View("WaaAdmin");
        }

    
        public ActionResult Reports()
        {
            ListIndividualMembersViewModel objListIndividualMembersViewModel = new ListIndividualMembersViewModel();

            var allMembers = _memberService.GetAllMembers();
            List<MembersViewModel> colMembers = new List<MembersViewModel>();

            foreach (MembersPart eachMember in allMembers)
            {

                var contactInformation = _contactInformationService.Get(eachMember.ContactId);

                MembersViewModel objMembersViewModel = new MembersViewModel();
                objMembersViewModel.Person.Copy(eachMember.Person);
                objMembersViewModel.ContactInfo.Copy(eachMember.ContactInformation);
                objMembersViewModel.Address.Copy(eachMember.Address);
                colMembers.Add(objMembersViewModel);
            }
            objListIndividualMembersViewModel.Members = colMembers;

            return View("List.IndividualMembers", objListIndividualMembersViewModel);
        }


    }
}