using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALCompany
    {
        Entities _dbContext = new Entities();
        POS_COMPANY _objCompanyEntity = new POS_COMPANY();
    
        public List<POS_COMPANY> List()
        {
            try
            {
                var result = (from ctx in _dbContext.POS_COMPANY
                              select ctx).ToList();
                return result;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException("Company Info not completed in Data Layer");
            }
        }
        public POS_COMPANY GetById(long? id)
        {
            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Find(id);
                return _objCompanyEntity;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public long GetMaxId()
        {
            long id = 0;
            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.OrderByDescending(x => x.COMPANY_ID).FirstOrDefault();
                if (_objCompanyEntity.COMPANY_ID.ToString() == null)
                    id = 1;
                else
                    id = _objCompanyEntity.COMPANY_ID + 1;

                return id;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public string GetMaxCode()
        {
            string code = string.Empty;
            int maxCode = 0;
            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.OrderByDescending(x => x.COMPANY_CODE).FirstOrDefault();
                if (_objCompanyEntity.COMPANY_CODE.ToString() == null)
                    code = "0001";
                else
                    maxCode = Formatter.SetValidValueToInt(_objCompanyEntity.COMPANY_CODE) + 1;
                code = maxCode.ToString().PadLeft(4, '0');

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }

        public bool IsMultipleBranch()
        {
            bool flag = false;
           
            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsMultipleBranch == true).FirstOrDefault();
                if (_objCompanyEntity.IsMultipleBranch == false)
                    flag = false;
                else
                    flag = true;
                
                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsWarehouse()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsWarehouse == true).FirstOrDefault();
                if (_objCompanyEntity.IsWarehouse == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public POS_BRANCH CompBranchInfo(int BranchID)
        {
            try
            {
                var result = (from ctx in _dbContext.POS_BRANCH
                              where ctx.BRANCH_ID == BranchID 
                              select ctx).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool IsWarehouseStock()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsWarehouseStock == true).FirstOrDefault();
                if (_objCompanyEntity.IsWarehouseStock == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsWarehouseTracking()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsWarehouseTracking == true).FirstOrDefault();
                if (_objCompanyEntity.IsWarehouseTracking == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsWarehouseShipment()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsWarehouseShipment == true).FirstOrDefault();
                if (_objCompanyEntity.IsWarehouseShipment == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsVendor()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsVendor == true).FirstOrDefault();
                if (_objCompanyEntity.IsVendor == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsVendorShipment()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsVendorShipment == true).FirstOrDefault();
                if (_objCompanyEntity.IsVendorShipment == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsDisplayTracking()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsDisplayTracking == true).FirstOrDefault();
                if (_objCompanyEntity.IsDisplayTracking == false)
                    flag = false;
                else
                    flag = true;
                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsRFQ()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsRFQ == true).FirstOrDefault();
                if (_objCompanyEntity.IsRFQ == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsAccounting()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsAccounting == true).FirstOrDefault();
                if (_objCompanyEntity.IsAccounting == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsCashierCounter()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsCashierCounter == true).FirstOrDefault();
                if (_objCompanyEntity.IsCashierCounter == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsPromotion()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsPromotion == true).FirstOrDefault();
                if (_objCompanyEntity.IsPromotion == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public bool IsPaymentSystem()
        {
            bool flag = false;

            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Where(m => m.IsPaymentSystem == true).FirstOrDefault();
                if (_objCompanyEntity.IsPaymentSystem == false)
                    flag = false;
                else
                    flag = true;

                return flag;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public int Create(POS_COMPANY CompanyModel)
        {
            int rowAffected = 0;
            try
            {
                _objCompanyEntity.COMPANY_ID = GetMaxId();
                _objCompanyEntity.COMPANY_CODE = GetMaxCode();
                _objCompanyEntity.COMPANY_DESC = CompanyModel.COMPANY_DESC;
                _objCompanyEntity.LOGO = CompanyModel.LOGO;
                _objCompanyEntity.HTTP_HOST_ADDRESS = CompanyModel.HTTP_HOST_ADDRESS;
                _objCompanyEntity.NTN_NO = CompanyModel.NTN_NO;
                _objCompanyEntity.REGISTEREDBY = CompanyModel.REGISTEREDBY;
                _objCompanyEntity.ISPOSTED_FLAG = false;
                _objCompanyEntity.ISACTIVE_FLAG = CompanyModel.ISACTIVE_FLAG;
                _objCompanyEntity.CREATEDBY = CompanyModel.CREATEDBY;
                _objCompanyEntity.CREATEDWHEN = CompanyModel.CREATEDWHEN;

                _dbContext.POS_COMPANY.Add(CompanyModel);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int Update(POS_COMPANY CompanyModel)
        {
            int rowAffected = 0;
            POS_COMPANY entity = new POS_COMPANY();
            try
            {
                entity = _dbContext.POS_COMPANY.Find(CompanyModel.COMPANY_ID);

                _objCompanyEntity.COMPANY_DESC = CompanyModel.COMPANY_DESC;
                _objCompanyEntity.LOGO = CompanyModel.LOGO;
                _objCompanyEntity.HTTP_HOST_ADDRESS = CompanyModel.HTTP_HOST_ADDRESS;
                _objCompanyEntity.NTN_NO = CompanyModel.NTN_NO;
                _objCompanyEntity.REGISTEREDBY = CompanyModel.REGISTEREDBY;
                _objCompanyEntity.ISPOSTED_FLAG = false;
                _objCompanyEntity.ISACTIVE_FLAG = CompanyModel.ISACTIVE_FLAG;
                entity.MODIFIEDBY = CompanyModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = CompanyModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public int Delete(long id)
        {
            int rowAffected = 0;
            try
            {
                _objCompanyEntity = _dbContext.POS_COMPANY.Find(id);
                _dbContext.POS_COMPANY.Remove(_objCompanyEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
    }
}
