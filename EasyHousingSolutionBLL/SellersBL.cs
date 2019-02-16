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
    public class SellersBL
    {
        SellersDAL sellerDAL = new SellersDAL();
        public bool AddSellerBL(Seller newSeller)
        {
            bool SellerAdded = false;
            try
            {
                if (ValidateSeller(newSeller))
                {

                    SellerAdded = sellerDAL.AddSellerDAL(newSeller);
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

            return SellerAdded;
        }

        protected bool ValidateSeller(Seller newSeller)
        {
            StringBuilder sb = new StringBuilder();

            bool validateSeller = true;

            if (newSeller.UserName == string.Empty)
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "User Name Required");
            }
            if (newSeller.FirstName == string.Empty)
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "First Name Required");
            }
            if (newSeller.LastName == string.Empty)
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "Last Name Required");
            }
            if (newSeller.DateofBirth == DateTime.Parse("01-01-1000 00:00:00"))
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "Date of birth Required");
            }
            if (newSeller.PhoneNo == 0 || newSeller.PhoneNo.ToString().Length != 10)
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "Phone number 10 digit Required");
            }
            if (newSeller.Address == string.Empty)
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "Address Required");
            }
            if (newSeller.EmailId == string.Empty)
            {
                validateSeller = false;
                sb.Append(Environment.NewLine + "Email Required");
            }
            if (validateSeller == false)
                throw new EHSException.EasyHousingSolutionException(sb.ToString());
            return validateSeller;

        }
     
    }
}
