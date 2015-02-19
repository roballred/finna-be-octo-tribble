using Orchard;
using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.Services
{

    ///-------------------------------------------------------------------------
    /// <summary>
    /// IPersonService
    /// </summary>
    /// 
    public interface IPersonService : IDependency
    {

    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// PersonService
    /// </summary>
    /// 
    public class PersonService : IPersonService
    {

        private IOrchardServices _orchardServices;


        ///-------------------------------------------------------------------------
        /// <summary>
        /// PersonService
        /// </summary>
        /// 
        public PersonService(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
        }


    }
}