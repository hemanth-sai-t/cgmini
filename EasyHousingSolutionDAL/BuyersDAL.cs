using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHousingSolutionEntity;
using System.Data;
using System.Data.SqlClient;
using EHSException;

namespace EasyHousingSolutionDAL
{
    public class BuyersDAL
    {
        SqlConnection connection = new SqlConnection(GlobalData.ConnectionString);
        public bool AddBuyerDAL(Buyer newBuyer)
        {
            bool BuyerAdded = false;
            try
            {
                string Query = "Project1.uspAddBuyer";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", newBuyer.UserName);
                command.Parameters.AddWithValue("@FirstName", newBuyer.FirstName);
                command.Parameters.AddWithValue("@LastName", newBuyer.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", newBuyer.DateOfBirth);
                command.Parameters.AddWithValue("@PhoneNumber", newBuyer.PhoneNo);
                command.Parameters.AddWithValue("@EmailId", newBuyer.EmailId);
                command.Parameters.AddWithValue("@Adress", newBuyer.Address);
                //command.Parameters.AddWithValue("@Password", newBuyer.Address);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                BuyerAdded = true;
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
            return BuyerAdded;
        }

        public List<Buyer> GetAllBuyersDAL()
        {
            try
            {
                List<Buyer> BuyerList = new List<Buyer>();
                string Query = "Project1.uspDisplayBuyer";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Buyer s = new Buyer();
                        s.BuyerId = int.Parse(Reader[0].ToString());
                        s.FirstName = Reader[1].ToString();
                        s.LastName = Reader[2].ToString();
                        s.DateOfBirth = DateTime.Parse(Reader[3].ToString());
                        s.PhoneNo = long.Parse(Reader[4].ToString());
                        s.EmailId = Reader[5].ToString();
                        BuyerList.Add(s);
                    }
                }
                connection.Close();
                return BuyerList;
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
        }

        public int getBuyerIdDAL(string BuyerName)
        {
            int BuyerId = 0;
            try
            {
                string Query = "Project1.uspGetBuyerId";
                SqlCommand command = new SqlCommand(Query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", BuyerName);

                connection.Open();
                Object RetrievedBuyerId = command.ExecuteScalar().ToString();
                BuyerId = int.Parse(RetrievedBuyerId.ToString());
                connection.Close();
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
            return BuyerId;
        }
    }
}
