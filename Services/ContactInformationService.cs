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

    }
}