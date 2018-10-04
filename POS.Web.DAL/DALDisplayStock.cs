using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALDisplayStock
    {
        Entities _dbContext = new Entities();
        POS_DISPLAY_STOCK _objDisplayStockEntity = new POS_DISPLAY_STOCK();
        public List<POS_DISPLAY_STOCK> GetDisplayStock()
        {
            List<POS_DISPLAY_STOCK> lst = new List<POS_DISPLAY_STOCK>();
            try
            {
                lst = _dbContext.POS_DISPLAY_STOCK.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_DISPLAY_STOCK GetById(long? id)
        {
            try
            {
                _objDisplayStockEntity = _dbContext.POS_DISPLAY_STOCK.Find(id);
                return _objDisplayStockEntity;
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
                _objDisplayStockEntity = _dbContext.POS_DISPLAY_STOCK.OrderByDescending(x => x.DSTOCK_ID).FirstOrDefault();
                if (_objDisplayStockEntity.DSTOCK_ID.ToString() == null)
                    id = 1;
                else
                    id = _objDisplayStockEntity.DSTOCK_ID + 1;

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
                _objDisplayStockEntity = _dbContext.POS_DISPLAY_STOCK.OrderByDescending(x => x.DSTOCK_ID).FirstOrDefault();
                if (_objDisplayStockEntity == null)
                {
                    code = "0001";
                }
                else
                {
                    maxCode = Formatter.SetValidValueToInt(_objDisplayStockEntity.DSTOCK_ID) + 1;
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
        public int CreateDisplayStock(POS_DISPLAY_STOCK DisplayStockModel)
        {
            int rowAffected = 0;
            POS_DISPLAY_STOCK _objDisplayStockEntity = new POS_DISPLAY_STOCK();
            try
            {
                _objDisplayStockEntity.DSTOCK_CODE = GetMaxCode();
                _objDisplayStockEntity.BRANCH_ID = DisplayStockModel.BRANCH_ID;
                _objDisplayStockEntity.SALE_CODE = DisplayStockModel.SALE_CODE;
                _objDisplayStockEntity.DATE = DisplayStockModel.DATE;
                _objDisplayStockEntity.PRODUCT_ID = DisplayStockModel.PRODUCT_ID;
                _objDisplayStockEntity.QUANTITY_IN = DisplayStockModel.QUANTITY_IN;
                _objDisplayStockEntity.QUANTITY_OUT = DisplayStockModel.QUANTITY_OUT;
                _objDisplayStockEntity.STOCK_TYPE = DisplayStockModel.STOCK_TYPE;
                _objDisplayStockEntity.UNIT_PRICE = DisplayStockModel.UNIT_PRICE;
                _objDisplayStockEntity.TOTAL_PRICE = DisplayStockModel.TOTAL_PRICE;
                _objDisplayStockEntity.WV_SHIPPMENT_CODE = DisplayStockModel.WV_SHIPPMENT_CODE;
                _objDisplayStockEntity.SHIPPMENT_FROM = DisplayStockModel.SHIPPMENT_FROM;
                _objDisplayStockEntity.WSTOCK_CODE = DisplayStockModel.WSTOCK_CODE;
                _objDisplayStockEntity.ISMANUAL_ENTRY = DisplayStockModel.ISMANUAL_ENTRY;
                _objDisplayStockEntity.ISPOSTED_FLAG = false;
                _objDisplayStockEntity.CREATEDBY = DisplayStockModel.CREATEDBY;
                _objDisplayStockEntity.CREATEDWHEN = DisplayStockModel.CREATEDWHEN;

                _dbContext.POS_DISPLAY_STOCK.Add(_objDisplayStockEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateDisplayStock(POS_DISPLAY_STOCK DisplayStockModel)
        {
            int rowAffected = 0;
            POS_DISPLAY_STOCK entity = new POS_DISPLAY_STOCK();
            try
            {
                entity = _dbContext.POS_DISPLAY_STOCK.Find(DisplayStockModel.DSTOCK_ID);

                _objDisplayStockEntity.BRANCH_ID = DisplayStockModel.BRANCH_ID;
                _objDisplayStockEntity.SALE_CODE = DisplayStockModel.SALE_CODE;
                _objDisplayStockEntity.DATE = DisplayStockModel.DATE;
                _objDisplayStockEntity.PRODUCT_ID = DisplayStockModel.PRODUCT_ID;
                _objDisplayStockEntity.QUANTITY_IN = DisplayStockModel.QUANTITY_IN;
                _objDisplayStockEntity.QUANTITY_OUT = DisplayStockModel.QUANTITY_OUT;
                _objDisplayStockEntity.STOCK_TYPE = DisplayStockModel.STOCK_TYPE;
                _objDisplayStockEntity.UNIT_PRICE = DisplayStockModel.UNIT_PRICE;
                _objDisplayStockEntity.TOTAL_PRICE = DisplayStockModel.TOTAL_PRICE;
                _objDisplayStockEntity.WV_SHIPPMENT_CODE = DisplayStockModel.WV_SHIPPMENT_CODE;
                _objDisplayStockEntity.SHIPPMENT_FROM = DisplayStockModel.SHIPPMENT_FROM;
                _objDisplayStockEntity.WSTOCK_CODE = DisplayStockModel.WSTOCK_CODE;
                _objDisplayStockEntity.ISMANUAL_ENTRY = DisplayStockModel.ISMANUAL_ENTRY;
                entity.ISPOSTED_FLAG = false;
                entity.MODIFIEDBY = DisplayStockModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = DisplayStockModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int DeleteDisplayStock(long id)
        {
            int rowAffected = 0;
            try
            {
                _objDisplayStockEntity = _dbContext.POS_DISPLAY_STOCK.Find(id);
                _dbContext.POS_DISPLAY_STOCK.Remove(_objDisplayStockEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
    }
}
