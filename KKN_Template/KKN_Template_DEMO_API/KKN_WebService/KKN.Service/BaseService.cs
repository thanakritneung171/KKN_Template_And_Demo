using KKN.Service.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Service
{
    public abstract class BaseService
    {
        private SqlConnection conn;
        private SqlTransaction tran;

        protected SqlConnection OpenDbConnection()
        {
            string connString = AppConfig.KKNDbConnectionString();
            conn = new SqlConnection(connString);
            conn.Open();
            return conn;
        }

        protected SqlTransaction OpenDbTransaction()
        {
            tran = conn.BeginTransaction();
            return tran;
        }

        protected void CommitData()
        {
            if (tran != null)
            {
                tran.Commit();
            }
        }

        protected void RollbackData()
        {
            if (tran != null)
            {
                tran.Rollback();
            }
        }
    }   
}
