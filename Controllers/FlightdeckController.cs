using WAA.Base;
using Orchard;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WAA.Controllers
{
    public class FlightdeckController : BaseController
    {

        public FlightdeckController(IOrchardServices orchardServices)
            : base(orchardServices)
        {

        }

                
        [Themed]
        // GET: Flightdeck
        public ActionResult Index()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            return View("Flightdeck");
        }
    }
}