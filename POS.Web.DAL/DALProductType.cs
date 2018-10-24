using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALProductType
    {
        Entities _dbContext = new Entities();
        POS_PRODUCT_TYPE _objProductTypeEntity = new POS_PRODUCT_TYPE();
        public List<POS_PRODUCT_TYPE> GetProductType()
        {
            List<POS_PRODUCT_TYPE> lst = new List<POS_PRODUCT_TYPE>();
            try
            {
                lst = _dbContext.POS_PRODUCT_TYPE.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_PRODUCT_TYPE GetById(long? id)
        {
            try
            {
                _objProductTypeEntity = _dbContext.POS_PRODUCT_TYPE.Find(id);
                return _objProductTypeEntity;
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
                _objProductTypeEntity = _dbContext.POS_PRODUCT_TYPE.OrderByDescending(x => x.TYPE_ID).FirstOrDefault();
                if (_objProductTypeEntity.TYPE_ID.ToString() == null)
                    id = 1;
                else
                    id = _objProductTypeEntity.TYPE_ID + 1;

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
                _objProductTypeEntity = _dbContext.POS_PRODUCT_TYPE.OrderByDescending(x => x.TYPE_CODE).FirstOrDefault();
                if (_objProductTypeEntity == null)
                {
                    code = "0001";
                }
                else
                {
                    maxCode = Formatter.SetValidValueToInt(_objProductTypeEntity.TYPE_CODE) + 1;
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
        public int CreateProductType(POS_PRODUCT_TYPE ProductTypeModel)
        {
            int rowAffected = 0;
            POS_PRODUCT_TYPE _objProductTypeEntity = new POS_PRODUCT_TYPE();
            try
            {
                _objProductTypeEntity.TYPE_CODE = GetMaxCode();
                _objProductTypeEntity.PRODUCT_TYPE = ProductTypeModel.PRODUCT_TYPE;
                _objProductTypeEntity.ISACTIVE_FLAG = ProductTypeModel.ISACTIVE_FLAG;
                _objProductTypeEntity.ISPOSTED_FLAG = false;
                _objProductTypeEntity.CREATEDBY = ProductTypeModel.CREATEDBY;
                _objProductTypeEntity.CREATEDWHEN = ProductTypeModel.CREATEDWHEN;

                _dbContext.POS_PRODUCT_TYPE.Add(_objProductTypeEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateProductType(POS_PRODUCT_TYPE ProductTypeModel)
        {
            int rowAffected = 0;
            POS_PRODUCT_TYPE entity = new POS_PRODUCT_TYPE();
            try
            {
                entity = _dbContext.POS_PRODUCT_TYPE.Find(ProductTypeModel.TYPE_ID);

                _objProductTypeEntity.PRODUCT_TYPE = ProductTypeModel.PRODUCT_TYPE;
                entity.ISACTIVE_FLAG = ProductTypeModel.ISACTIVE_FLAG;
                entity.ISPOSTED_FLAG = false;
                entity.MODIFIEDBY = ProductTypeModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = ProductTypeModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int DeleteProductType(long id)
        {
            int rowAffected = 0;
            try
            {
                _objProductTypeEntity = _dbContext.POS_PRODUCT_TYPE.Find(id);
                _dbContext.POS_PRODUCT_TYPE.Remove(_objProductTypeEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public IEnumerable<POS_PRODUCT_TYPE> ProductTypeSelectList()
        {
            IEnumerable<POS_PRODUCT_TYPE> lst = null;
            try
            {
                lst = _dbContext.POS_PRODUCT_TYPE.Select(x => new POS_PRODUCT_TYPE()
                {
                    TYPE_ID = x.TYPE_ID,
                    PRODUCT_TYPE = x.PRODUCT_TYPE
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
