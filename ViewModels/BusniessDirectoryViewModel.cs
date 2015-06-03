using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class BusniessDirectoryViewModel
    {

        public BusniessDirectoryViewModel()
        {
            this.Businesses = new List<BusinessViewModel>();
            this.BusinessCategories = new List<CategoryViewModel>();
        }
        public List<BusinessViewModel> Businesses { get; set; }
        public List<CategoryViewModel> BusinessCategories { get; set; }

    }

}