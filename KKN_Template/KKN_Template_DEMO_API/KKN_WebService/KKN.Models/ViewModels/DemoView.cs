using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Models.ViewModels
{
    public class DemoView
    {
        public int Id { get; set; }
        public string DemoString { get; set; }
        public int DemoInt { get; set; }
        public int? DemoIntNullable { get; set; }
        public DateTime DemoDate { get; set; }
        public DateTime? DemoDateNullable { get; set; }
        public decimal DemoDecimal { get; set; }
        public decimal? DemoDecimalNullable { get; set; }
        public bool DemoBoolean { get; set; }
        public bool? DemoBooleanNullable { get; set; }     
        public int IsActive { get; set; }
        public int UserAction { get; set; }       
        public List<IDNAME> DemoJoins { get; set; }
    }
}
