using Orchard;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WAA.Base;

namespace WAA.Controllers
{
    public class BusinessController : BaseController
    {
        public BusinessController(IOrchardServices orchardServices)
            : base(orchardServices)
        {

        }
        // GET: Business
        public ActionResult Index()
        {
            return View();
        }

        [Themed]
        public ActionResult Flightdeck()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            return View("Flightdeck.Business");
        }

    }
}