using KKN.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebService_API.Controllers
{
    public class ControllerBase : ApiController
    {
        protected HttpResponseMessage ResponseMessage(ServiceResult result)
        {
            HttpResponseMessage response;
            List<string> listMessage = new List<string>();
            if (result.code == (int)ServiceResultCodes.Ok)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else if (result.code == (int)ServiceResultCodes.Error)
            {
                listMessage.Add("โปรดติดต่อ admin");
                result.messages = listMessage;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            return response;
        }

        protected HttpResponseMessage ResponseMessage(CodeServiceResult result)
        {
            List<string> listMessage = new List<string>();
            HttpResponseMessage response;
            if (result.Code == (int)ServiceResultCodes.Ok)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else if (result.Code == (int)ServiceResultCodes.Error)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, result);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            return response;
        }

        protected HttpResponseMessage NoValueResponseMessage(ServiceResultNoValue result)
        {
            HttpResponseMessage response = Request.CreateResponse(result.Code == (int)ServiceResultCodes.Ok ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            return response;
        }
    }
}