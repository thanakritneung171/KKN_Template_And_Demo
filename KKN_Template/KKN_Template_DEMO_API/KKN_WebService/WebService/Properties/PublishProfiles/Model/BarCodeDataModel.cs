using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Properties.PublishProfiles
{
    public class BarCodeDataModel
    {
       
        public string BarCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialDetail { get; set; }
        public byte MaterialStatus { get; set; }
        public int ServeyBy { get; set; }
        public string ServeyByName { get; set; }
        public string ServeyDate { get; set; }
        public int runningNo { get; set; }
    }
}