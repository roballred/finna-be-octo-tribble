using WAA.Models;
using Orchard.Taxonomies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class RegisterIndividualViewModel : BaseViewModel, IMembers
    {

        public RegisterIndividualViewModel()
        {
            this.RenewalOn = DateTime.UtcNow;

            this.Person = new PersonViewModel();
            this.Address = new AddressViewModel();
            this.ContactInfo = new ContactInformationViewModel();
            this.Password = string.Empty;
            this.ConfirmPassword = string.Empty;
            this.Id = 0;
            this.AddressId = 0;
            this.ContactInformationId = 0;
            this.PersonId = 0;
        }

        public int Id { get; set; }

        public int ContactInformationId { get; set; }

        public int AddressId { get; set; }

        public int PersonId { get; set; }

        public DateTime RenewalOn { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public PersonViewModel Person {get; set;}
        public AddressViewModel Address { get; set; }
        public ContactInformationViewModel ContactInfo { get; set; }

        public IEnumerable<CategoryViewModel> Category { get; set; }

        public IEnumerable<States> States { get; set; }

    }
}