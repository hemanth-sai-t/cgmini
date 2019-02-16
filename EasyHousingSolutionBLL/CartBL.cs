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
    public class CartBL
    {
        CartDAL cartDAL = new CartDAL();
        public bool AddCartBL(Cart newCart)
        {
            bool CartAdded = false;
            try
            {               
                CartAdded = cartDAL.AddCartDAL(newCart);                
            }
            catch (EasyHousingSolutionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CartAdded;
        }

        public List<Property> GetAllCartsBL()
        {
            List<Property> CartList = null;
            try
            {
                CartList = cartDAL.GetAllCartDAL();
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CartList;
        }
        public bool DeleteCartBL(string propName)
        {
            bool CartDeleted = false;
            try
            {                
                    CartDeleted = cartDAL.DeleteCartDAL(propName);                              
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CartDeleted;
        }
    }
}
