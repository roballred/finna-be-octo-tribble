using WAA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {

        private const string szDefaultString = "";

        public AddressViewModel()
        {

            this.Id = 0;
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;
            this.Address1 = string.Empty;
            this.Address2 = string.Empty;
            this.Address3 = string.Empty;
            this.Address4 = string.Empty;
            this.City = string.Empty;
            this.State = "WA";
            this.ZipCode = string.Empty;
            this.Latitude = 0.0f;
            this.Longitude = 0.0f;
            this.Country = "United States";
        }


        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }





        public void Copy(AddressesPart src)
        {
            this.Id = src.Id;
            this.ModifiedOn = src.ModifiedOn;
            this.CreatedOn = src.CreatedOn;
            this.Address1 = src.Address1;
            this.Address2 = src.Address2;
            this.Address3 = src.Address3;
            this.Address4 = src.Address4;
            this.City = src.City;
            this.State = src.State;
            this.ZipCode = src.ZipCode;
            this.Latitude = src.Latitude;
            this.Longitude = src.Longitude;
            this.Country = src.Country;

        }


        
    }
}