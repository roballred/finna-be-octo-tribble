using WAA.Services;
using WAA.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Orchard.Security;
using Orchard.Taxonomies.Models;
using WAA.Models;

namespace WAA.Controllers
{
    public class EditBusinessDataController : ApiController
    {

                
        private readonly IAddressesService m_objAddressesService;
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;
        private IBusinessService m_objBusinessService;
        private readonly IMembershipService _membershipService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMemberLookupService m_objMemberLookupService;



        public EditBusinessDataController(IOrchardServices orchardServices,
            IAddressesService objAddressesService,
            IAuthenticationService authenticationService,
            IMembershipService membershipService,
            IBusinessService businessService,
            ITaxonomyService taxonomyService,
            IMemberLookupService objMemberLookupService)
            
        {
            m_objAddressesService = objAddressesService;
            m_objBusinessService = businessService;
            _taxonomyService = taxonomyService;
            _orchardServices = orchardServices;
            _authenticationService = authenticationService;
            _membershipService = membershipService;
            m_objMemberLookupService = objMemberLookupService;

        }


        [HttpPost]
        public HttpResponseMessage Post()
        {
            //return Request.CreateResponse(HttpStatusCode.OK);

            string szMessageBody = Request.Content.ReadAsStringAsync().Result;

            RegisterBusinessViewModel objRegisterBusinessViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterBusinessViewModel>(szMessageBody);

            if (objRegisterBusinessViewModel != null)
            {

                BusinessPart businessMember = null;
                if(objRegisterBusinessViewModel.Id == 0)
                {
                    businessMember = m_objBusinessService.Factory();
                    var userLookup = m_objMemberLookupService.Factory(objRegisterBusinessViewModel.ContactInfo.EmailAddress);
                    userLookup.BusinessId = businessMember.Id;
                }
                else
                {
                    businessMember = m_objBusinessService.Get(objRegisterBusinessViewModel.Id);
                }
                 
                if (businessMember != null)
                {
                    BusinessPart.MapData(businessMember, objRegisterBusinessViewModel);
                    PersonsPart.MapData(businessMember.Person, objRegisterBusinessViewModel.Person);
                    AddressesPart.MapData(businessMember.Address, objRegisterBusinessViewModel.Address);
                    ContactInformationPart.Copy(businessMember.ContactInformation, objRegisterBusinessViewModel.ContactInfo);


                    //var memberTermPart = businessMember.ContentItem.As<TermsPart>();
                    //var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategory");

                    //if (memberTermPart != null && taxonomy != null)
                    //{
                    //    var categoriesSelected = objRegisterBusinessViewModel.Category.Where(x => x.isSelected == true).ToList();
                    //    var terms = _taxonomyService.GetTerms(taxonomy.Id);

                    //    foreach (CategoryViewModel eachCategory in categoriesSelected)
                    //    {
                    //        var term = terms.Where(x => x.Name == eachCategory.Name).ToList().FirstOrDefault();

                    //        memberTermPart.Terms.Add(new TermContentItem
                    //        {
                    //            TermsPartRecord = memberTermPart.Record,
                    //            TermRecord = term.Record,
                    //            Field = term.Name
                    //        });

                    //    }

                    //}

                }


            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}
