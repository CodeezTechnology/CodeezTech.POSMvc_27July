using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeezTech.POS.Web.DAL
{
    public class DALProduct
    {
        Entities _dbContext = new Entities();
        POS_PRODUCT _objProductEntity = new POS_PRODUCT();
        public List<POS_PRODUCT> GetProduct()
        {
            List<POS_PRODUCT> lst = new List<POS_PRODUCT>();
            try
            {
                // lst = _dbContext.POS_PRODUCT.Include("POS_PRODUCT_CATEGORY").Include("POS_PRODUCT_TYPE").Include("POS_UNITS").ToList();
                var result = (from ctx in _dbContext.POS_PRODUCT
                              join c in _dbContext.POS_PRODUCT_CATEGORY on ctx.CATEGORY_ID equals c.CATEGORY_ID
                              join t in _dbContext.POS_PRODUCT_TYPE on ctx.TYPE_ID equals t.TYPE_ID
                              join u in _dbContext.POS_UNITS on ctx.UNIT_ID equals u.UNIT_ID
                              select new
                              {
                                  ProductId = ctx.PRODUCT_ID,
                                  ProductCode = ctx.PRODUCT_CODE,
                                  ProductName = ctx.PRODUCT_DESC,
                                  MarginRate = ctx.PROFIT_MARGIN_RATE,
                                  PayblePrice = ctx.PAYBLE_PRICE,
                                  TaxApplied = ctx.IS_TAX_APPLIED_FLAG,
                                  TaxPer = ctx.TAX_PER,
                                  TaxRs = ctx.TAX_RS,
                                  TypeId = ctx.TYPE_ID,
                                  CategoryId = ctx.CATEGORY_ID,
                                  UnitId = ctx.UNIT_ID,
                                  ExpiryFrom = ctx.EXPIRY_FROM,
                                  ExpiryTo = ctx.EXPIRY_TO,
                                  ProductCategory = c.PRODUCT_CATEGORY,
                                  ProductType = t.PRODUCT_TYPE,
                                  Units = u.UNIT,
                                  IsActive = ctx.ISACTIVE_FLAG,
                                  CreatedBy = ctx.CREATEDBY,
                                  ModifiedBy = ctx.MODIFIEDBY,
                                  CreatedWhen = ctx.CREATEDWHEN,
                                  ModifiedWhen = ctx.MODIFIEDWHEN
                              }).AsEnumerable().Select((x, index) => new POS_PRODUCT
                              {
                                 PRODUCT_ID = x.ProductId,
                               PRODUCT_CODE = x.ProductCode,
                                  PRODUCT_DESC = x.ProductName,
                                  PROFIT_MARGIN_RATE = x.MarginRate,
                                  PAYBLE_PRICE = x.PayblePrice,
                                  IS_TAX_APPLIED_FLAG = x.TaxApplied,
                                  TAX_PER = x.TaxPer,
                                  TAX_RS = x.TaxRs,
                                  TypeId = x.TypeId,
                                  CategoryId = x.CategoryId,
                                  UnitId = x.UnitId,
                                  EXPIRY_FROM = x.ExpiryFrom,
                                  EXPIRY_TO = x.ExpiryTo,
                                  CategoryDesc = x.ProductCategory,
                                  TypeDesc = x.ProductType,
                                  UnitDesc = x.Units,
                                  ISACTIVE_FLAG = x.IsActive,
                                  CREATEDBY = x.CreatedBy,
                                  MODIFIEDBY = x.ModifiedBy,
                                  CREATEDWHEN = x.CreatedWhen,
                                  MODIFIEDWHEN = x.ModifiedWhen
                              }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_PRODUCT GetById(long? id)
        {
            try
            {
                var result = (from ctx in _dbContext.POS_PRODUCT
                              join c in _dbContext.POS_PRODUCT_CATEGORY on ctx.CATEGORY_ID equals c.CATEGORY_ID
                              join t in _dbContext.POS_PRODUCT_TYPE on ctx.TYPE_ID equals t.TYPE_ID
                              join u in _dbContext.POS_UNITS on ctx.UNIT_ID equals u.UNIT_ID
                              where ctx.PRODUCT_ID == id
                              select new
                              {
                                  ProductId = ctx.PRODUCT_ID,
                                  ProductCode = ctx.PRODUCT_CODE,
                                  ProductName = ctx.PRODUCT_DESC,
                                  MarginRate = ctx.PROFIT_MARGIN_RATE,
                                  PayblePrice = ctx.PAYBLE_PRICE,
                                  TaxApplied = ctx.IS_TAX_APPLIED_FLAG,
                                  TaxPer = ctx.TAX_PER,
                                  TaxRs = ctx.TAX_RS,
                                  TypeId = ctx.TYPE_ID,
                                  CategoryId = ctx.CATEGORY_ID,
                                  UnitId = ctx.UNIT_ID,
                                  ExpiryFrom = ctx.EXPIRY_FROM,
                                  ExpiryTo = ctx.EXPIRY_TO,
                                  ProductCategory = c.PRODUCT_CATEGORY,
                                  ProductType = t.PRODUCT_TYPE,
                                  Units = u.UNIT,
                                  IsActive = ctx.ISACTIVE_FLAG,
                                  CreatedBy = ctx.CREATEDBY,
                                  ModifiedBy = ctx.MODIFIEDBY,
                                  CreatedWhen = ctx.CREATEDWHEN,
                                  ModifiedWhen = ctx.MODIFIEDWHEN
                              }).AsEnumerable().Select((x, index) => new POS_PRODUCT
                              {
                                  PRODUCT_ID = x.ProductId,
                                  PRODUCT_CODE = x.ProductCode,
                                  PRODUCT_DESC = x.ProductName,
                                  PROFIT_MARGIN_RATE = x.MarginRate,
                                  PAYBLE_PRICE = x.PayblePrice,
                                  IS_TAX_APPLIED_FLAG = x.TaxApplied,
                                  TAX_PER = x.TaxPer,
                                  TAX_RS = x.TaxRs,
                                  TypeId = x.TypeId,
                                  CategoryId = x.CategoryId,
                                  UnitId = x.UnitId,
                                  EXPIRY_FROM = x.ExpiryFrom,
                                  EXPIRY_TO = x.ExpiryTo,
                                  CategoryDesc = x.ProductCategory,
                                  TypeDesc = x.ProductType,
                                  UnitDesc = x.Units,
                                  ISACTIVE_FLAG = x.IsActive,
                                  CREATEDBY = x.CreatedBy,
                                  MODIFIEDBY = x.ModifiedBy,
                                  CREATEDWHEN = x.CreatedWhen,
                                  MODIFIEDWHEN = x.ModifiedWhen
                              }).FirstOrDefault();
                return result;
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
                _objProductEntity = _dbContext.POS_PRODUCT.OrderByDescending(x => x.TYPE_ID).FirstOrDefault();
                if (_objProductEntity.TYPE_ID.ToString() == null)
                    id = 1;
                else
                    id = _objProductEntity.TYPE_ID + 1;

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
                _objProductEntity = _dbContext.POS_PRODUCT.OrderByDescending(x => x.PRODUCT_CODE).FirstOrDefault();
                if (_objProductEntity == null)
                {
                    code = "0001";
                }
                else
                {
                    maxCode = Formatter.SetValidValueToInt(_objProductEntity.PRODUCT_CODE) + 1;
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
        public int CreateProduct(POS_PRODUCT ProductModel)
        {
            int rowAffected = 0;
            POS_PRODUCT _objProductEntity = new POS_PRODUCT();
            try
            {
                _objProductEntity.PRODUCT_CODE = GetMaxCode();
                _objProductEntity.PRODUCT_DESC = ProductModel.PRODUCT_DESC;
                _objProductEntity.PROFIT_MARGIN_RATE = ProductModel.PROFIT_MARGIN_RATE;
                _objProductEntity.PAYBLE_PRICE = ProductModel.PAYBLE_PRICE;
                _objProductEntity.IS_TAX_APPLIED_FLAG = ProductModel.IS_TAX_APPLIED_FLAG;
                _objProductEntity.TAX_PER = ProductModel.TAX_PER;
                _objProductEntity.TAX_RS = ProductModel.TAX_RS;
                _objProductEntity.TYPE_ID = ProductModel.TypeId;
                _objProductEntity.CATEGORY_ID = ProductModel.CategoryId;
                _objProductEntity.UNIT_ID = ProductModel.UnitId;
                _objProductEntity.EXPIRY_FROM = ProductModel.EXPIRY_FROM;
                _objProductEntity.EXPIRY_TO = ProductModel.EXPIRY_TO;
                _objProductEntity.ISACTIVE_FLAG = ProductModel.ISACTIVE_FLAG;
                _objProductEntity.ISPOSTED_FLAG = false;
                _objProductEntity.CREATEDBY = ProductModel.CREATEDBY;
                _objProductEntity.CREATEDWHEN = ProductModel.CREATEDWHEN;

                _dbContext.POS_PRODUCT.Add(_objProductEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateProduct(POS_PRODUCT ProductModel)
        {
            int rowAffected = 0;
            POS_PRODUCT entity = new POS_PRODUCT();
            try
            {
                entity = _dbContext.POS_PRODUCT.Find(ProductModel.PRODUCT_ID);

                entity.PRODUCT_DESC = ProductModel.PRODUCT_DESC;
                entity.PROFIT_MARGIN_RATE = ProductModel.PROFIT_MARGIN_RATE;
                entity.PAYBLE_PRICE = ProductModel.PAYBLE_PRICE;
                entity.IS_TAX_APPLIED_FLAG = ProductModel.IS_TAX_APPLIED_FLAG;
                entity.TAX_PER = ProductModel.TAX_PER;
                entity.TAX_RS = ProductModel.TAX_RS;
                entity.TYPE_ID = ProductModel.TypeId;
                entity.CATEGORY_ID = ProductModel.CategoryId;
                entity.UNIT_ID = ProductModel.UnitId;
                entity.EXPIRY_FROM = ProductModel.EXPIRY_FROM;
                entity.EXPIRY_TO = ProductModel.EXPIRY_TO;
                entity.ISACTIVE_FLAG = ProductModel.ISACTIVE_FLAG;
                entity.ISPOSTED_FLAG = false;
                entity.MODIFIEDBY = ProductModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = ProductModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int DeleteProduct(long id)
        {
            int rowAffected = 0;
            try
            {
                _objProductEntity = _dbContext.POS_PRODUCT.Find(id);
                _dbContext.POS_PRODUCT.Remove(_objProductEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public IEnumerable<POS_PRODUCT> ProductSelectList()
        {
            IEnumerable<POS_PRODUCT> lst = null;
            try
            {
                lst = _dbContext.POS_PRODUCT.Select(x => new POS_PRODUCT()
                {
                    TYPE_ID = x.TYPE_ID,
                    PRODUCT_DESC = x.PRODUCT_DESC
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
