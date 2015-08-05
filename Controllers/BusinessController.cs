using Orchard;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;
using Orchard.ContentManagement;
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
    public class BusinessController : BaseController
    {
        private readonly ITaxonomyService _taxonomyService;
        private readonly IBusinessService m_objIBusinessService;
        private readonly IContactInformationService m_objContactInformationService;
        private readonly IAddressesService m_objAddressesService;
        private readonly IMemberLookupService m_objMemberLookupService;

        public BusinessController(IOrchardServices orchardServices,
            ITaxonomyService taxonomyService,
            IBusinessService objIBusinessService,
            IContactInformationService objContactInformationService,
            IAddressesService objAddressesService,
            IMemberLookupService objMemberLookupService)
            : base(orchardServices)
        {
            _taxonomyService = taxonomyService;
            m_objIBusinessService = objIBusinessService;
            m_objContactInformationService = objContactInformationService;
            m_objMemberLookupService = objMemberLookupService;
            m_objAddressesService = objAddressesService;

        }
        // GET: Business
        public ActionResult Index()
        {
            return this.Flightdeck();
        }

        [Themed]
        public ActionResult Flightdeck()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            return View("Flightdeck.Business");
        }


        [Themed]
        public ActionResult Directory()
        {
            //if (!IsAuthorized()) return new HttpUnauthorizedResult();

            BusniessDirectoryViewModel objBusniessDirectoryViewModel = new BusniessDirectoryViewModel();

            var businessParts = m_objIBusinessService.GetAllBusinesses();
            foreach(BusinessPart eachBusiness in businessParts)
            {
                BusinessViewModel businessViewModel = new BusinessViewModel();
                BusinessPart.DeepCopy(businessViewModel, eachBusiness);

                ContactInformationPart.DeepCopy(businessViewModel.ContactInfo, eachBusiness.ContactInformation);

                AddressesPart.DeepCopy(businessViewModel.Address, eachBusiness.Address);
                //ContactInformationViewModel eachBusiness.ContactInformation
                var memberTermPart = eachBusiness.ContentItem.As<TermsPart>();
                var terms = _taxonomyService.GetTermsForContentItem(memberTermPart.Id);
                foreach (TermPart eachterm in terms)
                {
                    CategoryViewModel category = new CategoryViewModel();
                    category.Name = eachterm.Name;
                    businessViewModel.Category.Add(category);
                }
                objBusniessDirectoryViewModel.Businesses.Add(businessViewModel);
            }

            var taxonomy = _taxonomyService.GetTaxonomyByName("BusinessCategories");

            if (taxonomy != null)
            {
                var terms = _taxonomyService.GetTerms(taxonomy.Id);


                foreach (TermPart eachTerm in terms)
                {
                    CategoryViewModel objCategoryViewModel = new CategoryViewModel();
                    objCategoryViewModel.Name = eachTerm.Name;
                    objBusniessDirectoryViewModel.BusinessCategories.Add(objCategoryViewModel);
                }

            }

            return View("Business.Directory", objBusniessDirectoryViewModel);
        }

        private string DirectoryJSON()
        {

            BusniessDirectoryViewModel objBusniessDirectoryViewModel = new BusniessDirectoryViewModel();

            var businessParts = m_objIBusinessService.GetAllBusinesses();
            foreach (BusinessPart eachBusiness in businessParts)
            {
                BusinessViewModel businessViewModel = new BusinessViewModel();
                BusinessPart.DeepCopy(businessViewModel, eachBusiness);

                //var contactInfo = m_objContactInformationService.Get(eachBusiness.ContactInformationId);
                //ContactInformationPart.Copy(businessViewModel.ContactInfo, contactInfo);
                ContactInformationPart.DeepCopy(businessViewModel.ContactInfo, eachBusiness.ContactInformation);

                PersonsPart.Copy(businessViewModel.Person, eachBusiness.Person);

                AddressesPart.Copy(businessViewModel.Address, eachBusiness.Address);

                //ContactInformationViewModel eachBusiness.ContactInformation
                var memberTermPart = eachBusiness.ContentItem.As<TermsPart>();
                var terms = _taxonomyService.GetTermsForContentItem(memberTermPart.Id);
                foreach (TermPart eachterm in terms)
                {
                    CategoryViewModel category = new CategoryViewModel();
                    category.Name = eachterm.Name;
                    businessViewModel.Category.Add(category);
                }
                objBusniessDirectoryViewModel.Businesses.Add(businessViewModel);
            }

            var taxonomy = _taxonomyService.GetTaxonomyByName("BusinessCategories");

            if (taxonomy != null)
            {
                var terms = _taxonomyService.GetTerms(taxonomy.Id);


                foreach (TermPart eachTerm in terms)
                {
                    CategoryViewModel objCategoryViewModel = new CategoryViewModel();
                    objCategoryViewModel.Name = eachTerm.Name;
                    objBusniessDirectoryViewModel.BusinessCategories.Add(objCategoryViewModel);
                }

            }


            return Newtonsoft.Json.JsonConvert.SerializeObject(objBusniessDirectoryViewModel);

        }


        [Themed]
        public ActionResult Edit()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            var memberId = m_objMemberLookupService.FindBusiness();
            return this.EditProfile(memberId);
        }

        [Themed]
        public ActionResult EditProfile(int Id)
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            RegisterBusinessViewModel objRegisterBusinessViewModel = new RegisterBusinessViewModel();
            var businessMember = m_objIBusinessService.Get(Id);
            BusinessPart.DeepCopy(objRegisterBusinessViewModel, businessMember);
            PersonsPart.DeepCopy(objRegisterBusinessViewModel.Person, businessMember.Person);
            AddressesPart.DeepCopy(objRegisterBusinessViewModel.Address, businessMember.Address);

            ContactInformationPart.DeepCopy(objRegisterBusinessViewModel.ContactInfo, businessMember.ContactInformation);

            objRegisterBusinessViewModel.States = m_objAddressesService.GetStates();

            objRegisterBusinessViewModel.PostBackUrl = Url.HttpRouteUrl("MembershipRoute", new { controller = "EditBusinessData" });
            objRegisterBusinessViewModel.RedirectUrl = Url.Action("Flightdeck", "Business", new { area = "WAA" });


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



            return View("User.EditBusinessMember", objRegisterBusinessViewModel);
        }


        [Themed]
        public ActionResult Details(int Id)
        {
            BusinessDetailsViewModel objBusinessDetailsViewModel = new BusinessDetailsViewModel();
            var businessData = m_objIBusinessService.Get(Id);

            if (businessData != null)
            {
                BusinessPart.DeepCopy(objBusinessDetailsViewModel, businessData);
            }

            return View("Business.Details", objBusinessDetailsViewModel);
        }


    }
}