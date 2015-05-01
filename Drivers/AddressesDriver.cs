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
    ///-------------------------------------------------------------------------
    /// <summary>
    /// AddressesDriver
    /// </summary>
    /// 
    public class AddressesDriver : ContentPartDriver<AddressesPart>
    {
        private const string TemplateName = "Parts/Addresses";

        ///-------------------------------------------------------------------------
        /// <summary>
        /// Prefix
        /// </summary>
        /// 
        protected override string Prefix
        {
            get { return "Addresses"; }
        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Display
        /// </summary>
        /// 
        protected override DriverResult Display(AddressesPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_Addresses_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Addresses", Model: part, Prefix: Prefix));

        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Editor
        /// </summary>
        /// 
        protected override DriverResult Editor(AddressesPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Addresses_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Addresses", Model: part, Prefix: Prefix));

        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Editor
        /// </summary>
        /// 
        protected override DriverResult Editor(AddressesPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

       
    }
}