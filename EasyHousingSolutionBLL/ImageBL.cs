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
    public class ImageBL
    {
        ImagesDAL imagesDAL = new ImagesDAL();
        public bool AddImageBL(Images newImage)
        {
            bool ImageAdded = false;
            try
            {               
                ImageAdded = imagesDAL.AddImageDAL(newImage);             
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ImageAdded;
        }

        public Images GetImageBL(int PropertyId)
        {            
            Images obj = new Images();
            try
            {
                obj = imagesDAL.GetImageDAL(PropertyId);
            }
            catch (EasyHousingSolutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
