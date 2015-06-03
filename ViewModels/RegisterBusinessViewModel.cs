using WAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WAA.ViewModels
{
    public class RegisterBusinessViewModel : BaseViewModel, IBusinessRecored
    {
        public RegisterBusinessViewModel()
        {
            this.Person = new PersonViewModel();
            this.Address = new AddressViewModel();
            this.ContactInfo = new ContactInformationViewModel();
            this.RenewalOn = System.DateTime.UtcNow;
            this.Category = new List<CategoryViewModel>();
            this.States = new List<States>();
            this.Description = string.Empty;
            this.WebsiteUrl = string.Empty;
            this.CompanyName = string.Empty;
            this.ContactInformationId = 0;
            this.AddressId = 0;
            this.PersonId = 0;
            this.Id = 0;

        }

        public int Id { get; set; }

        public int ContactInformationId { get; set; }

        public int AddressId { get; set; }

        public int PersonId { get; set; }


        public string CompanyName { get; set; }

        [DefaultValue("")]
        public string Description { get; set; }
                
        [DefaultValue("")]
        public string WebsiteUrl { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public DateTime RenewalOn { get; set; }

        public PersonViewModel Person {get; set;}
        public AddressViewModel Address { get; set; }
        public ContactInformationViewModel ContactInfo { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }

        public IEnumerable<States> States { get; set; }



    }
}