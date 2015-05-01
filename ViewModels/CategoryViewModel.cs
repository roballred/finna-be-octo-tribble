using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.Name = string.Empty;
            this.isSelected = false;
            this.TaxonomyId = 0;
        }
        public string Name {get; set;}


        public bool isSelected { get; set; }


        public int TaxonomyId { get; set; }



    }
}