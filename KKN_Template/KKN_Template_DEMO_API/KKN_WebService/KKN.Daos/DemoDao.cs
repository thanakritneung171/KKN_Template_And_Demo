using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using KKN.Dao.Extensions;
using KKN.Models;

namespace KKN.Daos
{    
    public interface IDemo
    {

    }

    public class DemoException : Exception
    {
        public DemoException(string msg)
            : base(msg)
        {
        }
    }

    public class DemoDao : IDemo
    {
        private const string READ_BY_ID = "[dbo].Demos_READ_BY_ID";
        private const string CREATE = "[dbo].Demos_CREATE";
        private const string UPDATE = "[dbo].Demos_UPDATE";
        private const string DELETE = "[dbo].Demos_DELETE";
        //Custom
        private const string SEARCH = "[dbo].Demos_SEARCH";        

        private SqlConnection conn;
        private SqlTransaction tran;

        public DemoDao(SqlConnection conn)
        {
            this.conn = conn;
        }
        public DemoDao(SqlConnection conn, SqlTransaction tran)
        {
            this.conn = conn;
            this.tran = tran;
        }

        private DemoModel map(SqlDataReader rdr)
        {
            var model = new DemoModel(rdr.GetInt("Demo_Id"));
            model.DemoString = rdr.GetString("Demo_DemoString");
            model.DemoInt = rdr.GetInt("Demo_DemoInt");
            model.DemoIntNullable = rdr.GetIntNullable("Demo_DemoIntNullable");
            model.DemoDate = rdr.GetDateTime("Demo_DemoDate");
            model.DemoDateNullable = rdr.GetDateTimeNullable("Demo_DemoDateNullable");
            model.DemoDecimal = rdr.GetDecimal("Demo_DemoDecimal");
            model.DemoDecimalNullable = rdr.GetDecimalNullable("Demo_DemoDecimalNullable");
            model.DemoBoolean = rdr.GetBool("Demo_DemoBit");
            model.DemoBooleanNullable = rdr.GetBoolNullable("Demo_DemoBitNullable");
            model.IsActive = rdr.GetInt("Demo_IsActive");
            model.CreatedBy = rdr.GetInt("Demo_CreatedBy");
            model.CreatedDate = rdr.GetDateTime("Demo_CreatedDate");
            model.UpdatedBy = rdr.GetIntNullable("Demo_UpdatedBy");
            model.UpdatedDate = rdr.GetDateTimeNullable("Demo_UpdatedDate");

            if (!rdr.IsDBNull(rdr.GetOrdinal("DemoJoin_Id")))
            {
                model.Detail = DemoJoinDao.mapView(rdr);
            }
            return model;
        }

        public DemoModel GetById(int Id)
        {
            SqlCommand cmd = new SqlCommand(READ_BY_ID, conn);
            cmd.AddIntParameter("Id", Id);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DemoModel result = null;
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

        public DemoModel Create(DemoModel model)
        {
            SqlCommand cmd = new SqlCommand(CREATE, conn);
            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            cmd.AddNVarcharParameter("DemoString", model.DemoString);
            cmd.AddIntParameter("DemoInt", model.DemoInt);
            cmd.AddIntParameter("DemoIntNullable", model.DemoIntNullable);
            cmd.AddDateTimeParameter("DemoDate", model.DemoDate);
            cmd.AddDateTimeParameter("DemoDateNullable", model.DemoDateNullable);
            cmd.AddDecimalParameter("DemoDecimal", model.DemoDecimal);
            cmd.AddDecimalParameter("DemoDecimalNullable", model.DemoDecimalNullable);
            cmd.AddBitParameter("DemoBoolean", model.DemoBoolean);
            cmd.AddBitParameter("DemoBooleanNullable", model.DemoBooleanNullable);
            cmd.AddIntParameter("IsActive", model.IsActive);
            cmd.AddIntParameter("CreatedBy", model.CreatedBy);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DemoModel result = null;
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

        public DemoModel Update(DemoModel model)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            cmd.AddIntParameter("Id", model.Id);
            cmd.AddNVarcharParameter("DemoString", model.DemoString);
            cmd.AddIntParameter("DemoInt", model.DemoInt);
            cmd.AddIntParameter("DemoIntNullable", model.DemoIntNullable);
            cmd.AddDateTimeParameter("DemoDate", model.DemoDate);
            cmd.AddDateTimeParameter("DemoDateNullable", model.DemoDateNullable);
            cmd.AddDecimalParameter("DemoDecimal", model.DemoDecimal);
            cmd.AddDecimalParameter("DemoDecimalNullable", model.DemoDecimalNullable);
            cmd.AddBitParameter("DemoBoolean", model.DemoBoolean);
            cmd.AddBitParameter("DemoBooleanNullable", model.DemoBooleanNullable);
            cmd.AddIntParameter("IsActive", model.IsActive);
            cmd.AddIntParameter("UpdatedBy", model.UpdatedBy);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DemoModel result = null;
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

        public DemoListModel GetBySearch(DemoModel model, int demoJoinId)
        {
            SqlCommand cmd = new SqlCommand(SEARCH, conn);
            cmd.AddNVarcharParameter("DemoString", model.DemoString);
            cmd.AddIntParameter("DemoInt", model.DemoInt);
            cmd.AddIntParameter("DemoIntNullable", model.DemoIntNullable);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.AddIntParameter("Count", 0, System.Data.ParameterDirection.Output);
            var result = new DemoListModel();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    result.Details.Add(map(rdr));
                }
                result.Count = Convert.ToInt32(cmd.Parameters["@Count"].Value);
            }
            return result;
        }
    }
}
