using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class MembersViewModel : BaseViewModel
    {

        public MembersViewModel()
        {
            this.Person = new PersonViewModel();
            this.ContactInfo = new ContactInformationViewModel();
            this.Address = new AddressViewModel();

        }
        public PersonViewModel Person{ get; set;}

        public ContactInformationViewModel ContactInfo { get; set; }

        public AddressViewModel Address { get; set; }
    }
}