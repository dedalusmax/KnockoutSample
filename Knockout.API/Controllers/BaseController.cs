using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knockout.API.Controllers
{
    public class BaseController : ApiController
    {
        private static Repository _repository;
        public static Repository Repository
        {
            get
            {
                if (_repository == null)
                    _repository = new Repository();

                return _repository;
            }
        }

        public BaseController() { }
    }
}