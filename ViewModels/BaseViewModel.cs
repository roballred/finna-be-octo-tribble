using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            this.CreatedOn = System.DateTime.UtcNow;
            this.ModifiedOn = System.DateTime.UtcNow;
        }
  

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}