using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Erc1.DAL
{
    public class DataLayer
    {
        string server_name;
        string database_name;
        SqlConnection con;
        public bool IsValid = false;
        public DataLayer(string ServerName, string DataBaseName)
        {
            server_name = ServerName;
            database_name = DataBaseName;
            VerifyConnection();
        }

        private void VerifyConnection()
        {
            con = new SqlConnection(@"Data Source=" + server_name + ";Initial Catalog=" + database_name + ";Integrated Security=True");
            try
            {
                con.Open();
                con.Close();
                IsValid = true;
            }
            catch
            {
                IsValid = false;
            }
        }
        public void SetServerName(string ServerName)
        {
            server_name = ServerName;
            VerifyConnection();
        }
        public string GetServerName()
        {
            return server_name;
        }
        public void SetDataBaseName(string DataBaseName)
        {
            database_name = DataBaseName;
            VerifyConnection();
        }
        public string GetDataBaseName()
        {
            return database_name;
        }

        public int ExecuteActionCommand(string CommandText)
        {
            int rep = 0;

            if ((IsValid) && (CommandText.Length > 0))
            {
                con.Open();
                SqlCommand com = new SqlCommand(CommandText, con);
                try
                {
                    rep = com.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
            }
            return rep;
        }
        public object GetValue(string SqlText)
        {
            if ((IsValid) && (SqlText.Length > 0))
            {
                object v = null;
                SqlCommand com = new SqlCommand(SqlText, con);
                con.Open();
                try
                {
                    v = com.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
                return v;
            }
            else return null;
        }


        public DataTable GetData(string SqlText, object[,] Parameters, string name)
        {
            DataTable dt = new DataTable();
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.Length / 2; i++)
                    com.Parameters.Add(new SqlParameter
                    (Parameters[0, i].ToString(), Parameters[1, i]));
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    data_adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    dt = null;
                }
                con.Close();
                dt.TableName = name;
                return dt;
            }
            else return null;
        }

        public void ExecuteActionCommand(string CommandText, object[,] Parameters)
        {
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(CommandText, con);
                com.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameters.Length / 2; i++)
                {
                    com.Parameters.Add(new SqlParameter
                      (Parameters[0, i].ToString(), Parameters[1, i]));
                }
                con.Open();
                try
                {
                    com.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Not Executed");
                }
                con.Close();
            }
        }

        public object GetValue(string SqlText, object[,] Parameters)
        {
            object v = null;
            if (IsValid)
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.Text;
                string param = "(";
                for (int i = 0; i < Parameters.Length / 2; i++)
                {
                    com.Parameters.Add(new SqlParameter
                      (Parameters[0, i].ToString(), Parameters[1, i]));
                    param += Parameters[0, i].ToString() + ",";
                }
                param = param.Substring(0, param.Length - 1);
                param += ")";
                com.Connection = con;
                com.CommandText = "select dbo." + SqlText + param;
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    v = com.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
                con.Close();
                return v;
            }
            else return null;
        }

        public DataTable GetData(string SqlText, string name)
        {
            DataTable dt = new DataTable();
            if (IsValid)
            {
                SqlCommand com = new SqlCommand(SqlText, con);
                com.CommandType = CommandType.Text;
                SqlDataAdapter data_adapter = new SqlDataAdapter(com);
                con.Open();
                try
                {
                    data_adapter.Fill(dt);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                    dt = null;
                }
                con.Close();
                dt.TableName = name;
                return dt;
            }
            else return null;
        }
    }
}
