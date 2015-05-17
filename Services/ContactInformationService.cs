using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.Data;
using WAA.Models;

namespace WAA.Services
{
    ///-------------------------------------------------------------------------
    /// <summary>
    /// IContactInformationService
    /// </summary>
    /// 
    public interface IContactInformationService : IDependency
    {
        ContactInformationPart Get(int Id);
    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// ContactInformationService
    /// </summary>
    /// 
    public class ContactInformationService : IContactInformationService
    {
        private IOrchardServices _orchardServices;

        public ContactInformationService(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
        }

        public ContactInformationPart Get(int Id)
        {
            return _orchardServices.ContentManager.Query<ContactInformationPart, ContactInformation>().Where(x => x.Id == Id).List().FirstOrDefault();

        }

    }
}