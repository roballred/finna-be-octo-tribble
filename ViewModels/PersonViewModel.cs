using WAA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAA.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {

        public PersonViewModel()
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
            this.Title = string.Empty;
            this.Gender = 0;

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Nickname { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }


        public void Copy(PersonsPart src)
        {
            this.Id = src.Id;

            this.ModifiedOn = src.ModifiedOn;
            this.CreatedOn = src.CreatedOn;
            this.Birthday = src.Birthday;

            this.Prefix = src.Prefix;
            this.FirstName = src.FirstName;
            this.MiddleName = src.MiddleName;
            this.LastName = src.LastName;
            this.Suffix = src.Suffix;
            this.Nickname = src.Nickname;
            this.Title = src.Title;
            this.Gender = src.Gender;

        }

    }
}