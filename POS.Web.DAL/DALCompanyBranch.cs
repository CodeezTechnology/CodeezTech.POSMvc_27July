using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALCompanyBranch
    {
        Entities _dbContext = new Entities();
        POS_BRANCH _objBranchEntity = new POS_BRANCH();

        public List<POS_BRANCH> List()
        {
            List<POS_BRANCH> lst = new List<POS_BRANCH>();
            try
            {
                //lst = _dbContext.POS_BRANCH.ToList();
                //var result = (from ctx in _dbContext.POS_BRANCH
                //              join company in _dbContext.POS_COMPANY on ctx.COMPANY_ID equals company.COMPANY_ID
                //              join city in _dbContext.POS_CITY on ctx.CITY_ID equals city.CITY_ID
                //              join state in _dbContext.POS_STATE on ctx.STATE_ID equals state.STATE_ID
                //              join country in _dbContext.POS_COUNTRY on ctx.COUNTRY_ID equals country.COUNTRY_ID
                //              select new
                //              {
                //                  BranchId = ctx.BRANCH_ID,
                //                  BranchCode = ctx.BRANCH_CODE,
                //                  BranchDesc = ctx.BRANCH_DESC,
                //                  Name = ctx.NAME,
                //                  Mobile = ctx.MOBILE,
                //                  Telephone = ctx.TELEPHONE,
                //                  Email = ctx.EMAIL,
                //                  EmailPassword = ctx.EMAIL_PASSWORD,
                //                  Address = ctx.ADDRESS,
                //                  CompanyId = company.COMPANY_ID,
                //                  CompanyName = company.COMPANY_DESC,
                //                  CityId = city.CITY_ID,
                //                  CityName = city.CITY_DESC,
                //                  StateId = state.STATE_ID,
                //                  CountryName = country.COUNTRY_DESC,
                //                  CountryId = country.COUNTRY_ID,
                //                  CreatedBy = ctx.CREATEDBY,
                //                  ModifiedBy = ctx.MODIFIEDBY,
                //                  CreatedWhen = ctx.CREATEDWHEN,
                //                  ModifiedWhen = ctx.MODIFIEDWHEN
                //              }).Select((x, index) => new POS_BRANCH()
                //              {
                //                  BRANCH_ID = x.BranchId,
                //                  BRANCH_CODE = x.BranchCode,
                //                  BRANCH_DESC = x.BranchDesc,
                //                  NAME = x.Name,
                //                  MOBILE = x.Mobile,
                //                  TELEPHONE = x.Telephone,
                //                  EMAIL = x.Email,
                //                  EMAIL_PASSWORD = x.EmailPassword,
                //                  ADDRESS = x.Address,
                //                  COMPANY_ID = x.CompanyId,
                //                  CompanyName = x.CompanyName,
                //                  CITY_ID = x.CityId,
                //                  CityName = x.CityName,
                //                  STATE_ID = x.StateId,
                //                  CountryName = x.CountryName,
                //                  COUNTRY_ID = x.CountryId,
                //                  CREATEDBY = x.CreatedBy,
                //                  MODIFIEDBY = x.ModifiedBy,
                //                  CREATEDWHEN = x.CreatedWhen,
                //                  MODIFIEDWHEN = x.ModifiedWhen
                //              }).ToList();
                var result = (from ctx in _dbContext.POS_BRANCH
                              join company in _dbContext.POS_COMPANY on ctx.COMPANY_ID equals company.COMPANY_ID
                              join city in _dbContext.POS_CITY on ctx.CITY_ID equals city.CITY_ID
                              join state in _dbContext.POS_STATE on ctx.STATE_ID equals state.STATE_ID
                              join country in _dbContext.POS_COUNTRY on ctx.COUNTRY_ID equals country.COUNTRY_ID
                              select new
                              {
                                  BranchId = ctx.BRANCH_ID,
                                  BranchCode = ctx.BRANCH_CODE,
                                  BranchDesc = ctx.BRANCH_DESC,
                                  Name = ctx.NAME,
                                  Mobile = ctx.MOBILE,
                                  Telephone = ctx.TELEPHONE,
                                  Email = ctx.EMAIL,
                                  EmailPassword = ctx.EMAIL_PASSWORD,
                                  Address = ctx.ADDRESS,
                                  CompanyId = company.COMPANY_ID,
                                  CompanyName = company.COMPANY_DESC,
                                  CityId = city.CITY_ID,
                                  CityName = city.CITY_DESC,
                                  StateId = state.STATE_ID,
                                  CountryName = country.COUNTRY_DESC,
                                  CountryId = country.COUNTRY_ID,
                                  CreatedBy = ctx.CREATEDBY,
                                  ModifiedBy = ctx.MODIFIEDBY,
                                  CreatedWhen = ctx.CREATEDWHEN,
                                  ModifiedWhen = ctx.MODIFIEDWHEN
                              }).ToList();

                foreach (var item in result)
                {
                    POS_BRANCH entity = new POS_BRANCH();
                    
                                  entity.BRANCH_ID = item.BranchId;
                                  entity.BRANCH_CODE = item.BranchCode;
                                  entity.BRANCH_DESC = item.BranchDesc;
                                  entity.NAME = item.Name;
                                  entity.MOBILE = item.Mobile;
                                  entity.TELEPHONE = item.Telephone;
                                  entity.EMAIL = item.Email;
                                  entity.EMAIL_PASSWORD = item.EmailPassword;
                                  entity.ADDRESS = item.Address;
                                  entity.COMPANY_ID = item.CompanyId;
                                  entity.CompanyName = item.CompanyName;
                                  entity.CITY_ID = item.CityId;
                                  entity.CityName = item.CityName;
                                  entity.STATE_ID = item.StateId;
                                  entity.CountryName = item.CountryName;
                                  entity.COUNTRY_ID = item.CountryId;
                                  entity.CREATEDBY = item.CreatedBy;
                                  entity.MODIFIEDBY = item.ModifiedBy;
                                  entity.CREATEDWHEN = item.CreatedWhen;
                                  entity.MODIFIEDWHEN = item.ModifiedWhen;
                                  lst.Add(entity);
                }
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_BRANCH GetById(long? id)
        {
            POS_BRANCH lst = new POS_BRANCH();
            try
            {
                var result = (from ctx in _dbContext.POS_BRANCH
                              join company in _dbContext.POS_COMPANY on ctx.COMPANY_ID equals company.COMPANY_ID
                              join city in _dbContext.POS_CITY on ctx.CITY_ID equals city.CITY_ID
                              join state in _dbContext.POS_STATE on ctx.STATE_ID equals state.STATE_ID
                              join country in _dbContext.POS_COUNTRY on ctx.COUNTRY_ID equals country.COUNTRY_ID
                              where ctx.BRANCH_ID == id
                              select new
                              {
                                  BranchId = ctx.BRANCH_ID,
                                  BranchCode = ctx.BRANCH_CODE,
                                  BranchDesc = ctx.BRANCH_DESC,
                                  Name = ctx.NAME,
                                  Mobile = ctx.MOBILE,
                                  Telephone = ctx.TELEPHONE,
                                  Email = ctx.EMAIL,
                                  EmailPassword = ctx.EMAIL_PASSWORD,
                                  Address = ctx.ADDRESS,
                                  CompanyId = company.COMPANY_ID,
                                  CompanyName = company.COMPANY_DESC,
                                  CityId = city.CITY_ID,
                                  CityName = city.CITY_DESC,
                                  StateId = state.STATE_ID,
                                  CountryName = country.COUNTRY_DESC,
                                  CountryId = country.COUNTRY_ID,
                                  CreatedBy = ctx.CREATEDBY,
                                  ModifiedBy = ctx.MODIFIEDBY,
                                  CreatedWhen = ctx.CREATEDWHEN,
                                  ModifiedWhen = ctx.MODIFIEDWHEN
                              }).Select((x, index) => new POS_BRANCH()
                              {
                                  BRANCH_ID = x.BranchId,
                                  BRANCH_CODE = x.BranchCode,
                                  BRANCH_DESC = x.BranchDesc,
                                  NAME = x.Name,
                                  MOBILE = x.Mobile,
                                  TELEPHONE = x.Telephone,
                                  EMAIL = x.Email,
                                  EMAIL_PASSWORD = x.EmailPassword,
                                  ADDRESS = x.Address,
                                  COMPANY_ID = x.CompanyId,
                                  CompanyName = x.CompanyName,
                                  CITY_ID = x.CityId,
                                  CityName = x.CityName,
                                  STATE_ID = x.StateId,
                                  CountryName = x.CountryName,
                                  COUNTRY_ID = x.CountryId,
                                  CREATEDBY = x.CreatedBy,
                                  MODIFIEDBY = x.ModifiedBy,
                                  CREATEDWHEN = x.CreatedWhen,
                                  MODIFIEDWHEN = x.ModifiedWhen
                              }).FirstOrDefault();
                return lst;
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
                _objBranchEntity = _dbContext.POS_BRANCH.OrderByDescending(x => x.BRANCH_ID).FirstOrDefault();
                if (_objBranchEntity.BRANCH_ID.ToString() == null)
                    id = 1;
                else
                    id = _objBranchEntity.BRANCH_ID + 1;

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
                _objBranchEntity = _dbContext.POS_BRANCH.OrderByDescending(x => x.BRANCH_CODE).FirstOrDefault();
                if (_objBranchEntity.BRANCH_CODE.ToString() == null)
                    code = "0001";
                else
                    maxCode = Formatter.SetValidValueToInt(_objBranchEntity.BRANCH_CODE) + 1;
                code = maxCode.ToString().PadLeft(4, '0');

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int Create(POS_BRANCH BranchModel)
        {
            POS_BRANCH entity = new POS_BRANCH();
            int rowAffected = 0;
            try
            {
                entity.BRANCH_ID = GetMaxId();
                entity.BRANCH_CODE = GetMaxCode();
                entity.BRANCH_DESC = BranchModel.BRANCH_DESC;
                entity.NAME = BranchModel.NAME;
                entity.MOBILE = BranchModel.MOBILE;
                entity.TELEPHONE = BranchModel.TELEPHONE;
                entity.EMAIL = BranchModel.EMAIL;
                entity.EMAIL_PASSWORD = BranchModel.EMAIL_PASSWORD;
                entity.ADDRESS = BranchModel.ADDRESS;
                entity.COMPANY_ID = BranchModel.COMPANY_ID;
                entity.CompanyName = BranchModel.CompanyName;
                entity.CITY_ID = BranchModel.CITY_ID;
                entity.CityName = BranchModel.CityName;
                entity.STATE_ID = BranchModel.STATE_ID;
                entity.CountryName = BranchModel.CountryName;
                entity.COUNTRY_ID = BranchModel.COUNTRY_ID;
                entity.CREATEDBY = BranchModel.CREATEDBY;
                entity.CREATEDWHEN = BranchModel.CREATEDWHEN;


                _dbContext.POS_BRANCH.Add(entity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int Update(POS_BRANCH BranchModel)
        {
            int rowAffected = 0;
            POS_BRANCH entity = new POS_BRANCH();
            try
            {
                entity = _dbContext.POS_BRANCH.Find(BranchModel.BRANCH_ID);

                entity.BRANCH_DESC = BranchModel.BRANCH_DESC;
                entity.NAME = BranchModel.NAME;
                entity.MOBILE = BranchModel.MOBILE;
                entity.TELEPHONE = BranchModel.TELEPHONE;
                entity.EMAIL = BranchModel.EMAIL;
                entity.EMAIL_PASSWORD = BranchModel.EMAIL_PASSWORD;
                entity.ADDRESS = BranchModel.ADDRESS;
                entity.COMPANY_ID = BranchModel.COMPANY_ID;
                entity.CompanyName = BranchModel.CompanyName;
                entity.CITY_ID = BranchModel.CITY_ID;
                entity.CityName = BranchModel.CityName;
                entity.STATE_ID = BranchModel.STATE_ID;
                entity.CountryName = BranchModel.CountryName;
                entity.COUNTRY_ID = BranchModel.COUNTRY_ID;
                entity.MODIFIEDBY = BranchModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = BranchModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int Delete(long id)
        {
            int rowAffected = 0;
            try
            {
                _objBranchEntity = _dbContext.POS_BRANCH.Find(id);
                _dbContext.POS_BRANCH.Remove(_objBranchEntity);
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
