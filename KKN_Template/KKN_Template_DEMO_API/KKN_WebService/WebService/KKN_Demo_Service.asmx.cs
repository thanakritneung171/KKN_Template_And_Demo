using KKN.Common.Models;
using KKN.Models.ViewModels;
using KKN.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class KKN_Account_Service : System.Web.Services.WebService
    {
        [WebMethod]
        [XmlInclude(typeof(DemoView))]
        public ServiceResult GetDemoById(int id)
        {
            var result = DemoService.Instance.GetById(id);
            return result;
        }

        [WebMethod]
        [XmlInclude(typeof(DemoView))]
        public ServiceResult SaveDemo(DemoView model)
        {
            var result = DemoService.Instance.Save(model);
            return result;
        }

        [WebMethod]
        [XmlInclude(typeof(ServiceResultNoValue))]
        public ServiceResult SaveDelete(int id, int userId)
        {
            var result = DemoService.Instance.Delete(id, userId);
            return result;
        }

        [WebMethod]
        [XmlInclude(typeof(List<IDNAME>))]
        public ServiceResult GetDemoJoinByDemoId(int demoId)
        {
            var result = DemoJoinService.Instance.GetByDemoId(demoId);
            return result;
        }
    }
}
