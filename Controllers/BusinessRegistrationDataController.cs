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
    public class BusinessRegistrationDataController : ApiController
    {

                
        private readonly IAddressesService m_objAddressesService;
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;
        private IBusinessService m_objBusinessService;
        private readonly IMembershipService _membershipService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMemberLookupService m_objMemberLookupService;



        public BusinessRegistrationDataController(IOrchardServices orchardServices,
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

                var user = _membershipService.CreateUser(new CreateUserParams(objRegisterBusinessViewModel.ContactInfo.EmailAddress, objRegisterBusinessViewModel.Password, objRegisterBusinessViewModel.ContactInfo.EmailAddress, null, null, false));
                if (user != null)
                {
                    _authenticationService.SignIn(user, false /* createPersistentCookie */);

                    var businessMember = m_objBusinessService.Factory();
                    BusinessPart.MapData(businessMember, objRegisterBusinessViewModel);
                    businessMember.Person.Copy(objRegisterBusinessViewModel.Person);
                    businessMember.Address.Copy(objRegisterBusinessViewModel.Address);
                    //businessMember.ContactInformation.Copy(objRegisterBusinessViewModel.ContactInfo);
                    ContactInformationPart.Copy(businessMember.ContactInformation, objRegisterBusinessViewModel.ContactInfo);


                    var userLookup = m_objMemberLookupService.Factory(objRegisterBusinessViewModel.ContactInfo.EmailAddress);
                    userLookup.BusinessId = businessMember.Id;
                    
                    var memberTermPart = businessMember.ContentItem.As<TermsPart>();
                    var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategory");

                    if(memberTermPart != null && taxonomy != null)
                    {
                        var categoriesSelected = objRegisterBusinessViewModel.Category.Where(x => x.isSelected == true).ToList();
                        var terms = _taxonomyService.GetTerms(taxonomy.Id);

                        foreach (CategoryViewModel eachCategory in categoriesSelected)
                        {
                            var term = terms.Where(x => x.Name == eachCategory.Name).ToList().FirstOrDefault();

                            memberTermPart.Terms.Add(new TermContentItem
                            {
                                TermsPartRecord = memberTermPart.Record,
                                TermRecord = term.Record,
                                Field = term.Name
                            });

                        }

                    }

                }


            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}
