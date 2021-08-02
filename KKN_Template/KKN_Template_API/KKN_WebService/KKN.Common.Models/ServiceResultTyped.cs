using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Common.Models
{
    public class ServiceResultTyped<T>
    {
        public int Code { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
