using WAA.Models;
using Orchard.Taxonomies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class RegisterIndividualViewModel : BaseViewModel
    {

        public RegisterIndividualViewModel()
        {
            this.Person = new PersonViewModel();
            this.Address = new AddressViewModel();
            this.ContactInfo = new ContactInformationViewModel();
        }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public PersonViewModel Person {get; set;}
        public AddressViewModel Address { get; set; }
        public ContactInformationViewModel ContactInfo { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }

        public IEnumerable<States> States { get; set; }
    }
}