using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Models
{
    public class DemoJoinModel
    {
        public int Id { get; set; }
        public int DemoId { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }

        public DemoJoinModel()
        {
          
        }

        public DemoJoinModel(int id)
        {
            this.Id = id;           
        }
    }
}
