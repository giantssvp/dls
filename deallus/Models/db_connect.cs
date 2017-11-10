using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deallus.Models
{
    public class db_connect
    {
        private MySqlConnection connection;

        private bool OpenConnection()
        {
            string connetionString = null;
            connetionString = "server=182.50.133.77;database=common_db;uid=commonadmin;pwd=Common@123;Allow User Variables=True;";
            connection = new MySqlConnection(connetionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public int Insert(string name, string email, string phone, string comment_type, string msg)
        {
            try
            {
                int id = -1;
                string query = "INSERT INTO deallus_contact (Name, Email_id, Phone, Request_type, Message, Status, Date) VALUES(@name, @email, @phone, @rtype, @msg, @sts, CURDATE())";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@rtype", comment_type);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@msg", msg);
                    cmd.Parameters.AddWithValue("@sts", false);

                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd1 = new MySqlCommand("SELECT LAST_INSERT_ID()", connection);
                    id = Convert.ToInt32(cmd1.ExecuteScalar());

                    this.CloseConnection();
                }
                return id;
            }
            catch (MySqlException ex)
            {
                return -1;
            }
        }              

    } //db_connect class
} // namespace
