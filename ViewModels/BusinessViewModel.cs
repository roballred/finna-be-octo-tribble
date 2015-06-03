using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;

namespace WAA.ViewModels
{
    public class BusinessViewModel : IBusinessRecored
    {
        public BusinessViewModel()
        {
            this.Address = new AddressViewModel();
            this.Person = new PersonViewModel();
            this.ContactInfo = new ContactInformationViewModel();
            this.CompanyName = string.Empty;
            this.Description = string.Empty;
            this.Url = string.Empty;
            this.Category = new List<CategoryViewModel>();
        }

        public AddressViewModel Address { get; set; }
        public PersonViewModel Person { get; set; }
        public ContactInformationViewModel ContactInfo { get; set; }

        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public List<CategoryViewModel> Category { get; set; }



        public int Id { get; set; }

        public int ContactInformationId { get; set; }

        public int AddressId { get; set; }

        public int PersonId { get; set; }

        public string WebsiteUrl { get; set; }

        public DateTime RenewalOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}