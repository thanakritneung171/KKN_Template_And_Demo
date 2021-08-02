using KKN.Common.Models;
using KKN.Daos;
using KKN.Models;
using KKN.Models.Mapping;
using KKN.Models.ViewModels;
using KKN.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Service
{
    public class DemoService : BaseService
    {
        private static DemoService instance = null;
        private static readonly object padlock = new object();

        public static DemoService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DemoService();
                    }
                    return instance;
                }
            }
        }

        internal DemoModel GetDbById(int id)
        {
            using (var conn = OpenDbConnection())
            {
                var bService = new DemoDao(conn);
                return bService.GetById(id);
            }
        }

        internal DemoListModel GetDbSearch(DemoModel model, int demoJoinId)
        {
            using (var conn = OpenDbConnection())
            {
                var bService = new DemoDao(conn);
                return bService.GetBySearch(model, demoJoinId);
            }
        }

        internal DemoView GetViewById(int id)
        {
            var result = new DemoView();
            var details = DemoJoinService.Instance.GetDbByDemoId(id);
            result = DemoMapping.ToView(GetDbById(id), details);
            return result;
        }

        public ServiceResult GetById(int id)
        {
            var result = new ServiceResult();
            result.data = GetViewById(id);
            return result;
        }

        public ServiceResult Save(DemoView model)
        {
            var result = new ServiceResult();
            if (model.Id <= 0)
            {
                result = Create(model);
            }
            else
            {
                result = Update(model);
            }
            return result;
        }

        public ServiceResult Create(DemoView model)
        {
            var result = new ServiceResult();
            var dateNow = DateTime.Now;
            try
            {
                var dbDemo = DemoMapping.FromView(model);
                dbDemo.IsActive = EnumActive.Active.GetHashCode();
                dbDemo.CreatedBy = model.UserAction;

                var dbDemoJoins = new List<DemoJoinModel>();
                if (model.DemoJoins != null && model.DemoJoins.Count() > 0)
                {
                    foreach (var d in model.DemoJoins)
                    {
                        dbDemoJoins.Add(DemoJoinMapping.FromView(d));
                    }
                }

                using (var conn = OpenDbConnection())
                using (var tran = conn.BeginTransaction())
                {
                    var dService = new DemoDao(conn, tran);
                    var jService = new DemoJoinDao(conn, tran);

                    dbDemo = dService.Create(dbDemo);
                    if (model.DemoJoins.Count() > 0)
                    {
                        foreach (var dbDemoJoin in dbDemoJoins)
                        {
                            dbDemoJoin.DemoId = dbDemo.Id;
                            jService.Create(dbDemoJoin);
                        }
                    }
                    tran.Commit();
                }
                result.data = DemoMapping.ToView(dbDemo, dbDemoJoins);               
            }
            catch (Exception ex)
            {
                result.DoError(ex);
            }
            return result;
        }

        public ServiceResult Update(DemoView model)
        {
            var result = new ServiceResult();
            var dateNow = DateTime.Now;
            try
            {
                var dbDemo = GetDbById(model.Id);
                dbDemo = DemoMapping.FromView(dbDemo, model);
                dbDemo.IsActive = EnumActive.Active.GetHashCode();
                dbDemo.UpdatedBy = model.UserAction;

                var dbDemoJoins = DemoJoinService.Instance.GetDbByDemoId(model.Id);
                dbDemoJoins.ForEach(delegate (DemoJoinModel item) { item.IsActive = EnumActive.InActive.GetHashCode(); });
                if (model.DemoJoins != null && model.DemoJoins.Count() > 0)
                {
                    foreach (var d in model.DemoJoins)
                    {
                        if (d.Id <= 0)
                        {
                            dbDemoJoins.Add(DemoJoinMapping.FromView(d));
                        }
                        else
                        {
                            var db = dbDemoJoins.Find(x => x.Id == d.Id);
                            db.IsActive = EnumActive.Active.GetHashCode();
                        }
                    }
                }

                using (var conn = OpenDbConnection())
                using (var tran = conn.BeginTransaction())
                {
                    var dService = new DemoDao(conn, tran);
                    var jService = new DemoJoinDao(conn, tran);

                    dbDemo = dService.Update(dbDemo);
                    if (model.DemoJoins.Count() > 0)
                    {
                        foreach (var dbDemoJoin in dbDemoJoins)
                        {
                            if (dbDemoJoin.Id <= 0)
                            {
                                jService.Create(dbDemoJoin);
                            }
                            else
                            {
                                jService.Update(dbDemoJoin);
                            }
                        }
                    }
                    tran.Commit();
                }
                result.data = DemoMapping.ToView(dbDemo, dbDemoJoins);
            }
            catch (Exception ex)
            {
                result.DoError(ex);
            }
            return result;
        }

        public ServiceResult Delete(int Id, int userId)
        {
            var result = new ServiceResult();
            try
            {
                var DbWithdrawal = GetDbById(Id);

                using (var conn = OpenDbConnection())
                {
                    var bService = new DemoDao(conn);
                    DbWithdrawal.IsActive = EnumActive.InActive.GetHashCode();                 
                    bService.Update(DbWithdrawal);
                }
            }
            catch (Exception ex)
            {
                result.DoError(ex);
            }
            return result;
        }


        #region Mockup Data
        public ServiceResult GetByMId(int id)
        {
            var result = new ServiceResult();

            var details = new List<IDNAME>();
            details.Add(new IDNAME() { Id = 1, Name = "String1" });
            details.Add(new IDNAME() { Id = 2, Name = "String2" });
            details.Add(new IDNAME() { Id = 3, Name = "String3" });
            details.Add(new IDNAME() { Id = 4, Name = "String4" });
            result.data = new DemoView()
            {
                Id = 1,
                DemoString = "DemoString",
                DemoInt = 1,
                DemoDateNullable = DateTime.Now,
                IsActive = 1,
                DemoJoins = details
            };
            return result;
        }
        #endregion
    }
}
