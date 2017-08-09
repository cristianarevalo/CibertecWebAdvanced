using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cibertec.RealTime.Controllers
{
    public class DefaultController : ApiController
    {
        public IHttpActionResult Get()
        {
            var list = new List<string>();
            for (int i = 0; i < 300; i++)
            {
                list.Add("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            }

            return Ok(list);
        }
    }
}
