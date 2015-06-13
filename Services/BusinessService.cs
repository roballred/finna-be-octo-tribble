using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Taxonomies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;

namespace WAA.Services
{

    public interface IBusinessService : IDependency
    {
        BusinessPart Get(int Id);
        IEnumerable<BusinessPart> GetAllBusinesses();
        BusinessPart Factory();
    }


    public class BusinessService : IBusinessService
    {

                
        private readonly IRepository<Business> m_objBusinessRepository;

        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;
        public BusinessService(IOrchardServices services,
            ITaxonomyService taxonomyService,
            IRepository<Business> objBusinessRepository)
        {
            _orchardServices = services;
            _taxonomyService = taxonomyService;
            m_objBusinessRepository = objBusinessRepository;
        }

        ///-------------------------------------------------------------------------
        /// <summary>
        /// Factory
        /// </summary>
        /// 
        public BusinessPart Factory()
        {
            var objServiceItem = _orchardServices.ContentManager.New("BusinessServiceItem");

            _orchardServices.ContentManager.Create(objServiceItem, VersionOptions.Published);

            var objBusinessPart = objServiceItem.As<BusinessPart>();

            return objBusinessPart;

        }

        public IEnumerable<BusinessPart> GetAllBusinesses()
        {

            return _orchardServices.ContentManager.Query<BusinessPart, Business>().List();
        }

        public BusinessPart Get(int Id)
        {
            return _orchardServices.ContentManager.Query<BusinessPart, Business>().Where(x=>x.Id == Id).List().FirstOrDefault();
        }

    }
}