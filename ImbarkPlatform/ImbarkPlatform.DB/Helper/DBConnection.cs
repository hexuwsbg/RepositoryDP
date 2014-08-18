using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ImbarkPlatform.DB.Helper
{
    public class DBConnection
    {
        private SqlTransaction trans = null;
        private SqlConnection conn = null;
        private bool isTransaction = false;
        /// <summary>
        /// 获得Db连接对象
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public static DBConnection GetConnection(string ConnectionString)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            DBConnection dbConn = new DBConnection();

            sqlConn.Open();
            dbConn.trans = sqlConn.BeginTransaction();
            dbConn.conn = sqlConn;

            return dbConn;
        }

        public void Open(Boolean isTransaction)
        {
            conn.Open();
            this.isTransaction = isTransaction;
        }

        public void Open()
        {
           
            conn.Open();
        }

        public void CommitTransaction()
        {
            if (trans != null)
            {
                trans.Commit();
            }
        }

        public void RollbackTransaction()
        {
            if (trans != null)
            {
                trans.Rollback();
            }
        }

        public void Close()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }



        public static DBConnection GetConnectionNoTran(string ConnectionString)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            DBConnection dbConn = new DBConnection();

            sqlConn.Open();
            dbConn.conn = sqlConn;

            return dbConn;
        }
        /// <summary>
        /// 查询结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteDateTable(string sql, Hashtable param,Boolean isRollBack = false)
        {
            SqlCommand sqlCmd = null;
            DataSet ds = new DataSet();
            try
            {
                sqlCmd = new SqlCommand(sql, trans.Connection, trans);
                sqlCmd.CommandTimeout = 30;

                SetParameter(sqlCmd, param);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCmd;

                da.Fill(ds);

            }
            catch (Exception e)
            {
                if (isRollBack)
                {
                    if (trans != null)
                    {
                        try
                        {
                            trans.Rollback();
                        }
                        catch
                        {

                        }
                    }
                }
                throw e;
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 查询结果集，返回DataTable，没有事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable ExecuteDateTableNoTran(string sql, Hashtable param)
        {
            SqlCommand sqlCmd = null;
            DataSet ds = new DataSet();
            try
            {
                sqlCmd = new SqlCommand();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = sql;

                SetParameter(sqlCmd, param);

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCmd;

                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ds.Tables[0];
        }
        /// <summary>
        /// 查询结果集，没有事务
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReaderNoTran(string sql, Hashtable param)
        {
            SqlCommand sqlCmd = new SqlCommand();
           
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = sql;
                SetParameter(sqlCmd, param);
                SqlDataReader rdr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        /// <summary>
        /// 执行SQL语句。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns>DataSet</returns>
        public Object ExecuteScalar(string sql, Hashtable param, Boolean isRollBack = false)
        {
            SqlCommand sqlCmd = null;
            try
            {
                sqlCmd = new SqlCommand(sql, trans.Connection, trans);
                sqlCmd.CommandTimeout = 30;

                SetParameter(sqlCmd, param);

                return (Object)sqlCmd.ExecuteScalar();

            }
            catch (Exception e)
            {
                if (isRollBack)
                {
                    if (trans != null)
                    {
                        try
                        {
                            trans.Rollback();
                        }
                        catch
                        {

                        }
                    }
                }
                throw e;
            }
        }

        /// <summary>
        /// 执行SQL语句。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns>影响的数据行数</returns>
        public int ExecuteNonQuery(string sql, Hashtable param, Boolean isRollBack = false)
        {
            SqlCommand sqlCmd = null;
            int resultCount;
            try
            {
                sqlCmd = new SqlCommand(sql, trans.Connection, trans);
                sqlCmd.CommandTimeout = 30;

                SetParameter(sqlCmd, param);

                resultCount = sqlCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                if (isRollBack)
                {
                    if (trans != null)
                    {
                        try
                        {
                            trans.Rollback();
                        }
                        catch
                        {

                        }
                    }
                }
                throw e;
            }


            return resultCount;
        }

        /// <summary>
        /// 为SqlCommand填充参数。
        /// </summary>
        /// <param name="sqlCmd">SqlCommand	</param>
        /// <param name="param">参数</param>
        private static void SetParameter(SqlCommand sqlCmd, Hashtable param)
        {
            sqlCmd.Parameters.Clear();
            if (param != null)
            {
                foreach (string key in param.Keys)
                {
                    sqlCmd.Parameters.Add(new SqlParameter("@" + key, param[key] == null ? DBNull.Value : param[key]));
                }
            }
        }
    }
}