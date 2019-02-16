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
    public class UserBL
    {
        UsersDAL usersDAL = new UsersDAL();
        protected bool ValidateUsers(Users usersToValidate)
        {
            StringBuilder sb = new StringBuilder();

            bool validateusers = true;

            if (usersToValidate.UserName == string.Empty)
            {
                validateusers = false;
                sb.Append(Environment.NewLine + "User Name Required");
            }
            if (usersToValidate.Password == string.Empty)
            {
                validateusers = false;
                sb.Append(Environment.NewLine + "Password Required");
            }
                   

            if (usersToValidate.Password.ToString().Length < 8)
            {
                validateusers = false;
                sb.Append(Environment.NewLine + "Password should be of atleast 8 characters");
            }
            if (usersToValidate.UserType.ToString() == "Select")
            {
                validateusers = false;
                sb.Append(Environment.NewLine + "UserType Required");
            }
            if (validateusers == false)
                throw new EHSException.EasyHousingSolutionException(sb.ToString());
            return validateusers;
        }
        public bool AddUserBL(Users newUser)
        {
            bool UserAdded = false;
            try
            {
                if (ValidateUsers(newUser))
                {
                    UserAdded = usersDAL.AddUserDAL(newUser);
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

            return UserAdded;
        }
        public bool getPasswordBLL(Users users)
        {
            bool IsUserValid = false;
            try
            {
                if (ValidateLogin(users))
                {
                    IsUserValid = usersDAL.getUserPassword(users);
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

            return IsUserValid;
        }
        protected bool ValidateLogin(Users users)
        {
            StringBuilder sb = new StringBuilder();

            bool validatelogin = true;

            if (users.UserName == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "User Name Required");
            }
            if (users.Password == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Password Required");
            }
            if (users.UserType == string.Empty)
            {
                validatelogin = false;
                sb.Append(Environment.NewLine + "Password Required");
            }

            if (validatelogin == false)
                throw new EasyHousingSolutionException(sb.ToString());
            return validatelogin;

        }

    }
}
