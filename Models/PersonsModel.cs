
using AREA.Membership.ViewModels;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.Records;
using Orchard.Data;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace AREA.Membership.Models
{

    ///-------------------------------------------------------------------------
    /// <summary>
    /// Persons
    /// </summary>
    /// 
    public class Persons : ContentPartRecord
    {

        public Persons()
        {
            this.Id = 0;

            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;
            this.Birthday = DateTime.UtcNow;

            this.Prefix = String.Empty;
            this.FirstName = String.Empty;
            this.MiddleName = String.Empty;
            this.LastName = String.Empty;
            this.Suffix = String.Empty;
            this.Nickname = String.Empty;

        }


        public virtual string Prefix { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Suffix { get; set; }

        public virtual string Nickname { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime Birthday { get; set; }


    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// PersonsPart
    /// </summary>
    /// 
    public class PersonsPart : ContentPart<Persons>
    {


        public string Prefix
        {

            get { return Record.Prefix; }
            set { Record.Prefix = value; }
        }

        public string FirstName
        {

            get
            {
                string szReturn = string.Empty;

                if (Record.FirstName != null)
                    szReturn = Record.FirstName;

                return szReturn;
            }
            set { Record.FirstName = value; }
        }

        public string MiddleName
        {

            get { return Record.MiddleName; }
            set { Record.MiddleName = value; }
        }

        public string LastName
        {

            get { return Record.LastName; }
            set { Record.LastName = value; }
        }


        public string Suffix
        {

            get { return Record.Suffix; }
            set { Record.Suffix = value; }
        }


        public string Nickname
        {

            get { return Record.Nickname; }
            set { Record.Nickname = value; }
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

        public DateTime Birthday
        {
            get { return Record.Birthday; }
            set { Record.Birthday = value; }
        }



        public string FullName
        {
            get
            {
                StringBuilder objStringBuilder = new StringBuilder();

                if (this.Prefix != null && this.Prefix.Length > 0)
                {
                    objStringBuilder.AppendFormat("{0} ", this.Prefix);
                }

                if (this.FirstName != null && this.FirstName.Length > 0)
                {
                    objStringBuilder.AppendFormat("{0} ", this.FirstName);
                }

                if (this.MiddleName != null && this.MiddleName.Length > 0)
                {
                    objStringBuilder.AppendFormat("{0} ", this.MiddleName);
                }

                if (this.LastName != null && this.LastName.Length > 0)
                {
                    objStringBuilder.AppendFormat("{0} ", this.LastName);
                }

                if (this.Suffix != null && this.Suffix.Length > 0)
                {
                    objStringBuilder.AppendFormat("{0} ", this.Suffix);
                }

                return objStringBuilder.ToString().Trim();
            }
        }



        public void Copy(PersonViewModel src)
        {
            this.ModifiedOn = src.ModifiedOn;
            this.CreatedOn = src.CreatedOn;
            this.Birthday = src.Birthday;

            this.Prefix = src.Prefix;
            this.FirstName = src.FirstName;
            this.MiddleName = src.MiddleName;
            this.LastName = src.LastName;
            this.Suffix = src.Suffix;
            this.Nickname = src.Nickname;

        }

    }

    ///-------------------------------------------------------------------------
    /// <summary>
    /// PersonsHandler
    /// </summary>
    /// 
    public class PersonsHandler : ContentHandler
    {

        public PersonsHandler(IRepository<Persons> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}