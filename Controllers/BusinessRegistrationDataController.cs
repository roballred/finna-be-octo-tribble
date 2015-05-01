using WAA.Services;
using WAA.ViewModels;
using Orchard;
using Orchard.Taxonomies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WAA.Controllers
{
    public class BusinessRegistrationDataController : ApiController
    {

                private readonly IAddressesService m_objAddressesService;
        private readonly IMembersService m_objMembersService;
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;


        public BusinessRegistrationDataController(IOrchardServices orchardServices,
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
            string szMessageBody = Request.Content.ReadAsStringAsync().Result;

            RegisterBusinessViewModel objRegisterProducerViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterBusinessViewModel>(szMessageBody);

            if (objRegisterProducerViewModel != null)
            {
                var member = m_objMembersService.Factory();
                member.Person.Copy(objRegisterProducerViewModel.Person);
                member.Address.Copy(objRegisterProducerViewModel.Address);
                member.ContactInformation.Copy(objRegisterProducerViewModel.ContactInfo);


            }


            return Request.CreateResponse(HttpStatusCode.OK);
        }



    }
}
