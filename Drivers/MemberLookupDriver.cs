using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAA.Models;

namespace WAA.Drivers
{
    public class MemberLookupDriver : ContentPartDriver<MemberLookupPart>
    {
        private const string TemplateName = "Parts/MemberLookup";

        ///-------------------------------------------------------------------------
        /// <summary>
        /// Prefix
        /// </summary>
        /// 
        protected override string Prefix
        {
            get { return "MemberLookup"; }
        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Display
        /// </summary>
        /// 
        protected override DriverResult Display(MemberLookupPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_MemberLookup_Edit", () => shapeHelper.EditorTemplate(TemplateName: "MemberLookup", Model: part, Prefix: Prefix));

        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Editor
        /// </summary>
        /// 
        protected override DriverResult Editor(MemberLookupPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_MemberLookup_Edit", () => shapeHelper.EditorTemplate(TemplateName: "MemberLookup", Model: part, Prefix: Prefix));

        }


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Editor
        /// </summary>
        /// 
        protected override DriverResult Editor(MemberLookupPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }


    }
}