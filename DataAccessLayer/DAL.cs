using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Util;

namespace DataAccessLayer
{
    public class DAL
    {
        private static string connectionString = "";
        private static string dbHost = "";
        private static string dbName = "";
        private static string dbUsername = "";
        private static string dbPassword = "";
        protected SqlDataAdapter adapter;
        protected SqlConnection connection;
        protected DataSet dataSet;
        private bool connected;
        private int lastUpdatedRows;

        static DAL()
        {
            GenerateConnectionString();
        }

        public int LastUpdatedRows
        {
            get { return lastUpdatedRows; }
        }

        public static void SetLogin(string username, string password)
        {
            string anull = null;
            SetLogin(username, password, ref anull);
        }

        protected static void SetLogin(string username, string password, ref string toConnectionString)
        {
            dbUsername = username;
            dbPassword = password;
            if (toConnectionString == null)
            {
                connectionString = GenerateConnectionString();
            }
            else
            {
                toConnectionString = GenerateConnectionString();
            }
        }

        public static void SetDatabase(string host, string db)
        {
            dbHost = host;
            dbName = db;
            connectionString = GenerateConnectionString();
        }

        private static string GenerateConnectionString()
        {
            var cs =
                "Data Source=%host%;Initial Catalog=%db%;Persist Security Info=False;User ID=%login%;Password=%password%"
                    .Replace("%host%", dbHost).Replace("%db%", dbName).Replace("%login%", dbUsername).Replace("%password%", dbPassword);
            return cs;
        }

        protected DAL() { }

        private void CheckConnection()
        {
            if (connection != null && connected) return;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                connected = true;
                connection.Close();
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
        }

        protected void ResetConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection = null;
            CheckConnection();
        }

        protected bool Select(String query)
        {
            try
            {
                CheckConnection();
                dataSet = new DataSet();
                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataSet);
                return true;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Log("Query error! Query was: " + query);
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        protected bool Execute(String query)
        {
            return Execute(new SqlCommand {CommandType = CommandType.Text, CommandText = query});
        }

        protected bool Execute(SqlCommand command)
        {
            try
            {
                CheckConnection();
                command.Connection = connection;
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                lastUpdatedRows = command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Log("SQL exception in query:" + command.CommandText);
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        protected bool Execute(string name, Hashtable parameters)
        {
            try
            {
                CheckConnection();
                dataSet = new DataSet();
                var callCommand = BuildSpCommand(name, parameters);
                adapter = new SqlDataAdapter(callCommand);
                adapter.Fill(dataSet);
                return true;
            }
            catch (SqlException ex)
            {
                Logger.Instance.Exception(this, ex);
                return false;
            }
        }

        protected int ExecuteScalar(string name, Hashtable parameters)
        {
            try
            {
                CheckConnection();
                var callCommand = BuildSpCommand(name, parameters);
                var returnValue = new SqlParameter { ParameterName = "@Ret", Direction = ParameterDirection.ReturnValue, DbType = DbType.Int32 };
                callCommand.Parameters.Add(returnValue);
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                callCommand.ExecuteNonQuery();

                var ret = callCommand.Parameters["@Ret"].Value.ToString();
                if (ret.Equals("")) ret = "-1";
                connection.Close();
                Logger.Instance.Log("Return value of SP " + name + " = " + ret);
                return int.Parse(ret);
            }
            catch (SqlException ex)
            {
                Logger.Instance.Exception(this, ex);
                return -1;
            }
        }

        protected SqlCommand BuildSpCommand(string name, Hashtable parameters)
        {
            var command = new SqlCommand(name, connection) { CommandType = CommandType.StoredProcedure };
            if (parameters != null)
            {
                foreach (DictionaryEntry i in parameters)
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = (string)i.Key, Value = i.Value });
                }
            }
            return command;
        }

        public DataSet Data()
        {
            return dataSet;
        }

        public DataTable Table()
        {
            try
            {
                return dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
            return new DataTable();
        }

        public DataRow Row()
        {
            try
            {
                return dataSet.Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
            return null;
        }

        protected object Scalar()
        {
            try
            {
                return dataSet.Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                Logger.Instance.Exception(this, ex);
            }
            return null;
        }
    }
}