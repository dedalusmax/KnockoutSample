﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Knockout.API.Controllers
{
    public class SpeakersController : BaseController
    {
        public SpeakersController() { }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Json(Repository.GetSpeakers());
        }
    }
}