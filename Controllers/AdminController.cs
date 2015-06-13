using WAA.Models;
using WAA.Services;
using WAA.ViewModels;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Taxonomies.Services;
using Orchard.Taxonomies.Models;

namespace WAA.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMembersService _memberService;
        private readonly IBusinessService _businessService;
        private readonly IContactInformationService _contactInformationService;
        private readonly IAddressesService m_objAddressesService;
        private ITaxonomyService _taxonomyService;

        public AdminController(IMembersService memberService, 
            IContactInformationService contactInformationService,
            IBusinessService businessService,
            IAddressesService objAddressesService,
            ITaxonomyService taxonomyService)
        {
            _memberService = memberService;
            _businessService = businessService;
            _contactInformationService = contactInformationService;
            m_objAddressesService = objAddressesService;
            _taxonomyService = taxonomyService;

        }

        [Themed]
        // GET: Admin
        public ActionResult Index()
        {
            return View("WaaAdmin");
        }


        [Themed]
        public ActionResult EditBusiness(int Id)
        {
            RegisterBusinessViewModel objRegisterBusinessViewModel = new RegisterBusinessViewModel();
            var businessMember = _businessService.Get(Id);
            BusinessPart.DeepCopy(objRegisterBusinessViewModel, businessMember);
            PersonsPart.DeepCopy(objRegisterBusinessViewModel.Person, businessMember.Person);
            AddressesPart.DeepCopy(objRegisterBusinessViewModel.Address, businessMember.Address);

            ContactInformationPart.DeepCopy(objRegisterBusinessViewModel.ContactInfo, businessMember.ContactInformation);

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



            return View("Edit.BusinessMember", objRegisterBusinessViewModel);
        }

         [Themed]
        public ActionResult ListBusinesses()
        {
            BusniessDirectoryViewModel objBusniessDirectoryViewModel = new BusniessDirectoryViewModel();

            var allMembers = _businessService.GetAllBusinesses();
            List<BusinessViewModel> colMembers = new List<BusinessViewModel>();

            foreach (BusinessPart eachMember in allMembers)
            {
                BusinessViewModel objBusinessViewModel = new BusinessViewModel();

                BusinessPart.DeepCopy(objBusinessViewModel, eachMember);

                AddressesPart.Copy(objBusinessViewModel.Address, eachMember.Address);

                ContactInformationPart.DeepCopy(objBusinessViewModel.ContactInfo, eachMember.ContactInformation);

                colMembers.Add(objBusinessViewModel);
            }
            
            objBusniessDirectoryViewModel.Businesses = colMembers;

            return View("List.BusinessMembers", objBusniessDirectoryViewModel);
        }


         [Themed]
         public ActionResult EditMember(int Id)
         {
             RegisterIndividualViewModel objRegisterIndividualViewModel = new RegisterIndividualViewModel();
             var individualMember = _memberService.Get(Id);
             MembersPart.DeepCopy(objRegisterIndividualViewModel, individualMember);
             PersonsPart.DeepCopy(objRegisterIndividualViewModel.Person, individualMember.Person);
             AddressesPart.DeepCopy(objRegisterIndividualViewModel.Address, individualMember.Address);

             ContactInformationPart.DeepCopy(objRegisterIndividualViewModel.ContactInfo, individualMember.ContactInformation);

             objRegisterIndividualViewModel.States = m_objAddressesService.GetStates();

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



             return View("Edit.IndividualMember", objRegisterIndividualViewModel);
         }


        public ActionResult ListMembers()
        {

            ListIndividualMembersViewModel objMembersDirectoryViewModel = new ListIndividualMembersViewModel();

            var allMembers = _memberService.GetAllMembers();
            List<MembersViewModel> colMembers = new List<MembersViewModel>();

            foreach (MembersPart eachMember in allMembers)
            {
                MembersViewModel objViewModel = new MembersViewModel();

                MembersPart.DeepCopy(objViewModel, eachMember);

                AddressesPart.DeepCopy(objViewModel.Address, eachMember.Address);

                ContactInformationPart.DeepCopy(objViewModel.ContactInfo, eachMember.ContactInformation);

                PersonsPart.DeepCopy(objViewModel.Person, eachMember.Person);

                colMembers.Add(objViewModel);
            }

            objMembersDirectoryViewModel.Members = colMembers;

            return View("List.IndividualMembers", objMembersDirectoryViewModel);
        }


        public ActionResult Reports()
        {
            ListIndividualMembersViewModel objListIndividualMembersViewModel = new ListIndividualMembersViewModel();

            var allMembers = _memberService.GetAllMembers();
            List<MembersViewModel> colMembers = new List<MembersViewModel>();

            foreach (MembersPart eachMember in allMembers)
            {

                var contactInformation = _contactInformationService.Get(eachMember.ContactInformationId);

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