using WAA.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Drivers
{
    public class BusinessDriver : ContentPartDriver<BusinessPart>
    {
                
        private const string TemplateName = "Parts/Business";




        protected override string Prefix
        {
            get { return "Business"; }
        }

        protected override DriverResult Display(BusinessPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_Business", () => shapeHelper.Parts_Business());
            //return ContentShape("Parts_Producers_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Business", Model: part, Prefix: Prefix));

        }

        protected override DriverResult Editor(BusinessPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Addresses_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Business", Model: part, Prefix: Prefix));

        }

        protected override DriverResult Editor(BusinessPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

    }
}