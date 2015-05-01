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
        }
        public PersonViewModel Person{ get; set;}

    }
}