using KKN.Common.Models;
using KKN.Models.ViewModels;
using KKN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService_API.Controllers
{
    public class DemoController : ControllerBase
    {
        // GET: Demo
        [HttpGet]
        [Route("api/Demo")]
        [ResponseType(typeof(ServiceResultTyped<DemoView>))]
        public HttpResponseMessage GetDemoById(int id)
        {
            ServiceResult r = DemoService.Instance.GetByMId(id);
            return ResponseMessage(r);
        }
    }
}