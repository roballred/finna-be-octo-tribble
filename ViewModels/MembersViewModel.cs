using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;

namespace WAA.ViewModels
{
    public class MembersViewModel : BaseViewModel, IMembers
    {

        public MembersViewModel()
        {
            this.Person = new PersonViewModel();
            this.ContactInfo = new ContactInformationViewModel();
            this.Address = new AddressViewModel();
            this.RenewalOn = DateTime.UtcNow;

            this.ContactInformationId = 0;
            this.AddressId = 0;
            this.PersonId = 0;

        }

        public int Id { get; set; }

        public int ContactInformationId { get; set; }

        public int AddressId { get; set; }

        public int PersonId { get; set; }

        public PersonViewModel Person{ get; set;}

        public ContactInformationViewModel ContactInfo { get; set; }

        public AddressViewModel Address { get; set; }

        public DateTime RenewalOn { get; set; }


    }
}