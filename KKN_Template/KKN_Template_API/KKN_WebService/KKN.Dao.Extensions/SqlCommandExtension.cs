using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKN.Dao.Extensions
{
    public static class SqlCommandExtension
    {
        private static readonly string PARAM_PREFIX = "@";

        private static string createParameterName(string paramName)
        {
            return PARAM_PREFIX + paramName;
        }

        private static void AddParameter(SqlCommand cmd, string paramName, System.Data.SqlDbType paramType, object paramVal, System.Data.ParameterDirection paramDirection)
        {
            var param = new SqlParameter(createParameterName(paramName), paramType);
            if (paramVal != null)
            {
                param.Value = paramVal;
            }
            else
            {
                param.Value = DBNull.Value;
            }
            param.Direction = paramDirection;
            cmd.Parameters.Add(param);
        }


        public static void AddByteParameter(this SqlCommand cmd, string paramName, byte? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Int, paramVal, paramDirection);
        }

        public static void AddByteArrayParameter(this SqlCommand cmd, string paramName, byte[] paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Binary, paramVal, paramDirection);
        }

        public static void AddIntParameter(this SqlCommand cmd, string paramName, int? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Int, paramVal, paramDirection);
        }

        public static void AddBigIntParameter(this SqlCommand cmd, string paramName, long? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.BigInt, paramVal, paramDirection);
        }

        public static void AddDateTimeParameter(this SqlCommand cmd, string paramName, DateTime? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.DateTime, paramVal, paramDirection);
        }

        public static void AddDecimalParameter(this SqlCommand cmd, string paramName, decimal? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Decimal, paramVal, paramDirection);
        }

        public static void AddVarcharParameter(this SqlCommand cmd, string paramName, string paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.VarChar, paramVal, paramDirection);
        }

        public static void AddNVarcharParameter(this SqlCommand cmd, string paramName, string paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.NVarChar, paramVal, paramDirection);
        }

        public static void AddNTextParameter(this SqlCommand cmd, string paramName, string paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.NText, paramVal, paramDirection);
        }

        public static void AddBitParameter(this SqlCommand cmd, string paramName, bool? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Bit, paramVal, paramDirection);
        }

        public static void AddImageParameter(this SqlCommand cmd, string paramName, byte[] paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.VarBinary, paramVal, paramDirection);
        }

        public static void AddFloatParameter(this SqlCommand cmd, string paramName, float? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Float, paramVal, paramDirection);
        }

        public static void AddDoubleParameter(this SqlCommand cmd, string paramName, double? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Float, paramVal, paramDirection);
        }

        public static void AddSmallIntParameter(this SqlCommand cmd, string paramName, double? paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.SmallInt, paramVal, paramDirection);
        }
        public static void AddXmlParameter(this SqlCommand cmd, string paramName, string paramVal, System.Data.ParameterDirection paramDirection = System.Data.ParameterDirection.Input)
        {
            AddParameter(cmd, paramName, System.Data.SqlDbType.Xml, paramVal, paramDirection);
        }
    }
}
