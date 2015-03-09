using AREA.Membership.Services;
using AREA.Membership.ViewModels;
using Orchard;
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
            string szMessageBody = Request.Content.ReadAsStringAsync().Result;

            RegisterIndividualViewModel objRegisterProducerViewModel = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterIndividualViewModel>(szMessageBody);

            if (objRegisterProducerViewModel != null)
            {
                var member = m_objMembersService.Factory();
                member.Person.Copy(objRegisterProducerViewModel.Person);
                member.Address.Copy(objRegisterProducerViewModel.Address);
                member.ContactInformation.Copy(objRegisterProducerViewModel.ContactInfo);

                //save taxonomy


                //IUser userItem = _orchardServices.WorkContext.CurrentUser;
                //if (userItem is IUser)
                //{
                //    var test = userItem.Email;
                //}

            }


            return Request.CreateResponse(HttpStatusCode.ExpectationFailed);
        }

    }
}