using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Models
{
    public class MemberLookup : ContentPartRecord
    {

        public MemberLookup()
        {
            this.BusinessId = 0;
            this.MemberId = 0;
            this.EmailAddress = string.Empty;
        }
        public virtual int MemberId { get; set; }
        public virtual int BusinessId { get; set; }
        public virtual string EmailAddress { get; set; }


    }

    public class MemberLookupPart : ContentPart<MemberLookup>
    {
        public int MemberId
        {

            get { return Record.MemberId; }
            set { Record.MemberId = value; }
        }
        public int BusinessId
        {

            get { return Record.BusinessId; }
            set { Record.BusinessId = value; }
        }
        public string EmailAddress
        {

            get { return Record.EmailAddress; }
            set { Record.EmailAddress = value; }
        }


    }

    public class MemberLookupHandler : ContentHandler
    {

        public MemberLookupHandler(IRepository<MemberLookup> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }

    }
}