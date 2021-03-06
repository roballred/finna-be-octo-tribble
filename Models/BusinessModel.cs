﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.Core.Common.Utilities;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.ViewModels;

namespace WAA.Models
{
    public interface IBusinessRecored
    {
        int Id { get; set; }
        int ContactInformationId { get; set; }

        int AddressId { get; set; }

        int PersonId { get; set; }

        string CompanyName { get; set; }
        string Description { get; set; }
        string Keywords { get; set; }
        string WebsiteUrl { get; set; }

        DateTime RenewalOn { get; set; }

        DateTime ModifiedOn { get; set; }

        DateTime CreatedOn { get; set; }

    }
    public class Business : ContentPartRecord, IBusinessRecored
    {
        public Business()
        {
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;
            this.RenewalOn = DateTime.UtcNow;

            this.CompanyName = string.Empty;
            this.Description = string.Empty;
            this.Keywords = string.Empty;
            this.WebsiteUrl = string.Empty;
            this.ContactInformationId = 0;
            this.AddressId = 0;
            this.PersonId = 0;


        }

        public virtual int ContactInformationId { get; set; }

        public virtual int AddressId { get; set; }

        public virtual int PersonId { get; set; }

        public virtual string CompanyName { get; set; }
        public virtual string Description { get; set; }
        public virtual string Keywords { get; set; }
        public virtual string WebsiteUrl { get; set; }

        public virtual DateTime RenewalOn { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }

    }

    public class BusinessPart : ContentPart<Business>, IBusinessRecored
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


        public string CompanyName
        {
            get { return Record.CompanyName; }
            set { Record.CompanyName = value; }
        }
        public string Description
        {
            get { return Record.Description; }
            set { Record.Description = value; }
        }

        public string Keywords
        {
            get { return Record.Keywords; }
            set { Record.Keywords = value; }
        }

        public string WebsiteUrl
        {
            get { return Record.WebsiteUrl; }
            set { Record.WebsiteUrl = value; }
        }

        int IBusinessRecored.Id
        {
            get { return Record.Id; }
            set {  }
        }

        public static void DeepCopy(IBusinessRecored dest, IBusinessRecored src)
        {
            dest.Id = src.Id;
            BusinessPart.Copy(dest, src);
        }

        public static void Copy(IBusinessRecored dest, IBusinessRecored src)
        {
            dest.ContactInformationId = src.ContactInformationId;
            dest.AddressId = src.AddressId;
            dest.PersonId = src.PersonId;
            BusinessPart.MapData(dest, src);
        }
        public static void MapData(IBusinessRecored dest, IBusinessRecored src)
        {

            dest.ModifiedOn = src.ModifiedOn;
            dest.CreatedOn = src.CreatedOn;
            dest.RenewalOn = src.RenewalOn;

            dest.CompanyName = src.CompanyName;
            dest.Description = src.Description;
            Uri objUri = null;
            Uri.TryCreate(src.WebsiteUrl, UriKind.Absolute, out objUri);
            if (objUri is Uri)
            {
                dest.WebsiteUrl = objUri.AbsoluteUri;
            }

            //dest.WebsiteUrl = src.WebsiteUrl;
            dest.Keywords = src.Keywords;
        }



    }

    public class BusinessHandler : ContentHandler
    {
        private IContentManager _contentManager;


        public BusinessHandler(IRepository<Business> repository, IContentManager contentManager)
        {
            _contentManager = contentManager;
            Filters.Add(StorageFilter.For(repository));
            OnActivated<BusinessPart>(SetupBusiness);
        }



        private void SetupBusiness(ActivatedContentContext context, BusinessPart part)
        {

            part.AddressField.Loader(() =>
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


            part.ContactInformationField.Loader(() =>
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


            part.PersonField.Loader(() =>
            {
                var personItem = _contentManager.Get<PersonsPart>(part.Record.PersonId);
                //var personItem = _contentManager.Query<PersonsPart, Persons>().Where(x => x.Id == part.Record.PersonId).List().FirstOrDefault();
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