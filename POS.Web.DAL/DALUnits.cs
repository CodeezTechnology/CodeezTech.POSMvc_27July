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
        POS_UNITS _objUnitsEntity = new POS_UNITS();
        public List<POS_UNITS> GetUnits()
        {
            List<POS_UNITS> lst = new List<POS_UNITS>();
            try
            {
                lst = _dbContext.POS_UNITS.ToList();
                return lst;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public POS_UNITS GetById(long? id)
        {
            try
            {
                _objUnitsEntity = _dbContext.POS_UNITS.Find(id);
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
                _objUnitsEntity = _dbContext.POS_UNITS.OrderByDescending(x => x.UNIT_ID).FirstOrDefault();
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
        public int CreateUnits(POS_UNITS UnitsModel)
        {
            int rowAffected = 0;
            POS_UNITS _objUnitsEntity = new POS_UNITS();
            try
            {
                _objUnitsEntity.UNIT = UnitsModel.UNIT;
                _objUnitsEntity.ISACTIVE_FLAG = UnitsModel.ISACTIVE_FLAG;
                _objUnitsEntity.ISPOSTED_FLAG = false;
                _objUnitsEntity.CREATEDBY = UnitsModel.CREATEDBY;
                _objUnitsEntity.CREATEDWHEN = UnitsModel.CREATEDWHEN;

                _dbContext.POS_UNITS.Add(_objUnitsEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateUnits(POS_UNITS UnitsModel)
        {
            int rowAffected = 0;
            POS_UNITS entity = new POS_UNITS();
            try
            {
                entity = _dbContext.POS_UNITS.Find(UnitsModel.UNIT_ID);

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
                _objUnitsEntity = _dbContext.POS_UNITS.Find(id);
                _dbContext.POS_UNITS.Remove(_objUnitsEntity);
                rowAffected = _dbContext.SaveChanges();

                return rowAffected;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public IEnumerable<POS_UNITS> UnitsSelectList()
        {
            IEnumerable<POS_UNITS> lst = null;
            try
            {
                lst = _dbContext.POS_UNITS.Select(x => new POS_UNITS()
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
