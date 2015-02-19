using AREA.Membership.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.Services
{

    ///-------------------------------------------------------------------------
    /// <summary>
    /// IAddressesService
    /// </summary>
    /// 
    public interface IAddressesService : IDependency
    {
        IEnumerable<States> GetStates();
    }

    ///-------------------------------------------------------------------------
    /// <summary>
    /// AddressesService
    /// </summary>
    /// 
    public class AddressesService : IAddressesService, IDependency
    {
        private readonly IRepository<States> _stateRepository;

        private IOrchardServices _orchardServices;

        public AddressesService(IOrchardServices orchardServices,
            IRepository<States> stateRepository)
        {
            _orchardServices = orchardServices;
            _stateRepository = stateRepository;
        }

        ///-------------------------------------------------------------------------
        /// <summary>
        /// GetStates
        /// </summary>
        /// 
        public IEnumerable<States> GetStates()
        {
            return _stateRepository.Table.ToList();
        }
    }
}