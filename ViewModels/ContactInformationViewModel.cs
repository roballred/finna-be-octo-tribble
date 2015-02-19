using AREA.Membership.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AREA.Membership.ViewModels
{
    public class ContactInformationViewModel : BaseViewModel
    {

        public ContactInformationViewModel()
        {
            this.CellNumber = string.Empty;
            this.EmailAddress = string.Empty;
            this.FacsimileNumber = string.Empty;
            this.HomeNumber = string.Empty;
            this.OfficeNumber = string.Empty;
            this.WebUrl = string.Empty;

        }
        public int Id { get; set; }

        public string CellNumber { get; set; }

        public string EmailAddress { get; set; }

        public string FacsimileNumber { get; set; }

        public string HomeNumber { get; set; }

        public string OfficeNumber { get; set; }

        public string WebUrl { get; set; }


        public void Copy(ContactInformationPart src)
        {
            this.Id = src.Id;
            this.ModifiedOn = src.ModifiedOn;
            this.CreatedOn = src.CreatedOn;

            this.CellNumber = src.CellNumber;
            this.HomeNumber = src.HomeNumber;
            this.OfficeNumber = src.OfficeNumber;
            this.FacsimileNumber = src.FacsimileNumber;
            this.EmailAddress = src.EmailAddress;
            this.WebUrl = src.WebUrl;

        }
       
    }
}