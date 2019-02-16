using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHousingSolutionDAL;
using EasyHousingSolutionEntity;
using EHSException;

namespace EasyHousingSolutionBLL
{
    public class BuyersBL
    {
        BuyersDAL buyersDAL = new BuyersDAL();
        public bool AddBuyerBL(Buyer newBuyer)
        {
            bool BuyerAdded = false;
            try
            {
                if (ValidateBuyer(newBuyer))
                {
                    BuyerAdded = buyersDAL.AddBuyerDAL(newBuyer);
                }
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return BuyerAdded;
        }
        protected bool ValidateBuyer(Buyer newBuyer)
        {
            StringBuilder sb = new StringBuilder();

            bool validatebuyer = true;

            if (newBuyer.UserName == string.Empty)
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "User Name Required");
            }
            if (newBuyer.FirstName == string.Empty)
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "First Name Required");
            }
            if (newBuyer.LastName == string.Empty)
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "Last Name Required");
            }
            if (newBuyer.DateOfBirth== DateTime.Parse("01-01-1000 00:00:00"))
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "Date of birth Required");
            }
            if (newBuyer.PhoneNo == 0 || newBuyer.PhoneNo.ToString().Length!=10)
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "Phone number 10 digit Required");
            }
            if (newBuyer.Address == string.Empty)
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "Address Required");
            }
            if (newBuyer.EmailId == string.Empty)
            {
                validatebuyer = false;
                sb.Append(Environment.NewLine + "Email Required");
            }


            if (validatebuyer == false)
                throw new EHSException.EasyHousingSolutionException(sb.ToString());
            return validatebuyer;

        }

        public List<Buyer> GetAllBuyersBL()
        {            
                List<Buyer> BuyerList = null;
                try
                {
                    BuyerList = buyersDAL.GetAllBuyersDAL();
                }
                catch (EasyHousingSolutionException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return BuyerList;
           
        }

        public int getBuyerIdBL(string BuyerName)
        {
            try
            {
                int BuyerId = buyersDAL.getBuyerIdDAL(BuyerName);
                return BuyerId;
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
