using KKN.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Models.Mapping
{
    public static class DemoMapping
    {
        public static List<DemoView> ToView(List<DemoModel> dbDemos, List<DemoJoinModel> dbDemoJoins)
        {
            var r = new List<DemoView>();

            if (dbDemos != null && dbDemos.Count() != 0)
            {
                foreach (var dbDemo in dbDemos)
                {
                    r.Add(ToView(dbDemo, dbDemoJoins));
                }
            }
            return r;
        }

        public static DemoView ToView(DemoModel d, List<DemoJoinModel> dbDemoJoins)
        {
            var dbDemoJoin = dbDemoJoins.Find(x => x.Id == d.Id);
            return new DemoView
            {
                Id = d.Id,
                DemoString = d.DemoString,
                DemoInt = d.DemoInt,
                DemoIntNullable = d.DemoIntNullable,
                DemoDate = d.DemoDate,
                DemoDateNullable = d.DemoDateNullable,
                DemoDecimal = d.DemoDecimal,
                DemoDecimalNullable = d.DemoDecimalNullable,
                DemoBoolean = d.DemoBoolean,
                DemoBooleanNullable = d.DemoBooleanNullable,               
                DemoJoins = DemoJoinMapping.ToView(d.Details)
            };
        }

        public static List<DemoModel> FromView(List<DemoView> v)
        {
            var r = new List<DemoModel>();

            if (v != null && v.Count() != 0)
            {
                foreach (var d in v)
                {
                    r.Add(FromView(d));
                }
            }
            return r;
        }

        public static DemoModel FromView(DemoView d)
        {
            return new DemoModel
            {
                Id = d.Id,
                DemoString = d.DemoString,
                DemoInt = d.DemoInt,
                DemoIntNullable = d.DemoIntNullable,
                DemoDate = d.DemoDate,
                DemoDateNullable = d.DemoDateNullable,
                DemoDecimal = d.DemoDecimal,
                DemoDecimalNullable = d.DemoDecimalNullable,
                DemoBoolean = d.DemoBoolean,
                DemoBooleanNullable = d.DemoBooleanNullable
            };
        }

        public static DemoModel FromView(DemoModel model,DemoView d)
        {
            model.DemoString = d.DemoString;
            model.DemoInt = d.DemoInt;
            model.DemoIntNullable = d.DemoIntNullable;
            model.DemoDate = d.DemoDate;
            model.DemoDateNullable = d.DemoDateNullable;
            model.DemoDecimal = d.DemoDecimal;
            model.DemoDecimalNullable = d.DemoDecimalNullable;
            model.DemoBoolean = d.DemoBoolean;
            model.DemoBooleanNullable = d.DemoBooleanNullable;
            return model;
        }
    }
}
