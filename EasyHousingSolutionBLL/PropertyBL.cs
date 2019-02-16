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
    public class PropertyBL
    {
        PropertyDAL propertyDAL = new PropertyDAL();

        public bool AddPropertyBL(Property newProperty)
        {
            bool PropertyAdded = false;
            try
            {
                if (ValidateProperty(newProperty))
                {

                    PropertyAdded = propertyDAL.AddPropertyDAL(newProperty);
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

            return PropertyAdded;
        }

        protected bool ValidateProperty(Property newProperty)
        {
            StringBuilder sb = new StringBuilder();

            bool validatelogin = true;

            if (newProperty.Address == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Address Required");
            }
            if (newProperty.PriceRange == -1)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Price Range Required");
            }
            if (newProperty.Description == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Description Required");
            }
            if (newProperty.InitialDeposit == -1)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Initial Deposit Required");
            }
            if (newProperty.Landmark == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Landmark Required");
            }          
            if (newProperty.PropertyName == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Property Name Required");
            }          
            if (newProperty.PropertyType == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Property Type Required");
            }
            if (newProperty.SellerId == -1)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Seller Id Required");
            }

            if (validatelogin == false)
                throw new EasyHousingSolutionException(sb.ToString());
            return validatelogin;

        }

        public List<Property> GetAllPropertyByOwnerBL(string SellerName)
        {
            List<Property> PropertyList = null;
            try
            {
                PropertyList = propertyDAL.GetPropertyByOwnerDAL(SellerName);
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PropertyList;
        }

        public List<Property> GetAllPropertyByRegionBL(string CityName)
        {
            List<Property> PropertyList = null;
            try
            {
                PropertyList = propertyDAL.GetPropertyByRegionDAL(CityName);
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PropertyList;
        }

        public List<Property> GetVerifiedPropertyBL()
        {
            List<Property> PropertyList = null;
            try
            {
                PropertyList = propertyDAL.GetVerifiedPropertyDAL();
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PropertyList;
        }

        public List<Property> GetDeActivatedPropertyBL()
        {
            List<Property> PropertyList = null;
            try

            {
                PropertyList = propertyDAL.GetDeActivatedPropertyDAL();
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PropertyList;
        }

        public List<Property> GetAllPropertyBL()
        {
            List<Property> PropertyList = null;
            try
            {
                PropertyList = propertyDAL.GetAllPropertyDAL();
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PropertyList;
        }

        public bool DeletePropertyBL(int deletePropertyID)
        {
            bool PropertyDeleted = false;
            try
            {
                if (deletePropertyID > 0)
                {
                    PropertyDeleted = propertyDAL.DeletePropertyDAL(deletePropertyID);
                }
                else
                {
                    throw new EasyHousingSolutionException("Invalid Property ID");
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

            return PropertyDeleted;
        }

        public Property SearchPropertyBL(int searchPropertyID)
        {
            Property searchProperty = null;
            try
            {
                searchProperty = propertyDAL.SearchPropertyDAL(searchPropertyID);
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchProperty;

        }

        public bool EditPropertyBL(Property updateProperty)
        {
            bool PropertyUpdated = false;
            try
            {
                if (ValidateProperty(updateProperty))
                {
                    PropertyUpdated = propertyDAL.EditPropertyDAL(updateProperty);
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

            return PropertyUpdated;
        }
  
        public bool VerifyPropertyBL(Property verifyProperty)
        {
            bool propertyVerified = false;
            try
            {

                propertyVerified = propertyDAL.VerifyPropertyDAL(verifyProperty);

            }
            catch (EasyHousingSolutionException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyVerified;
        }

        public bool DeactivatePropertyBL(Property deactivateProperty)
        {
            bool propertyDeactivated = false;
            try
            {

                propertyDeactivated = propertyDAL.DeactivatePropertyDAL(deactivateProperty);

            }
            catch (EasyHousingSolutionException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return propertyDeactivated;
        }


    }
}
