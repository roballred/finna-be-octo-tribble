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


        public AdminController(IMembersService memberService)
        {
            _memberService = memberService;
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
                MembersViewModel objMembersViewModel = new MembersViewModel();
                objMembersViewModel.Person.Copy(eachMember.Person);
                colMembers.Add(objMembersViewModel);
            }
            objListIndividualMembersViewModel.Members = colMembers;

            return View("List.IndividualMembers", objListIndividualMembersViewModel);
        }


    }
}