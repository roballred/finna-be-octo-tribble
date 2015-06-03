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

        public BusinessController(IOrchardServices orchardServices,
            ITaxonomyService taxonomyService,
            IBusinessService objIBusinessService)
            : base(orchardServices)
        {
            _taxonomyService = taxonomyService;
            m_objIBusinessService = objIBusinessService;
        }
        // GET: Business
        public ActionResult Index()
        {
            return View();
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
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            BusniessDirectoryViewModel objBusniessDirectoryViewModel = new BusniessDirectoryViewModel();

            var businessParts = m_objIBusinessService.GetAllBusinesses();
            foreach(BusinessPart eachBusiness in businessParts)
            {
                BusinessViewModel businessViewModel = new BusinessViewModel();
                BusinessPart.DeepCopy(businessViewModel, eachBusiness);

                ContactInformationPart.Copy(businessViewModel.ContactInfo, eachBusiness.ContactInformation);

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

    }
}