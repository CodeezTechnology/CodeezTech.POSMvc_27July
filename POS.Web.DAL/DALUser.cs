using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALUser
    {
        Entities _dbContext = new Entities();
        POS_USER _objUserEntity = new POS_USER();
        public POS_USER Login(POS_USER viewModel)
        {
            try
            {
                var result = (from ctx in _dbContext.POS_USER
                              where ctx.USERNAME == viewModel.USERNAME && ctx.PASSWORD == viewModel.PASSWORD ||
                                     ctx.MASTER_PASSWORD == viewModel.PASSWORD && ctx.ISACTIVE_FLAG == true
                              select ctx).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        public List<POS_USER> List()
        {
            List<POS_USER> lst = new List<POS_USER>();
            try
            {
                //lst = _dbContext.POS_USER.ToList();
                var result = (from ctx in _dbContext.POS_USER
                              join j in _dbContext.POS_BRANCH on ctx.BRANCH_ID equals j.BRANCH_ID
                              select new
                              {
                                  UserId = ctx.USER_ID,
                                  UserCode = ctx.CODE,
                                  Username = ctx.USERNAME,
                                  Password = ctx.PASSWORD,
                                  Email = ctx.EMAIL,
                                  IsActive = ctx.ISACTIVE_FLAG,
                                  LoginType = ctx.LOGIN_TYPE,
                                  MasterPassword = ctx.MASTER_PASSWORD,
                                  BranchId = ctx.BRANCH_ID,
                                  BranchName = j.BRANCH_DESC,
                                  CreatedBy = ctx.CREATEDBY,
                                  ModifiedBy = ctx.MODIFIEDBY,
                                  CreatedWhen = ctx.CREATEDWHEN,
                                  ModifiedWhen = ctx.MODIFIEDWHEN
                              }).ToList();
                foreach (var item in result)
                {
                    POS_USER _entity = new POS_USER();
                    _entity.USER_ID = item.UserId;
                    _entity.CODE = item.UserCode;
                    _entity.USERNAME = item.Username;
                    _entity.PASSWORD = item.Password;
                    _entity.EMAIL = item.Email;
                    _entity.ISACTIVE_FLAG = item.IsActive;
                    _entity.LOGIN_TYPE = item.LoginType;
                    _entity.MASTER_PASSWORD = item.MasterPassword;
                    _entity.BRANCH_ID = item.BranchId;
                    _entity.BranchName = item.BranchName;
                    _entity.CREATEDBY = item.CreatedBy;
                    _entity.CREATEDWHEN = item.CreatedWhen;
                    _entity.MODIFIEDWHEN = item.ModifiedWhen;
                    lst.Add(_entity);
                }
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException("User Info not completed in Data Layer");
            }
        }
        public POS_USER GetById(long? id)
        {
            try
            {
                _objUserEntity = _dbContext.POS_USER.Find(id);
                return _objUserEntity;
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
                _objUserEntity = _dbContext.POS_USER.OrderByDescending(x => x.USER_ID).FirstOrDefault();
                if (_objUserEntity.USER_ID.ToString() == null)
                    id = 1;
                else
                    id = _objUserEntity.USER_ID + 1;

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
                _objUserEntity = _dbContext.POS_USER.OrderByDescending(x => x.CODE).FirstOrDefault();
                if (_objUserEntity.CODE.ToString() == null)
                    code = "0001";
                else
                    maxCode = Formatter.SetValidValueToInt(_objUserEntity.CODE) + 1;
                    code = maxCode.ToString().PadLeft(4, '0');

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public int Create(POS_USER userModel)
        {
            int rowAffected = 0;
            POS_USER _objUserEntity = new POS_USER();
            try
            {
                _objUserEntity.USER_ID = GetMaxId();
                _objUserEntity.CODE = userModel.CODE;
                _objUserEntity.USERNAME = userModel.USERNAME;
                _objUserEntity.PASSWORD = userModel.PASSWORD;
                _objUserEntity.EMAIL = userModel.EMAIL;
                _objUserEntity.ISACTIVE_FLAG = userModel.ISACTIVE_FLAG;
                _objUserEntity.LOGIN_TYPE = userModel.LOGIN_TYPE;
                _objUserEntity.MASTER_PASSWORD = userModel.MASTER_PASSWORD;
                _objUserEntity.BRANCH_ID = userModel.BranchId;
                _objUserEntity.ISPOSTED_FLAG = false;
                _objUserEntity.CREATEDBY = userModel.CREATEDBY;
                _objUserEntity.CREATEDWHEN = userModel.CREATEDWHEN;
                _objUserEntity.MODIFIEDBY = userModel.MODIFIEDBY;
                _dbContext.POS_USER.Add(_objUserEntity);
               rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException("User Info not completed in Data Layer");
            }
        }
        public int Update(POS_USER userModel)
        {
            int rowAffected = 0;
            POS_USER entity = new POS_USER();
            try
            {
                //_dbContext.Entry(userModel).State = System.Data.Entity.EntityState.Modified;
                entity = _dbContext.POS_USER.Find(userModel.USER_ID);

              entity.USER_ID=  userModel.USER_ID;
              entity.CODE = userModel.CODE;
              entity.USERNAME = userModel.USERNAME;
              entity.PASSWORD = userModel.PASSWORD;
              entity.EMAIL = userModel.EMAIL;
              entity.ISACTIVE_FLAG = userModel.ISACTIVE_FLAG;
              entity.LOGIN_TYPE = userModel.LOGIN_TYPE;
              entity.MASTER_PASSWORD = userModel.MASTER_PASSWORD;
              entity.BRANCH_ID = userModel.BranchId;
              entity.ISPOSTED_FLAG = false;
              entity.MODIFIEDBY = userModel.MODIFIEDBY;
              entity.MODIFIEDWHEN = userModel.MODIFIEDWHEN;
          
               rowAffected= _dbContext.SaveChanges();

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
                _objUserEntity = _dbContext.POS_USER.Find(id);
                _dbContext.POS_USER.Remove(_objUserEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public IEnumerable<POS_BRANCH> GetCompanyBranch()
        {
            IEnumerable<POS_BRANCH> lst = null;
            try
            {
                lst = _dbContext.POS_BRANCH.Select(x => new POS_BRANCH()
                {
                    BRANCH_ID = x.BRANCH_ID,
                    BRANCH_DESC =x.BRANCH_DESC
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
