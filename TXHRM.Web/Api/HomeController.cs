using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TXHRM.Service;
using TXHRM.Web.Infrastructure.Core;

namespace TXHRM.Web.Api
{
    [RoutePrefix("api/home")]
    public class HomeController : BaseApiController
    {
        #region Initialize
        IErrorService _errorService;
        public HomeController(IErrorService errorService) : base(errorService)
        {
            this._errorService = errorService;
        }
        #endregion
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, Trinh Ngoc Han";
        }

    }
}