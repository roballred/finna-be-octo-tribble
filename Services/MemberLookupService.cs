using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;

namespace WAA.Services
{
    public interface IMemberLookupService : IDependency
    {
        int FindMember(string szEmail);
        int FindBusiness(string szEmail);
        MemberLookupPart Factory(string szEmail);
    }

    public class MemberLookupService : IMemberLookupService
    {

        private IOrchardServices _orchardServices;
        private readonly IRepository<MemberLookup> m_objLookupRepository;

        public MemberLookupService(IOrchardServices orchardServices,
            IRepository<MemberLookup> objLookupRepository)
        {
            _orchardServices = orchardServices;
            m_objLookupRepository = objLookupRepository;
        }

        public int FindMember(string szEmail)
        {
            int nResult = -1;
            try
            {
                var objUserLookup = m_objLookupRepository.Fetch(record => record.EmailAddress == szEmail).FirstOrDefault();
                if (objUserLookup != null)
                {
                    nResult = objUserLookup.MemberId;
                }

            }
            catch { }

            return nResult;
        }

        public int FindBusiness(string szEmail)
        {
            int nResult = -1;
            try
            {
                var objUserLookup = m_objLookupRepository.Fetch(record => record.EmailAddress == szEmail).FirstOrDefault();
                if (objUserLookup != null)
                {
                    nResult = objUserLookup.BusinessId;
                }

            }
            catch{ }

            return nResult;

        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Factory
        /// </summary>
        /// 
        public MemberLookupPart Factory(string szEmail)
        {
            var objMemberLookupServiceItem = _orchardServices.ContentManager.New("MemberLookupServiceItem");

            _orchardServices.ContentManager.Create(objMemberLookupServiceItem, VersionOptions.Published);

            var objMemberLookupPart = objMemberLookupServiceItem.As<MemberLookupPart>();

            objMemberLookupPart.EmailAddress = szEmail;

            return objMemberLookupPart;

        }

    }
}