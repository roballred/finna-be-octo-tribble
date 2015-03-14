using AREA.Membership.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using Orchard.Data;
using Orchard.Security;
using Orchard.Taxonomies.Fields;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;
using Orchard.Taxonomies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AREA.Membership.Services
{

    ///-------------------------------------------------------------------------
    /// <summary>
    /// IMembersService
    /// </summary>
    /// 
    public interface IMembersService : IDependency
    {

        MembersPart Factory();
        void Testing();
    }


    ///-------------------------------------------------------------------------
    /// <summary>
    /// MembersService
    /// </summary>
    /// 
    public class MembersService : IMembersService
    {
        private IOrchardServices _orchardServices;
        private ITaxonomyService _taxonomyService;
        public MembersService(IOrchardServices services,
            ITaxonomyService taxonomyService)
        {
            _orchardServices = services;
            _taxonomyService = taxonomyService;
        }



        ///-------------------------------------------------------------------------
        /// <summary>
        /// Factory
        /// </summary>
        /// 
        public MembersPart Factory()
        {
            var objServiceItem = _orchardServices.ContentManager.New("MembersServiceItem");

            _orchardServices.ContentManager.Create(objServiceItem, VersionOptions.Published);

            var objMemberPart = objServiceItem.As<MembersPart>();

            return objMemberPart;

        }

        public void Testing()
        {
            var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategory");
            var termPilot = _taxonomyService.GetTermByName(taxonomy.Id, "Pilot");

            //var member = _orchardServices.ContentManager.Get<MembersPart>(36);
            var members = _taxonomyService.GetContentItemsQuery(termPilot, "Pilot").List();
            //var terms = _taxonomyService.GetTermsForContentItem(member.ContentItem.Id);

            string junk = "";
  //          //var blogPosts = _contentManager.Query<BlogPostPart>().Where<CommonPartRecord>(bp => bp.Container.Id == blogPart.Id);

  //          //var objServiceItem = _orchardServices.ContentManager.New("TestingContentItem");
  //          var objServiceItem = _orchardServices.ContentManager.New("MembersServiceItem");
  //          _orchardServices.ContentManager.Create(objServiceItem, VersionOptions.Published);

  //          //var taxField = objServiceItem.As<TaxonomyField>();
  //          //get taxonomy name Category
  //          //var taxonomy = _taxonomyService.GetTaxonomyByName("Category");
  //          var memberPart = objServiceItem.As<TermsPart>();
  //          var taxonomy = _taxonomyService.GetTaxonomyByName("IndividualCategory");


  //          //var terms = _taxonomyService.GetTermsForContentItem(objServiceItem.Id, "Category").ToList();
  //          var terms = _taxonomyService.GetTerms(taxonomy.Id);
  //          var term = terms.FirstOrDefault();
  //          var termTaxonomy = (term.ContentItem);
  //          var termContentItem = _orchardServices.ContentManager.Get(term.Record.Id);
  //          memberPart.Terms.Add(new TermContentItem
  //          {
  //              TermsPartRecord = memberPart.Record,
  //              TermRecord = term.Record,
  //              Field = "Pilot"
  //          });

  //          //var term = _taxonomyService.NewTerm(taxonomy);
  //          //term.Container = taxonomy.ContentItem;
  //          //term.Name = "Pilot";
  //          //term.Selectable = true;

  //          //_taxonomyService.ProcessPath(term);
  //          //_orchardServices.ContentManager.Create(term, VersionOptions.Published);

  //          //List<TermPart> objTest = new List<TermPart>();
  //          //objTest.Add(term);

  //          //get terms to update content item

  //          //_taxonomyService.UpdateTerms(objServiceItem, objTest, "Pilot");

            
  //          //TermContentItem
  //          //objMemberPart.Terms.Add(test);
  //          //var objServiceItem = _orchardServices.ContentManager.Query(VersionOptions.AllVersions, "Testing");
  //          //var objServiceItem = _orchardServices.ContentManager.Query<TaxonomyPart, TaxonomyPartRecord>().Where(tst => tst.TermTypeName == "Catigory").List().FirstOrDefault();
  //          //var objServiceItem = _orchardServices.ContentManager.Query().ForType("AAW").List().FirstOrDefault();
  //          //var objServiceItem = _orchardServices.ContentManager.Query<MembersPart, Members>().Join<TermPartRecord>()
  //          //    .Where(r => r.Title == name).Where(tst => tst.TermTypeName == "Catigory").List().FirstOrDefault();

  ////          _cms.Query<TagsPart, TagsPartRecord>()
  //29:                  .Where(tpr => tpr.Tags.Any(t => tags.Contains(t.TagRecord.TagName)))
            //_orchardServices.ContentManager.Create(objServiceItem, VersionOptions.Published);
            //var objTaxonomy = _taxonomyService.
            //var objMemberPart = objServiceItem.As<TaxonomyPart>();
            var testId = "";
        }


    }
}