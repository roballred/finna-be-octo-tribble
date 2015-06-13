
using WAA.ViewModels;
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


namespace WAA.Models
{

    public interface IPersons
    {
        int Id { get; set; }
        string Prefix { get; set; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        string LastName { get; set; }

        string Suffix { get; set; }

        string Nickname { get; set; }

        string Title { get; set; }

        int Gender { get; set; }

        DateTime ModifiedOn { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime Birthday { get; set; }

    }
    ///-------------------------------------------------------------------------
    /// <summary>
    /// Persons
    /// </summary>
    /// 
    public class Persons : ContentPartRecord, IPersons
    {

        public Persons()
        {
            this.ModifiedOn = DateTime.UtcNow;
            this.CreatedOn = DateTime.UtcNow;
            this.Birthday = DateTime.UtcNow;
            this.Title = string.Empty;
            this.Prefix = String.Empty;
            this.FirstName = String.Empty;
            this.MiddleName = String.Empty;
            this.LastName = String.Empty;
            this.Suffix = String.Empty;
            this.Nickname = String.Empty;

            this.Gender = 0;

        }


        public virtual string Prefix { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Suffix { get; set; }

        public virtual string Nickname { get; set; }

        public virtual string Title { get; set; }

        public virtual int Gender { get; set; }

        public virtual DateTime ModifiedOn { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime Birthday { get; set; }


    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// PersonsPart
    /// </summary>
    /// 
    public class PersonsPart : ContentPart<Persons>, IPersons
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

        public string Title
        {
            get { return Record.Title; }
            set { Record.Title = value; }
        }

        public int Gender
        {
            get { return Record.Gender; }
            set { Record.Gender = value; }
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

        int IPersons.Id
        {
            get { return Record.Id; }
            set { }
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

        public static void DeepCopy(IPersons dest, IPersons src)
        {
            dest.Id = src.Id;
            PersonsPart.Copy(dest, src);
        }

        public static void Copy(IPersons dest, IPersons src)
        {
            PersonsPart.MapData(dest, src);
        }
        public static void MapData(IPersons dest, IPersons src)
        {
            dest.ModifiedOn = src.ModifiedOn;
            dest.CreatedOn = src.CreatedOn;
            dest.Birthday = src.Birthday;

            dest.Prefix = src.Prefix;
            dest.FirstName = src.FirstName;
            dest.MiddleName = src.MiddleName;
            dest.LastName = src.LastName;
            dest.Suffix = src.Suffix;
            dest.Nickname = src.Nickname;
            dest.Title = src.Title;
            dest.Gender = src.Gender;

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