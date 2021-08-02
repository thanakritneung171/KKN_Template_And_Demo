using KKN.Common.Models;
using KKN.Daos;
using KKN.Models;
using KKN.Models.Mapping;
using KKN.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Service
{
    public class DemoJoinService : BaseService
    {
        private static DemoJoinService instance = null;
        private static readonly object padlock = new object();

        public static DemoJoinService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DemoJoinService();
                    }
                    return instance;
                }
            }
        }

        internal DemoJoinModel GetDbById(int id)
        {
            using (var conn = OpenDbConnection())
            {
                var bService = new DemoJoinDao(conn);
                return bService.GetById(id);
            }
        }

        internal List<DemoJoinModel> GetDbByDemoId(int demoId)
        {
            using (var conn = OpenDbConnection())
            {
                var bService = new DemoJoinDao(conn);
                return bService.GetByDemoId(demoId);
            }
        }

        internal List<IDNAME> GetViewByDemoId(int demoId)
        {
            var result = new List<IDNAME>();
            result = DemoJoinMapping.ToView(GetDbByDemoId(demoId));
            return result;
        }

        public ServiceResult GetByDemoId(int demoId)
        {
            var result = new ServiceResult();          
            result.data = GetViewByDemoId(demoId);
            return result;
        }
    }
}
