using KKN.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Models.Mapping
{
    public static class DemoJoinMapping
    {
        public static List<IDNAME> ToView(List<DemoJoinModel> db)
        {
            var r = new List<IDNAME>();

            if (db != null && db.Count() != 0)
            {
                foreach (var d in db)
                {
                    r.Add(ToView(d));
                }
            }
            return r;
        }

        public static IDNAME ToView(DemoJoinModel d)
        {
            return new IDNAME
            {
                Id = d.Id,
                Name = d.Name
            };
        }

        public static List<DemoJoinModel> FromView(List<IDNAME> v)
        {
            var r = new List<DemoJoinModel>();

            if (v != null && v.Count() != 0)
            {
                foreach (var d in v)
                {
                    r.Add(FromView(d));
                }
            }
            return r;
        }

        public static DemoJoinModel FromView(IDNAME d)
        {
            return new DemoJoinModel
            {
                Id = d.Id,
                Name = d.Name
            };
        }
    }
}
