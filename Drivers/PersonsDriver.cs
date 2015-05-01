using WAA.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Drivers
{


    public class PersonsDriver : ContentPartDriver<PersonsPart>
    {

        protected override string Prefix
        {
            get { return "Persons"; }
        }

        protected override DriverResult Display(PersonsPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_Persons_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Persons", Model: part, Prefix: Prefix));

        }
        

        

        protected override DriverResult Editor(PersonsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Persons_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Persons", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(PersonsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}