﻿
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement.Utilities;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WAA.Models
{


    public interface IMembers
    {
        int Id { get; set; }

        int ContactInformationId { get; set; }

        int AddressId { get; set; }

        int PersonId { get; set; }

        DateTime RenewalOn { get; set; }

        DateTime ModifiedOn { get; set; }

        DateTime CreatedOn { get; set; }

    }

    ///-------------------------------------------------------------------------
    /// <summary>
    /// Members
    /// </summary>
    /// 
    public class Members : ContentPartRecord, IMembers
    {
        public Members()
        {
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;
            this.RenewalOn = DateTime.UtcNow;

            this.ContactInformationId = 0;
            this.AddressId = 0;
            this.PersonId = 0;
        }

        public virtual int ContactInformationId { get; set; }

        public virtual int AddressId { get; set; }

        public virtual int PersonId { get; set; }

        public virtual DateTime RenewalOn { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }
    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// MembersPart
    /// </summary>
    /// 
    public class MembersPart : ContentPart<Members>, IMembers
    {

        internal readonly LazyField<AddressesPart> AddressField = new LazyField<AddressesPart>();
        internal readonly LazyField<ContactInformationPart> ContactInformationField = new LazyField<ContactInformationPart>();
        internal readonly LazyField<PersonsPart> PersonField = new LazyField<PersonsPart>();


        public AddressesPart Address
        {
            get { return AddressField.Value; }
            set { AddressField.Value = value; }
        }

        public ContactInformationPart ContactInformation
        {
            get { return ContactInformationField.Value; }
            set { ContactInformationField.Value = value; }
        }

        public PersonsPart Person
        {
            get { return PersonField.Value; }
            set { PersonField.Value = value; }
        }



        public int ContactInformationId
        {
            get { return Record.ContactInformationId; }
            set { Record.ContactInformationId = value; }
        }

        public int AddressId
        {
            get { return Record.AddressId; }
            set { Record.AddressId = value; }
        }

        public int PersonId
        {
            get { return Record.PersonId; }
            set { Record.PersonId = value; }
        }


        public DateTime RenewalOn
        {
            get { return Record.RenewalOn; }
            set { Record.RenewalOn = value; }
        }

        public DateTime ModifiedOn
        {
            get { return Record.ModifiedOn; }
            set { Record.ModifiedOn = value; }
        }

        public DateTime CreatedOn
        {
            get { return Record.CreatedOn; }
            set { Record.CreatedOn = value; }
        }

        int IMembers.Id
        {
            get { return Record.Id; }
            set {  }
        }


        public static void DeepCopy(IMembers dest, IMembers src)
        {
            dest.Id = src.Id;
            MembersPart.Copy(dest, src);
        }

        public static void Copy(IMembers dest, IMembers src)
        {
            dest.ContactInformationId = src.ContactInformationId;
            dest.AddressId = src.AddressId;
            dest.PersonId = src.PersonId;
            MembersPart.MapData(dest, src);
        }
        public static void MapData(IMembers dest, IMembers src)
        {

            dest.ModifiedOn = src.ModifiedOn;
            dest.CreatedOn = src.CreatedOn;
            dest.RenewalOn = src.RenewalOn;


        }

    }


    public class MembersHandler : ContentHandler
    {
        private IContentManager _contentManager;


        public MembersHandler(IRepository<Members> repository, IContentManager contentManager)
        {
            _contentManager = contentManager;
            Filters.Add(StorageFilter.For(repository));
            OnActivated<MembersPart>(SetupMember);
        }



        private void SetupMember(ActivatedContentContext context, MembersPart part)
        {

            part.AddressField.Loader(address =>
            {
                var addressContentItem = _contentManager.Get<AddressesPart>(part.Record.AddressId);

                if (addressContentItem == null)
                {
                    addressContentItem = _contentManager.Create<AddressesPart>("AddressServiceItem", VersionOptions.Published);
                    part.Record.AddressId = addressContentItem.Id;
                }
                return addressContentItem;


            });

            part.AddressField.Setter(address =>
            {
                part.Record.AddressId = address != null ? address.Id : default(int);
                return address;
            });


            part.ContactInformationField.Loader(contact =>
            {
                //var contactsContentItem = _contentManager.Get<ContactInformationPart>(part.Record.ContactInformationId);
                var contactsContentItem = _contentManager.Query<ContactInformationPart, ContactInformation>().Where(x => x.Id == part.Record.ContactInformationId).List().FirstOrDefault();

                if (contactsContentItem == null)
                {
                    contactsContentItem = _contentManager.Create<ContactInformationPart>("ContactInformationServiceItem", VersionOptions.Published);
                    part.Record.ContactInformationId = contactsContentItem.Id;
                }
                return contactsContentItem;


            });

            part.ContactInformationField.Setter(contact =>
            {
                part.Record.ContactInformationId = contact != null ? contact.Id : default(int);
                return contact;
            });


            part.PersonField.Loader(person =>
            {
                var personItem = _contentManager.Get<PersonsPart>(part.Record.PersonId);

                if (personItem == null)
                {
                    personItem = _contentManager.Create<PersonsPart>("PersonServiceItem", VersionOptions.Published);
                    part.Record.PersonId = personItem.Id;
                }
                return personItem;


            });

            part.PersonField.Setter(person =>
            {
                part.Record.PersonId = person != null ? person.Id : default(int);
                return person;
            });


        }
    }


}