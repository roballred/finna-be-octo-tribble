using WAA.Services;
using WAA.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;
using Orchard.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WAA.Controllers
{
    public class IndividualRegistrationDataController : ApiController
    {
                
        private readonly IAddressesService m_objAddressesService;
        private readonly IMembersService m_objMembersService;
        private readonly IOrchardServices _orchardServices;
        private readonly ITaxonomyService _taxonomyService;
        private readonly IMembershipService _membershipService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMemberLookupService m_objMemberLookupService;



        public IndividualRegistrationDataController(IOrchardServices orchardServices,
            IAuthenticationService authenticationService,
            IAddressesService objAddressesService,
            IMembersService objMembersService,
            IMembershipService membershipService,
            ITaxonomyService taxonomyService,
            IMemberLookupService objMemberLookupService)
            
        {
            _authenticationService = authenticationService;
            m_objAddressesService = objAddressesService;
            m_objMembersService = objMembersService;
            _membershipService = membershipService;
            _taxonomyService = taxonomyService;
            _orchardServices = orchardServices;
            m_objMemberLookupService = objMemberLookupService;

        }



        [HttpPost]
        public HttpResponseMessage Post()
        {

            var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            string szMessageBody = Request.Content.ReadAsStringAsync().Result;

            RegisterIndividualViewModel objRegisterViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterIndividualViewModel>(szMessageBody);

            if (objRegisterViewModel != null)
            {
                //register the users with orchard
                var registrationSettings = _orchardServices.WorkContext.CurrentSite.As<RegistrationSettingsPart>();

                var user = _membershipService.CreateUser(new CreateUserParams(objRegisterViewModel.ContactInfo.EmailAddress, objRegisterViewModel.Password, objRegisterViewModel.ContactInfo.EmailAddress, null, null, false));
                if(user != null)
                {
                    _authenticationService.SignIn(user, false /* createPersistentCookie */);
                    var member = m_objMembersService.Factory();
                    member.Person.Copy(objRegisterViewModel.Person);
                    member.Address.Copy(objRegisterViewModel.Address);
                    member.ContactInformation.Copy(objRegisterViewModel.ContactInfo);

                    var userLookup = m_objMemberLookupService.Factory(objRegisterViewModel.ContactInfo.EmailAddress);
                    userLookup.MemberId = member.Id;
                    var memberTermPart = member.ContentItem.As<TermsPart>();
                    var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategory");

                    if (memberTermPart != null && taxonomy != null)
                    {
                        var categoriesSelected = objRegisterViewModel.Category.Where(x => x.isSelected == true).ToList();
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

                    response = Request.CreateResponse(HttpStatusCode.OK);

                }

            }


            return response;
        }

    }
}