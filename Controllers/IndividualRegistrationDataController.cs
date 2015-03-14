using AREA.Membership.Services;
using AREA.Membership.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AREA.Membership.Controllers
{
    public class IndividualRegistrationDataController : ApiController
    {
                
        private readonly IAddressesService m_objAddressesService;
        private readonly IMembersService m_objMembersService;
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;


        public IndividualRegistrationDataController(IOrchardServices orchardServices,
            IAddressesService objAddressesService,
            IMembersService objMembersService,
            ITaxonomyService taxonomyService)
            
        {
            m_objAddressesService = objAddressesService;
            m_objMembersService = objMembersService;
            _taxonomyService = taxonomyService;
            _orchardServices = orchardServices;

        }



        [HttpPost]
        public HttpResponseMessage Post()
        {
            var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            string szMessageBody = Request.Content.ReadAsStringAsync().Result;

            RegisterIndividualViewModel objRegisterProducerViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterIndividualViewModel>(szMessageBody);

            if (objRegisterProducerViewModel != null)
            {
                var member = m_objMembersService.Factory();
                member.Person.Copy(objRegisterProducerViewModel.Person);
                member.Address.Copy(objRegisterProducerViewModel.Address);
                member.ContactInformation.Copy(objRegisterProducerViewModel.ContactInfo);

                var memberTermPart = member.ContentItem.As<TermsPart>();
                var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategory");

                var categoriesSelected = objRegisterProducerViewModel.Category.Where(x => x.isSelected == true).ToList();
                //var terms = _taxonomyService.GetTermsForContentItem(objServiceItem.Id, "Category").ToList();
                var terms = _taxonomyService.GetTerms(taxonomy.Id);

                foreach(CategoryViewModel eachCategory in categoriesSelected)
                {

                    var term = terms.Where(x => x.Name == eachCategory.Name).ToList().FirstOrDefault();

                    memberTermPart.Terms.Add(new TermContentItem
                    {
                        TermsPartRecord = memberTermPart.Record,
                        TermRecord = term.Record,
                        Field = term.Name
                    });

                }

                //save taxonomy
                //var taxonomy = _taxonomyService.GetTaxonomyByName("Category");
                //var terms = taxonomy.Terms;

                //var memberTaxonomy = member.ContentItem.As<TermsField>();
                //IUser userItem = _orchardServices.WorkContext.CurrentUser;
                //if (userItem is IUser)
                //{
                //    var test = userItem.Email;
                //}
                response = Request.CreateResponse(HttpStatusCode.OK);
            }


            return response;
        }

    }
}