using WAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WAA.ViewModels
{
    public class RegisterBusinessViewModel : BaseViewModel
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

        }

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

        public void Copy(BusinessPart objBusinessPart)
        {
            this.CompanyName = objBusinessPart.CompanyName;
            this.Description = objBusinessPart.Description;
            this.WebsiteUrl = objBusinessPart.WebsiteUrl;
            this.RenewalOn = objBusinessPart.RenewalOn;
        }

    }
}