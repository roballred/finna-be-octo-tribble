
using WAA.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Models
{

    public interface IContactInformation
    {
        string CellNumber { get; set; }

        string HomeNumber { get; set; }

        string OfficeNumber { get; set; }

        string FacsimileNumber { get; set; }

        string EmailAddress { get; set; }

        string WebUrl { get; set; }

        DateTime ModifiedOn { get; set; }

        DateTime CreatedOn { get; set; }

    }

    ///-------------------------------------------------------------------------
    /// <summary>
    /// ContactInformation
    /// </summary>
    /// 
    public class ContactInformation : ContentPartRecord, IContactInformation
    {


        public ContactInformation()
        {
            this.Id = 0;
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;

            this.CellNumber = string.Empty;
            this.HomeNumber = string.Empty;
            this.OfficeNumber = string.Empty;
            this.FacsimileNumber = string.Empty;
            this.EmailAddress = string.Empty;
            this.WebUrl = string.Empty;

        }

        public string CellNumber { get; set; }

        public string HomeNumber { get; set; }

        public string OfficeNumber { get; set; }

        public string FacsimileNumber { get; set; }

        public string EmailAddress { get; set; }

        public string WebUrl { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }


    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// ContactInformationPart
    /// </summary>
    /// 
    public class ContactInformationPart : ContentPart<ContactInformation>, IContactInformation
    {

   

        public string CellNumber
        {

            get { return Record.CellNumber; }
            set { Record.CellNumber = value; }
        }


        public string HomeNumber
        {

            get { return Record.HomeNumber; }
            set { Record.HomeNumber = value; }
        }


        public string OfficeNumber
        {

            get { return Record.OfficeNumber; }
            set { Record.OfficeNumber = value; }
        }



        public string FacsimileNumber
        {

            get { return Record.FacsimileNumber; }
            set { Record.FacsimileNumber = value; }
        }

        public string EmailAddress
        {

            get { return Record.EmailAddress; }
            set { Record.EmailAddress = value; }
        }

        public string WebUrl
        {

            get { return Record.WebUrl; }
            set { Record.WebUrl = value; }
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



        public static void Copy(IContactInformation dest, IContactInformation src)
        {
            dest.ModifiedOn = src.ModifiedOn;
            dest.CreatedOn = src.CreatedOn;

            dest.CellNumber = src.CellNumber;
            dest.HomeNumber = src.HomeNumber;
            dest.OfficeNumber = src.OfficeNumber;
            dest.FacsimileNumber = src.FacsimileNumber;
            dest.EmailAddress = src.EmailAddress;
            dest.WebUrl = src.WebUrl;

        }

    }



    ///-------------------------------------------------------------------------
    /// <summary>
    /// ContactInformationHandler
    /// </summary>
    /// 
    public class ContactInformationHandler : ContentHandler
    {

        public ContactInformationHandler(IRepository<ContactInformation> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}