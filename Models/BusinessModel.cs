using Orchard.ContentManagement;
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
    public class Business : ContentPartRecord
    {
        public Business()
        {
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;
            this.RenewalOn = DateTime.UtcNow;

            this.CompanyName = string.Empty;
            this.Description = string.Empty;
            this.WebsiteUrl = string.Empty;

        }

        public virtual int ContactInformationId { get; set; }

        public virtual int AddressId { get; set; }

        public virtual int PersonId { get; set; }

        public virtual string CompanyName { get; set; }
        public virtual string Description { get; set; }
        public virtual string WebsiteUrl { get; set; }

        public virtual DateTime RenewalOn { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }

    }

    public class BusinessPart : ContentPart<Business>
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



        public int ContactId
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
        public string WebsiteUrl
        {
            get { return Record.WebsiteUrl; }
            set { Record.WebsiteUrl = value; }
        }


        public void Copy(RegisterBusinessViewModel objRegisterBusinessViewModel)
        {
            this.CompanyName = objRegisterBusinessViewModel.CompanyName;
            this.Description = objRegisterBusinessViewModel.Description;
            this.WebsiteUrl = objRegisterBusinessViewModel.WebsiteUrl;
            this.RenewalOn = objRegisterBusinessViewModel.RenewalOn;
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
                var contactsContentItem = _contentManager.Get<ContactInformationPart>(part.Record.ContactInformationId);

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