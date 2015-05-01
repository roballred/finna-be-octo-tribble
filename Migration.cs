using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using System.Data;
using WAA.Models;

namespace WAA
{


    public class Migration : DataMigrationImpl
    {
        private readonly IRepository<States> _stateRepository;

        public Migration(IRepository<States> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        #region Populate states
        private readonly IEnumerable<States> _states =
            new List<States> {
                new States {Code = "AL", Name = "Alabama"},
                new States {Code = "AK", Name = "Alaska"},
                new States {Code = "AZ", Name = "Arizona"},
                new States {Code = "AR", Name = "Arkansas"},
                new States {Code = "CA", Name = "California"},
                new States {Code = "CO", Name = "Colorado"},
                new States {Code = "CT", Name = "Connecticut"},
                new States {Code = "DE", Name = "Delaware"},
                new States {Code = "FL", Name = "Florida"},
                new States {Code = "GA", Name = "Georgia"},
                new States {Code = "HI", Name = "Hawaii"},
                new States {Code = "ID", Name = "Idaho"},
                new States {Code = "IL", Name = "Illinois"},
                new States {Code = "IN", Name = "Indiana"},
                new States {Code = "IA", Name = "Iowa"},
                new States {Code = "KS", Name = "Kansas"},
                new States {Code = "KY", Name = "Kentucky"},
                new States {Code = "LA", Name = "Louisiana"},
                new States {Code = "ME", Name = "Maine"},
                new States {Code = "MD", Name = "Maryland"},
                new States {Code = "MA", Name = "Massachusetts"},
                new States {Code = "MI", Name = "Michigan"},
                new States {Code = "MN", Name = "Minnesota"},
                new States {Code = "MS", Name = "Mississippi"},
                new States {Code = "MO", Name = "Missouri"},
                new States {Code = "MT", Name = "Montana"},
                new States {Code = "NE", Name = "Nebraska"},
                new States {Code = "NV", Name = "Nevada"},
                new States {Code = "NH", Name = "New Hampshire"},
                new States {Code = "NJ", Name = "New Jersey"},
                new States {Code = "NM", Name = "New Mexico"},
                new States {Code = "NY", Name = "New York"},
                new States {Code = "NC", Name = "North Carolina"},
                new States {Code = "ND", Name = "North Dakota"},
                new States {Code = "OH", Name = "Ohio"},
                new States {Code = "OK", Name = "Oklahoma"},
                new States {Code = "OR", Name = "Oregon"},
                new States {Code = "PA", Name = "Pennsylvania"},
                new States {Code = "RI", Name = "Rhode Island"},
                new States {Code = "SC", Name = "South Carolina"},
                new States {Code = "SD", Name = "South Dakota"},
                new States {Code = "TN", Name = "Tennessee"},
                new States {Code = "TX", Name = "Texas"},
                new States {Code = "UT", Name = "Utah"},
                new States {Code = "VT", Name = "Vermont"},
                new States {Code = "VA", Name = "Virginia"},
                new States {Code = "WA", Name = "Washington"},
                new States {Code = "WV", Name = "West Virginia"},
                new States {Code = "WI", Name = "Wisconsin"},
                new States {Code = "WY", Name = "Wyoming"},
                new States {Code = "AB", Name = "Alberta"},
                new States {Code = "BC", Name = "British Columbia"},
                new States {Code = "MB", Name = "Manitoba"},
                new States {Code = "NB", Name = "New Brunswick"},
                new States {Code = "NF", Name = "Newfoundland and Labrador"},
                new States {Code = "NT", Name = "Northwest Territories"},
                new States {Code = "NS", Name = "Nova Scotia"},
                new States {Code = "NU", Name = "Nunavut"},
                new States {Code = "ON", Name = "Ontario"},
                new States {Code = "PE", Name = "Prince Edward Island"},
                new States {Code = "PQ", Name = "Quebec"},
                new States {Code = "SK", Name = "Saskatchewan"},
                new States {Code = "YT", Name = "Yukon Territory"},
                new States {Code = "AC", Name = "Australian Capital Territory"},
                new States {Code = "NW", Name = "New South Wales"},
                new States {Code = "NO", Name = "Northern Territory"},
                new States {Code = "QL", Name = "Queensland"},
                new States {Code = "SA", Name = "South Australia"},
                new States {Code = "TS", Name = "Tasmania"},
                new States {Code = "VC", Name = "Victoria"},
                new States {Code = "WS", Name = "Western Australia"},
            };

        #endregion


        public int Create()
        {

            SchemaBuilder.CreateTable("Members",
                table => table
                .ContentPartRecord()
                .Column<int>("ContactInformationId")
                .Column<int>("AddressId")
                .Column<int>("PersonId")
                .Column<DateTime>("RenewalOn")
                .Column<DateTime>("CreatedOn")
                .Column<DateTime>("ModifiedOn")
                );


            //create persons table
            SchemaBuilder.CreateTable("Persons",
                table => table
                .ContentPartRecord()
                .Column<string>("Prefix", column => column.WithLength(32).NotNull())
                .Column<string>("FirstName", column => column.WithLength(128).NotNull())
                .Column<string>("MiddleName", column => column.WithLength(128).NotNull())
                .Column<string>("LastName", column => column.WithLength(128).NotNull())
                .Column<string>("Suffix", column => column.WithLength(32).NotNull())
                .Column<string>("Nickname", column => column.WithLength(64).NotNull())
                .Column<string>("Title", column => column.WithLength(64).NotNull())                
                .Column<int>("Gender")
                .Column<DateTime>("CreatedOn")
                .Column<DateTime>("ModifiedOn")
                .Column<DateTime>("Birthday")
                );


            //create Addresses table
            SchemaBuilder.CreateTable("Addresses",
                table => table
                .ContentPartRecord()
                .Column<string>("Address1", column => column.WithLength(256).NotNull())
                .Column<string>("Address2", column => column.WithLength(256).NotNull())
                .Column<string>("Address3", column => column.WithLength(256).NotNull())
                .Column<string>("Address4", column => column.WithLength(256).NotNull())
                .Column<string>("City", column => column.WithLength(128).NotNull())
                .Column<string>("State", column => column.WithLength(64).NotNull())
                .Column<string>("ZipCode", column => column.WithLength(64).NotNull())
                .Column<string>("Country", column => column.WithLength(64).NotNull())
                .Column<double>("Latitude", column => column.WithType(DbType.Double).WithDefault(0))
                .Column<double>("Longitude", column => column.WithType(DbType.Double).WithDefault(0))
                .Column<DateTime>("CreatedOn")
                .Column<DateTime>("ModifiedOn")
                );


            //create ContactInformation table
            SchemaBuilder.CreateTable("ContactInformation",
                table => table
                .ContentPartRecord()
                .Column<string>("CellNumber", column => column.WithLength(24).NotNull())
                .Column<string>("HomeNumber", column => column.WithLength(24).NotNull())
                .Column<string>("OfficeNumber", column => column.WithLength(24).NotNull())
                .Column<string>("FacsimileNumber", column => column.WithLength(24).NotNull())
                .Column<string>("EmailAddress", column => column.WithLength(254).NotNull())
                .Column<string>("WebUrl", column => column.WithLength(2048).NotNull())
                .Column<DateTime>("CreatedOn")
                .Column<DateTime>("ModifiedOn")
                );




            SchemaBuilder.CreateTable("States",
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("Code", column => column.WithLength(2).NotNull())
                    .Column<string>("Name", column => column.WithLength(128).NotNull())
                );

            if (_stateRepository == null) throw new InvalidOperationException("Couldn't find state repository.");
            foreach (var state in _states)
            {
                _stateRepository.Create(state);
            }

            SchemaBuilder.CreateTable("MemberLookup",
                table => table
                    .Column<int>("Id", column => column.PrimaryKey().Identity())
                    .Column<string>("EmailAddress", column => column.WithLength(254).NotNull())
                    .Column<int>("MemberId")
                    .Column<int>("BusinessId")

                );



            #region Part Definitions
            ContentDefinitionManager.AlterPartDefinition(typeof(MembersPart).Name, part => part.Attachable());

            ContentDefinitionManager.AlterPartDefinition(typeof(PersonsPart).Name, part => part.Attachable());

            ContentDefinitionManager.AlterPartDefinition(typeof(AddressesPart).Name, part => part.Attachable());


            ContentDefinitionManager.AlterPartDefinition(typeof(ContactInformationPart).Name, part => part.Attachable());

            #endregion

            #region Content Items
            ContentDefinitionManager.AlterTypeDefinition("MembersServiceItem", type => type.WithPart("MembersPart"));


            ContentDefinitionManager.AlterTypeDefinition("AddressServiceItem", type => type.WithPart("AddressesPart"));

            ContentDefinitionManager.AlterTypeDefinition("ContactInformationServiceItem", type => type.WithPart("ContactInformationPart"));

            ContentDefinitionManager.AlterTypeDefinition("PersonServiceItem", type => type.WithPart("PersonsPart"));

            #endregion

            return 1;
        }

        //public int UpdateFrom1()
        //{
        //    ContentDefinitionManager.AlterTypeDefinition("TestingContentItem", cfg => cfg
        //        .WithPart("PersonsPart")
        //        .WithPart("TaxonomyPart")
        //        );

        //    return 2;
        //}
        //public int UpdateFrom3()
        //{
        //    SchemaBuilder.CreateTable("TitlePartRecord",
        //        table => table
        //            .ContentPartVersionRecord()
        //            .Column<string>("Title", column => column.WithLength(1024))
        //        );
        //    return 4;
        //}
    }
}






