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
    public class MembersController : BaseController
    {

        public MembersController(IOrchardServices orchardServices) : base(orchardServices)
        {

        }


        [Themed]
        // GET: Flightdeck
        public ActionResult Flightdeck()
        {
            if (!IsAuthorized()) return new HttpUnauthorizedResult();

            return this.Flightdeck();
        }

        private ActionResult PrepareFlightdeck(int nMemberId)
        {

            return View("Flightdeck.Individual");

        }

    }
}