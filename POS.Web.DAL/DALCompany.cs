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
