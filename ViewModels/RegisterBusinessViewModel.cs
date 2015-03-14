using AREA.Membership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.ViewModels
{
    public class RegisterBusinessViewModel : BaseViewModel
    {
        public RegisterBusinessViewModel()
        {
            this.Person = new PersonViewModel();
            this.Address = new AddressViewModel();
            this.ContactInfo = new ContactInformationViewModel();
        }
        public PersonViewModel Person {get; set;}
        public AddressViewModel Address { get; set; }
        public ContactInformationViewModel ContactInfo { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }

        public IEnumerable<States> States { get; set; }

    }
}