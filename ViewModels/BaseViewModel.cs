using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            this.CreatedOn = System.DateTime.UtcNow;
            this.ModifiedOn = System.DateTime.UtcNow;
            this.PostBackUrl = string.Empty;
            this.RedirectUrl = string.Empty;
        }
  

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PostBackUrl { get; set; }

        public string RedirectUrl { get; set; }

    }
}