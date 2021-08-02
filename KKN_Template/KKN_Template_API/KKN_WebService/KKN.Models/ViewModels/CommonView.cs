using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Models.ViewModels
{
    public class IDNAME
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IDCODENAME : IDNAME
    {
        public string Code { get; set; }
    }
}
