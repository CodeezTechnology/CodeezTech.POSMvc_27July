using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;

namespace CodeezTech.POS.Web.DAL
{
    public class DALUnits
    {
        Entities _dbContext = new Entities();
        POS_UNI _objUnitsEntity = new POS_UNI();
        public List<POS_UNI> GetUnits()
        {
            List<POS_UNI> lst = new List<POS_UNI>();
            try
            {
                lst = _dbContext.POS_UNI.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_UNI GetById(long? id)
        {
            try
            {
                _objUnitsEntity = _dbContext.POS_UNI.Find(id);
                return _objUnitsEntity;
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
                _objUnitsEntity = _dbContext.POS_UNI.OrderByDescending(x => x.UNIT_ID).FirstOrDefault();
                if (_objUnitsEntity.UNIT_ID.ToString() == null)
                    id = 1;
                else
                    id = _objUnitsEntity.UNIT_ID + 1;

                return id;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int CreateUnits(POS_UNI UnitsModel)
        {
            int rowAffected = 0;
            POS_UNI _objUnitsEntity = new POS_UNI();
            try
            {
                _objUnitsEntity.UNIT = UnitsModel.UNIT;
                _objUnitsEntity.ISACTIVE_FLAG = UnitsModel.ISACTIVE_FLAG;
                _objUnitsEntity.ISPOSTED_FLAG = false;
                _objUnitsEntity.CREATEDBY = UnitsModel.CREATEDBY;
                _objUnitsEntity.CREATEDWHEN = UnitsModel.CREATEDWHEN;

                _dbContext.POS_UNI.Add(_objUnitsEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateUnits(POS_UNI UnitsModel)
        {
            int rowAffected = 0;
            POS_UNI entity = new POS_UNI();
            try
            {
                entity = _dbContext.POS_UNI.Find(UnitsModel.UNIT_ID);

                _objUnitsEntity.UNIT = UnitsModel.UNIT;
                entity.ISACTIVE_FLAG = UnitsModel.ISACTIVE_FLAG;
                entity.ISPOSTED_FLAG = false;
                entity.MODIFIEDBY = UnitsModel.MODIFIEDBY;
                entity.MODIFIEDWHEN = UnitsModel.MODIFIEDWHEN;

                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int DeleteUnits(long id)
        {
            int rowAffected = 0;
            try
            {
                _objUnitsEntity = _dbContext.POS_UNI.Find(id);
                _dbContext.POS_UNI.Remove(_objUnitsEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public IEnumerable<POS_UNI> UnitsSelectList()
        {
            IEnumerable<POS_UNI> lst = null;
            try
            {
                lst = _dbContext.POS_UNI.Select(x => new POS_UNI()
                {
                    UNIT_ID = x.UNIT_ID,
                    UNIT = x.UNIT
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
