using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;
using System.Runtime.Serialization;

namespace WAA.ViewModels
{
    [DataContract]
    public class BusinessViewModel : IBusinessRecored
    {
        public BusinessViewModel()
        {
            this.Address = new AddressViewModel();
            this.Person = new PersonViewModel();
            this.ContactInfo = new ContactInformationViewModel();
            this.CompanyName = string.Empty;
            this.Description = string.Empty;
            this.Keywords = string.Empty;
            this.Url = string.Empty;
            this.Category = new List<CategoryViewModel>();
        }

        [DataMember]
        public AddressViewModel Address { get; set; }
        [DataMember]
        public PersonViewModel Person { get; set; }
        [DataMember]
        public ContactInformationViewModel ContactInfo { get; set; }

        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Keywords { get; set; }
        [DataMember]
        public string Url { get; set; }

        public List<CategoryViewModel> Category { get; set; }



        [DataMember]
        public int Id { get; set; }


        public int ContactInformationId { get; set; }

        public int AddressId { get; set; }

        public int PersonId { get; set; }

        [DataMember]
        public string WebsiteUrl { get; set; }

        [DataMember]
        public DateTime RenewalOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}