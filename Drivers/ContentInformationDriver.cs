using WAA.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Drivers
{
    public class ContentInformationDriver : ContentPartDriver<ContactInformationPart>
    {

        private const string TemplateName = "Parts/ContentInformation";

        protected override string Prefix
        {
            get { return "ContentInformation"; }
        }

        protected override DriverResult Display(ContactInformationPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_ContentInformation_Edit", () => shapeHelper.EditorTemplate(TemplateName: "ContentInformation", Model: part, Prefix: Prefix));

        }

        protected override DriverResult Editor(ContactInformationPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_ContentInformation_Edit", () => shapeHelper.EditorTemplate(TemplateName: "ContentInformation", Model: part, Prefix: Prefix));

        }

        protected override DriverResult Editor(ContactInformationPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}