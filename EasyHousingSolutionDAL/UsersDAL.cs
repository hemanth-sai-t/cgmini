using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHousingSolutionEntity;
using System.Data;
using System.Data.SqlClient;
using EHSException;
using System.Windows;

namespace EasyHousingSolutionDAL
{
  public class UsersDAL
    {
        SqlConnection connection = new SqlConnection(GlobalData.ConnectionString);
        public bool AddUserDAL(Users newUser)
        {
            bool UserAdded = false;
            try
            {
                string Query = "Project1.uspAddUser";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserName", newUser.UserName);
                command.Parameters.AddWithValue("@UserType", newUser.UserType);
                command.Parameters.AddWithValue("@Pasword", newUser.Password);
               
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                UserAdded = true;
            }
            catch (Exception ex)
            {
                throw new EasyHousingSolutionException(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return UserAdded;
        }      

        public bool getUserPassword(Users user)
        {
            bool IsPasswordMatch = false;
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Project1.uspGetPassword";
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@UserType", user.UserType);

                command.Connection = connection;
                connection.Open();
                object retrievePassword = command.ExecuteScalar().ToString();
                IsPasswordMatch = false;
                if (retrievePassword != null && user.Password == retrievePassword.ToString())
                {
                    IsPasswordMatch = true;
                }
                else
                {
                    MessageBox.Show("Invalid details...");
                }
            }
            catch (Exception ex)
            {
                throw new EasyHousingSolutionException(ex.Message);
                
            }
            
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return IsPasswordMatch;
        }
    }
}
