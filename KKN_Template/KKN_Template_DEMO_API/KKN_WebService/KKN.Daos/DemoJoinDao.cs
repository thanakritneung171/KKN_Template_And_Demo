using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KKN.Dao.Extensions;
using KKN.Models;

namespace KKN.Daos
{    
    public interface IDemoJoin
    {

    }

    public class DemoJoinException : Exception
    {
        public DemoJoinException(string msg)
            : base(msg)
        {
        }
    }

    public class DemoJoinDao : IDemo
    {
        private const string READ_BY_ID = "[dbo].DemoJoins_READ_BY_ID";
        private const string CREATE = "[dbo].DemoJoins_CREATE";
        private const string UPDATE = "[dbo].DemoJoins_UPDATE";
        private const string DELETE = "[dbo].DemoJoins_DELETE";

        private const string READ_DEMO_ID = "[dbo].DemoJoins_READ_DEMO_ID";

        private SqlConnection conn;
        private SqlTransaction tran;

        public DemoJoinDao(SqlConnection conn)
        {
            this.conn = conn;
        }
        public DemoJoinDao(SqlConnection conn, SqlTransaction tran)
        {
            this.conn = conn;
            this.tran = tran;
        }

        private DemoJoinModel map(SqlDataReader rdr)
        {
            var model = new DemoJoinModel(rdr.GetInt("Id"));
            model.DemoId = rdr.GetInt("DemoId");
            model.Name = rdr.GetString("Name");           
            model.IsActive = rdr.GetInt("IsActive");           
            return model;
        }

        internal static DemoJoinModel mapView(SqlDataReader rdr)
        {
            var model = new DemoJoinModel(rdr.GetInt("DemoJoin_Id"));
            model.DemoId = rdr.GetInt("DemoJoin_Id");
            model.Name = rdr.GetString("DemoJoin_Name");
            model.IsActive = rdr.GetInt("DemoJoin_IsActive");
            return model;
        }

        public DemoJoinModel GetById(int Id)
        {
            SqlCommand cmd = new SqlCommand(READ_BY_ID, conn);
            cmd.AddIntParameter("Id", Id);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DemoJoinModel result = null;
            using (var rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = map(rdr);
                }
            }
            return result;
        }

        public DemoJoinModel Create(DemoJoinModel model)
        {
            SqlCommand cmd = new SqlCommand(CREATE, conn);
            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            cmd.AddIntParameter("DemoId", model.DemoId);
            cmd.AddNVarcharParameter("Name", model.Name);         
            cmd.AddIntParameter("IsActive", model.IsActive);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DemoJoinModel result = null;
            using (var rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = map(rdr);
                }
            }
            return result;
        }

        public DemoJoinModel Update(DemoJoinModel model)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            cmd.AddIntParameter("Id", model.Id);
            cmd.AddIntParameter("DemoId", model.DemoId);
            cmd.AddNVarcharParameter("Name", model.Name);
            cmd.AddIntParameter("IsActive", model.IsActive);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DemoJoinModel result = null;
            using (var rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                if (rdr.HasRows)
                {
                    result = map(rdr);
                }
            }
            return result;
        }

        public void Delete(int id, int userId)
        {
            SqlCommand cmd = new SqlCommand(DELETE, conn);
            cmd.AddIntParameter("Id", id);
            cmd.AddIntParameter("UpdatedBy", userId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var rdr = cmd.ExecuteReader())
            {
                int rowsAffected = rdr.RecordsAffected;
            }
        }

        public List<DemoJoinModel> GetByDemoId(int Id)
        {
            SqlCommand cmd = new SqlCommand(READ_DEMO_ID, conn);
            cmd.AddIntParameter("DemoId", Id);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            List<DemoJoinModel> result = new List<DemoJoinModel>();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    result.Add(map(rdr));
                }
            }
            return result;
        }
    }
}
