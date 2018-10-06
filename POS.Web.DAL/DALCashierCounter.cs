using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALCashierCounter
    {
        Entities _dbContext = new Entities();
        POS_CASHIER_COUNTER _objCashierCounterEntity = new POS_CASHIER_COUNTER();
        
        public List<POS_CASHIER_COUNTER> List()
        {
            List<POS_CASHIER_COUNTER> lst = new List<POS_CASHIER_COUNTER>();
            try
            {
                //lst = _dbContext.POS_CASHIER_COUNTER.ToList();
                var result = (from ctx in _dbContext.POS_CASHIER_COUNTER
                              join j in _dbContext.POS_CASHIER_COUNTER on ctx.BRANCH_ID equals j.BRANCH_ID
                              select new
                              {
                                  CounterDesc = ctx.COUNTER_DESC,
                                  PCName = ctx.PC_NAME,
                                  IPAddress = ctx.IP_ADDRESS,
                                  MacAddress = ctx.MAC_ADDRESS,
                                  IsActive = ctx.ISACTIVE_FLAG,
                                  BranchId = ctx.BRANCH_ID,
                                  IsPosted = ctx.ISPOSTED_FLAG,
                                  CreatedBy = ctx.CREATEDBY,
                                  ModifiedBy = ctx.MODIFIEDBY,
                                  CreatedWhen = ctx.CREATEDWHEN,
                                  ModifiedWhen = ctx.MODIFIEDWHEN
                              }).ToList();
                foreach (var item in result)
                {
                    POS_CASHIER_COUNTER _entity = new POS_CASHIER_COUNTER();
                    _entity.COUNTER_DESC = item.CounterDesc;
                    _entity.PC_NAME = item.PCName;
                    _entity.IP_ADDRESS = item.IPAddress;
                    _entity.MAC_ADDRESS = item.MacAddress;              
                    _entity.ISACTIVE_FLAG = item.IsActive;
                    _entity.BRANCH_ID = item.BranchId;
                    _entity.ISPOSTED_FLAG = item.IsPosted;
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
        public POS_CASHIER_COUNTER GetById(long? id)
        {
            try
            {
                _objCashierCounterEntity = _dbContext.POS_CASHIER_COUNTER.Find(id);
                return _objCashierCounterEntity;
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
                _objCashierCounterEntity = _dbContext.POS_CASHIER_COUNTER.OrderByDescending(x => x.USER_ID).FirstOrDefault();
                if (_objCashierCounterEntity.USER_ID.ToString() == null)
                    id = 1;
                else
                    id = _objCashierCounterEntity.USER_ID + 1;

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
                _objCashierCounterEntity = _dbContext.POS_CASHIER_COUNTER.OrderByDescending(x => x.CODE).FirstOrDefault();
                if (_objCashierCounterEntity.CODE.ToString() == null)
                    code = "0001";
                else
                    maxCode = Formatter.SetValidValueToInt(_objCashierCounterEntity.CODE) + 1;
                code = maxCode.ToString().PadLeft(4, '0');

                return code;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public int Create(POS_CASHIER_COUNTER userModel)
        {
            int rowAffected = 0;
            POS_CASHIER_COUNTER _objCashierCounterEntity = new POS_CASHIER_COUNTER();
            try
            {
                _objCashierCounterEntity.USER_ID = GetMaxId();
                _objCashierCounterEntity.CODE = userModel.CODE;
                _objCashierCounterEntity.USERNAME = userModel.USERNAME;
                _objCashierCounterEntity.PASSWORD = userModel.PASSWORD;
                _objCashierCounterEntity.EMAIL = userModel.EMAIL;
                _objCashierCounterEntity.ISACTIVE_FLAG = userModel.ISACTIVE_FLAG;
                _objCashierCounterEntity.LOGIN_TYPE = userModel.LOGIN_TYPE;
                _objCashierCounterEntity.MASTER_PASSWORD = userModel.MASTER_PASSWORD;
                _objCashierCounterEntity.BRANCH_ID = userModel.BranchId;
                _objCashierCounterEntity.ISPOSTED_FLAG = false;
                _objCashierCounterEntity.CREATEDBY = userModel.CREATEDBY;
                _objCashierCounterEntity.CREATEDWHEN = userModel.CREATEDWHEN;
                _objCashierCounterEntity.MODIFIEDBY = userModel.MODIFIEDBY;
                _dbContext.POS_CASHIER_COUNTER.Add(_objCashierCounterEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException("User Info not completed in Data Layer");
            }
        }
        public int Update(POS_CASHIER_COUNTER userModel)
        {
            int rowAffected = 0;
            POS_CASHIER_COUNTER entity = new POS_CASHIER_COUNTER();
            try
            {
                //_dbContext.Entry(userModel).State = System.Data.Entity.EntityState.Modified;
                entity = _dbContext.POS_CASHIER_COUNTER.Find(userModel.USER_ID);

                entity.USER_ID = userModel.USER_ID;
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
                _objCashierCounterEntity = _dbContext.POS_CASHIER_COUNTER.Find(id);
                _dbContext.POS_CASHIER_COUNTER.Remove(_objCashierCounterEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public IEnumerable<POS_CASHIER_COUNTER> GetCompanyBranch()
        {
            IEnumerable<POS_CASHIER_COUNTER> lst = null;
            try
            {
                lst = _dbContext.POS_CASHIER_COUNTER.Select(x => new POS_CASHIER_COUNTER()
                {
                    BRANCH_ID = x.BRANCH_ID,
                    BRANCH_DESC = x.BRANCH_DESC
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
