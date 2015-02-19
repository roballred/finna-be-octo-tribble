
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Producer.Controllers
{
    public class RegistrationDataController : ApiController
    {


        ///-------------------------------------------------------------------------
        /// <summary>
        /// Post
        /// </summary>
        /// 
        [HttpPost]
        public HttpResponseMessage Post()
        {


            HttpResponseMessage objReturn = Request.CreateResponse(HttpStatusCode.ExpectationFailed);




            return objReturn;
        }
    }
}
