using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALProductCategory
    {
        //Commit by HASH Khan
        Entities _dbContext = new Entities();
        POS_PRODUCT_CATEGORY _objProductCategoryEntity = new POS_PRODUCT_CATEGORY();
        public List<POS_PRODUCT_CATEGORY> GetProductCategory()
        {
            List<POS_PRODUCT_CATEGORY> lst = new List<POS_PRODUCT_CATEGORY>();
            try
            {
                lst = _dbContext.POS_PRODUCT_CATEGORY.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_PRODUCT_CATEGORY GetById(long? id)
        {
            try
            {
                _objProductCategoryEntity = _dbContext.POS_PRODUCT_CATEGORY.Find(id);
                return _objProductCategoryEntity;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public long GetMaxId()
        {
            long id = 0;
            try
            {
                _objProductCategoryEntity = _dbContext.POS_PRODUCT_CATEGORY.OrderByDescending(x => x.CATEGORY_ID).FirstOrDefault();
                if (_objProductCategoryEntity.CATEGORY_ID.ToString() == null)
                    id = 1;
                else
                    id = _objProductCategoryEntity.CATEGORY_ID + 1;

                return id;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public string GetMaxCode()
        {
            string code = string.Empty;
            int maxCode = 0;
            try
            {
                _objProductCategoryEntity = _dbContext.POS_PRODUCT_CATEGORY.OrderByDescending(x => x.CATOEGORY_CODE).FirstOrDefault();
                if (_objProductCategoryEntity == null)
                {
                    code = "0001";
                }
                else
                {
                    maxCode = Formatter.SetValidValueToInt(_objProductCategoryEntity.CATOEGORY_CODE) + 1;
                    code = maxCode.ToString().PadLeft(4, '0');
                }

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int CreateProductCategory(POS_PRODUCT_CATEGORY ProductCategoryModel)
        {
            int rowAffected = 0;
            POS_PRODUCT_CATEGORY _objProductCategoryEntity = new POS_PRODUCT_CATEGORY();
            try
            {
                _objProductCategoryEntity.CATOEGORY_CODE = GetMaxCode();
                _objProductCategoryEntity.PRODUCT_CATEGORY = ProductCategoryModel.PRODUCT_CATEGORY;
                _objProductCategoryEntity.ISACTIVE_FLAG = ProductCategoryModel.ISACTIVE_FLAG;
                _objProductCategoryEntity.ISPOSTED_FLAG = false;
                _objProductCategoryEntity.CREATEDBY = ProductCategoryModel.CREATEDBY;
                _objProductCategoryEntity.CREATEDWHEN = ProductCategoryModel.CREATEDWHEN;

                _dbContext.POS_PRODUCT_CATEGORY.Add(_objProductCategoryEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateProductCategory(POS_PRODUCT_CATEGORY ProductCategoryModel)
        {
            int rowAffected = 0;
            POS_PRODUCT_CATEGORY entity = new POS_PRODUCT_CATEGORY();
            try
            {
                entity = _dbContext.POS_PRODUCT_CATEGORY.Find(ProductCategoryModel.CATEGORY_ID);

                entity.CATOEGORY_CODE = GetMaxCode();
                entity.PRODUCT_CATEGORY = ProductCategoryModel.PRODUCT_CATEGORY;
                entity.ISACTIVE_FLAG = ProductCategoryModel.ISACTIVE_FLAG;
                entity.ISPOSTED_FLAG = false;
                entity.MODIFIEDBY = ProductCategoryModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = ProductCategoryModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int DeleteProductCategory(long id)
        {
            int rowAffected = 0;
            try
            {
                _objProductCategoryEntity = _dbContext.POS_PRODUCT_CATEGORY.Find(id);
                _dbContext.POS_PRODUCT_CATEGORY.Remove(_objProductCategoryEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public IEnumerable<POS_PRODUCT_CATEGORY> ProductCategorySelectList()
        {
            IEnumerable<POS_PRODUCT_CATEGORY> lst = null;
            try
            {
                lst = _dbContext.POS_PRODUCT_CATEGORY.Select(x => new POS_PRODUCT_CATEGORY()
                {
                    CATEGORY_ID = x.CATEGORY_ID,
                    PRODUCT_CATEGORY = x.PRODUCT_CATEGORY
                }).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
