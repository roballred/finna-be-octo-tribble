using WAA.Models;
using WAA.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAA.Drivers
{


    public class ProducersDriver : ContentPartDriver<MembersPart>
    {
        private readonly IMembersService m_objMembersService;
        private const string TemplateName = "Parts/MemberDisplay";

        public ProducersDriver(IMembersService objMembersService)
        {
            m_objMembersService = objMembersService;
        }


        protected override DriverResult Display(MembersPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("MemberDisplay", () => shapeHelper.Parts_MemberDisplay(Model: part));

        }

        protected override DriverResult Editor(MembersPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Members_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts.Members", Model: part));

        }

        protected override DriverResult Editor(MembersPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
        

        
    }
}