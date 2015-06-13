using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class MembersDirectoryViewModel
    {

        public MembersDirectoryViewModel()
        {
            this.Members = new List<MembersViewModel>();
        }


        public List<MembersViewModel> Members { get; set; }
    }
}