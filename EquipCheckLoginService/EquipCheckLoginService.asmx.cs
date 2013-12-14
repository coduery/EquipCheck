using EquipCheckLoginService.Domain;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

namespace EquipCheckLoginService
{
    /// <summary>
    /// Summary description for EquipCheckLoginService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EquipCheckLoginService : System.Web.Services.WebService
    {
        /// <summary>
        /// Method for authenticating users.
        /// </summary>
        /// <param name="appUser">Incoming EquipCheckAppUser</param>
        /// <returns>Returns an EquipCheckAppUser or null if the user cannot be authenticated.</returns>
        [WebMethod]
        public EquipCheckAppUser AuthenticateUser(EquipCheckAppUser appUser)
        {
            Console.WriteLine("User Authentication Process Started.");

            string connectionString = ConfigurationManager.ConnectionStrings["AspNetDB"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlDataReader reader = null;

            try
            {
                String sqlString = "SELECT * FROM aspnet_Users INNER JOIN aspnet_Membership " +
                                   "ON aspnet_Users.UserId = aspnet_Membership.UserId " +
                                   "WHERE aspnet_Users.UserName = @username " +
                                   "AND aspnet_Membership.Password = @password";

                SqlCommand command = new SqlCommand(sqlString, sqlConnection);
                command.Parameters.AddWithValue("@username", appUser.Username);
                command.Parameters.AddWithValue("@password", appUser.Password);

                sqlConnection.Open();
                reader = command.ExecuteReader();

                appUser = null;

                while (reader.Read())
                {
                    appUser = new EquipCheckAppUser();
                    appUser.Username = (String)reader["username"];
                    appUser.Password = (String)reader["password"];
                }
            }
            catch (Exception e)
            {
                appUser = null;
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            if (appUser != null)
            {
                Console.WriteLine("User Successfully Authenticated!");
            }
            else
            {
                Console.WriteLine("User Authentication Failed!  Invalid Credentials.");
            }

            Console.WriteLine();

            return appUser;
        }
    }
}
