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

        /*
         open database connection
         Function name: open connection
         Args: 

         **/
        private bool OpenConnection()
        {
            string connetionString = null;
            connetionString = "server=182.50.133.77;database=dls_gst;uid=gstadmin;pwd=Gstadmin@123;Allow User Variables=True;";
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

        /*
         close database connection
         Function name: close connection
         Args: 

         **/
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

        /*
         Insert contat info in database 
         Function name: insert
         Args: 
         name:
         email:
         phone:
         comment_type: enquiry, feedback, other
         msg:
         **/
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

        /*
         Login in database 
         Function name: login
         Args: 
         username:
         password:
         **/

        public Boolean Login(string name, string password)
        {
            try
            {
                MySqlDataReader rdr;
                string query = "select * from gst_profile where username = @name and password = @password";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        this.CloseConnection();
                        return true;
                    }
                }
                this.CloseConnection();
                return false;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        /*Login Section*/

    } //db_connect class
} // namespace
