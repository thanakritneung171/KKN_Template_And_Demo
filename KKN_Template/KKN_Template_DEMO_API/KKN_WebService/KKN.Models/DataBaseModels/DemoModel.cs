using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Models
{
    public class DemoModel
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
        public DemoJoinModel Detail { get; set; }
        public List<DemoJoinModel> Details { get; set; }
        public int IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DemoModel()
        {
            this.Detail = new DemoJoinModel();
            this.Details = new List<DemoJoinModel>();
        }

        public DemoModel(int id)
        {
            this.Id = id;
            this.Detail = new DemoJoinModel();
            this.Details = new List<DemoJoinModel>();
        }
    }

    public class DemoListModel
    {
        public List<DemoModel> Details { get; set; }
        public int Count { get; set; }

        public DemoListModel()
        {
            this.Details = new List<DemoModel>();
        }
    }
}
