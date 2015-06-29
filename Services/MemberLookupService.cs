using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;

namespace WAA.Services
{
    public interface IMemberLookupService : IDependency
    {
        int FindMember();
        int FindMember(string szEmail);
        int FindBusiness();
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

        public int FindMember()
        {
            int nResult = -1;
            try
            {
                IUser usertItem = _orchardServices.WorkContext.CurrentUser;
                if (usertItem is IUser)
                {
                    nResult = this.FindMember(usertItem.Email);
                }


            }
            catch 
            {
            }

            return nResult;
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


        public int FindBusiness()
        {
            int nResult = -1;
            try
            {
                IUser usertItem = _orchardServices.WorkContext.CurrentUser;
                if (usertItem is IUser)
                {
                    nResult = this.FindBusiness(usertItem.Email);
                }


            }
            catch
            {
            }

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
            var objUserLookup = _orchardServices.ContentManager.Query<MemberLookupPart, MemberLookup>().Where(x => x.EmailAddress == szEmail).List().FirstOrDefault();

            if(objUserLookup == null)
            {
                var objMemberLookupServiceItem = _orchardServices.ContentManager.New("MemberLookupServiceItem");

                _orchardServices.ContentManager.Create(objMemberLookupServiceItem, VersionOptions.Published);

                objUserLookup = objMemberLookupServiceItem.As<MemberLookupPart>();

                objUserLookup.EmailAddress = szEmail;

            }
            return objUserLookup;

        }

    }
}