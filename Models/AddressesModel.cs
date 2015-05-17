
using WAA.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.Data;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Models
{


    ///-------------------------------------------------------------------------
    /// <summary>
    /// Addresses
    /// </summary>
    /// 
    public class Addresses : ContentPartRecord
    {


        public Addresses()
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
            this.Country = string.Empty;
            this.Latitude = 0.0f;
            this.Longitude = 0.0f;

        }



        public virtual string Address1 { get; set; }

        public virtual string Address2 { get; set; }


        public virtual string Address3 { get; set; }

        public virtual string Address4 { get; set; }


        public virtual string City { get; set; }

        public virtual string State { get; set; }


        public virtual string ZipCode { get; set; }

        public virtual string Country { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// AddressesPart
    /// </summary>
    /// 
    public class AddressesPart : ContentPart<Addresses>
    {
        public string Address1
        {

            get { return Record.Address1; }
            set { Record.Address1 = value; }
        }

        public string Address2
        {

            get { return Record.Address2; }
            set { Record.Address2 = value; }
        }

        public string Address3
        {

            get { return Record.Address3; }
            set { Record.Address3 = value; }
        }


        public string Address4
        {

            get { return Record.Address4; }
            set { Record.Address4 = value; }
        }


        public string City
        {

            get { return Record.City; }
            set { Record.City = value; }
        }


        public string State
        {

            get { return Record.State; }
            set { Record.State = value; }
        }


        public string ZipCode
        {

            get { return Record.ZipCode; }
            set { Record.ZipCode = value; }
        }


        public string Country
        {

            get { return Record.Country; }
            set { Record.Country = value; }
        }


       
        public DateTime ModifiedOn
        {
            get { return Record.ModifiedOn; }
            set { Record.ModifiedOn = value; }
        }

        public DateTime CreatedOn
        {
            get { return Record.CreatedOn; }
            set { Record.CreatedOn = value; }
        }

        public double Latitude
        {
            get { return Record.Latitude; }
            set { Record.Latitude = value; }
        }

        public double Longitude
        {
            get { return Record.Longitude; }
            set { Record.Longitude = value; }
        }


        public string ShortAddress()
        {
            string szReturn = string.Empty;

            if (this.Address1.Length > 0 && this.City.Length > 0 && this.State.Length > 0 && this.ZipCode.Length > 0)
            {
                szReturn = string.Format("<p>{0}</p><p>{1}, {2} {3}</p>", this.Address1, this.City, this.State, this.ZipCode);
            }
            return szReturn;
        }



        public void Copy(AddressViewModel src)
        {
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


    ///-------------------------------------------------------------------------
    /// <summary>
    /// AddressesHandler
    /// </summary>
    /// 
    public class AddressesHandler : ContentHandler
    {

        public AddressesHandler(IRepository<Addresses> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }

    }
}