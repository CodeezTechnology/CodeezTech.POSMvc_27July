using CodeezTech.POS.CommonProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.Web.DAL.EntityDataModel
{
    public class DALMenu
    {
        Entities _objEntityModel = new Entities();
        POS_MENU _objEntity = new POS_MENU();

        public IEnumerable<POS_MENU> GetAllMenu()
        {
            IEnumerable<POS_MENU> lstMenu = null;
            try
            {
                lstMenu = _objEntityModel.POS_MENU.ToList().OrderBy(x => x.MASTER_MENU_ID);
                return lstMenu;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in Data Layer");
            }
        }
        public List<ParentMenu> GetParentMenu()
        {
            List<ParentMenu> parentMenu = new List<ParentMenu>();
            try
            {
                var result = (from u in _objEntityModel.POS_MENU
                              where u.ILEVEL == 1
                              select new
                              {
                                  MenuId = u.MENU_ID,
                                  ILevel = u.ILEVEL,
                                  MasterMenuId = u.MASTER_MENU_ID,
                                  Controller = u.CONTROLLER,
                                  Actions = u.ACTION,
                                  FormName = u.FORM_NAME
                              }).AsEnumerable().ToList();

                if (result.Count() > 0)
                {
                    parentMenu = result.Select((x, index) => new ParentMenu
                    {
                        ParentId = x.MenuId,
                        ParentName = x.FormName
                    }).ToList();
                }
                return parentMenu;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in Data Layer");
            }
        }
        public List<POS_MENU> GetChildMenuForAdmin(long parentMenuId)
        {
            List<POS_MENU> lstChildMenu = new List<POS_MENU>();
            try
            {
                var result = (from u in _objEntityModel.POS_MENU
                              where u.MASTER_MENU_ID == parentMenuId
                              select new
                              {
                                  Controller = u.CONTROLLER,
                                  Actions = u.ACTION,
                                  FormName = u.FORM_NAME
                              }).AsEnumerable().ToList();
                foreach (var item in result)
                {
                    POS_MENU objMenu = new POS_MENU();
                    objMenu.CONTROLLER = item.Controller;
                    objMenu.ACTION = item.Actions;
                    objMenu.FORM_NAME = item.FormName;
                    lstChildMenu.Add(objMenu);
                }

                return lstChildMenu;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in Data Layer");
            }
        }
        public List<POS_MENU> GetChildMenuForUser(long parentMenuId, long userId)
        {
            List<POS_MENU> lstChildMenu = new List<POS_MENU>();
            try
            {
                var result = (from u in _objEntityModel.POS_MENU
                              join j in _objEntityModel.POS_MENU_RIGHTS on u.MENU_ID equals j.MENU_ID
                              where j.USER_ID == userId && u.MASTER_MENU_ID == parentMenuId
                              select new
                              {
                                  Controller = u.CONTROLLER,
                                  Actions = u.ACTION,
                                  FormName = u.FORM_NAME,
                                  MenuRightsId = j.MENU_RIGHTS_ID,
                                  UserId = j.USER_ID,
                                  MenuId = j.MENU_ID,
                                  Insertion = j.INSERTION_FLAG,
                                  Updation = j.UPDATION_FLAG,
                                  Deletion = j.DELETION_FLAG,
                                  Selection = j.SELECTION_FLAG,
                              }).AsEnumerable().ToList();
                foreach (var item in result)
                {
                    POS_MENU objMenu = new POS_MENU();
                    objMenu.CONTROLLER = item.Controller;
                    objMenu.ACTION = item.Actions;
                    objMenu.FORM_NAME = item.FormName;
                    objMenu.MenuRights.MENU_RIGHTS_ID = item.MenuRightsId;
                    objMenu.MenuRights.USER_ID = item.UserId;
                    objMenu.MenuRights.MENU_ID = item.MenuId;
                    objMenu.MenuRights.INSERTION_FLAG = item.Insertion;
                    objMenu.MenuRights.UPDATION_FLAG = item.Updation;
                    objMenu.MenuRights.DELETION_FLAG = item.Deletion;
                    objMenu.MenuRights.SELECTION_FLAG = item.Selection;
                    lstChildMenu.Add(objMenu);
                }

                return lstChildMenu;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in Data Layer");
            }
        }
      
        public List<POS_MENU_RIGHTS> GetMenuRightsByUserId(long id)
        {
            List<POS_MENU_RIGHTS> objList = new List<POS_MENU_RIGHTS>();
            try
            {
                var result = (from u in _objEntityModel.POS_MENU
                              join j in _objEntityModel.POS_MENU_RIGHTS
                              on new { MenuId = u.MENU_ID, UserId = id } equals
                               new { MenuId = j.MENU_ID, UserId = j.USER_ID }
                               into rights
                              from ctx in rights.DefaultIfEmpty()
                              where u.ILEVEL == 2
                              select new
                              {
                                  MenuRightsId = (ctx.MENU_RIGHTS_ID == null ? 0 : ctx.MENU_RIGHTS_ID),
                                  UserId = (ctx.USER_ID == null ? 0 : ctx.USER_ID),
                                  MenuId = (ctx.MENU_ID == null ? 0 : ctx.MENU_ID),
                                  MenuName = (u.FORM_NAME == null ? null : u.FORM_NAME),
                                  Insertion = (ctx != null ?  ctx.INSERTION_FLAG : false),
                                  Updation = (ctx != null ?  ctx.UPDATION_FLAG: false),
                                  Deletion = (ctx != null ?  ctx.DELETION_FLAG: false),
                                  Selection = (ctx != null ? ctx.SELECTION_FLAG : false)
                              }).AsEnumerable().Select((x, index) => new POS_MENU_RIGHTS
                              {
                                  MENU_RIGHTS_ID = x.MenuRightsId,
                                  USER_ID = x.UserId,
                                  MENU_ID = x.MenuId,
                                  MenuName = x.MenuName,
                                  INSERTION_FLAG = x.Insertion,
                                  UPDATION_FLAG = x.Updation,
                                  DELETION_FLAG = x.Deletion,
                                  SELECTION_FLAG = x.Selection
                              }).ToList();
                if (result != null)
                {
                    objList = result;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
            return objList;
        }
        public List<POS_REPORT_RIGHTS> GetReportRightsByUserId(long id)
        {
            List<POS_REPORT_RIGHTS> objList = new List<POS_REPORT_RIGHTS>();
            try
            {
                var result = (from u in _objEntityModel.POS_REPORTS
                              join j in _objEntityModel.POS_REPORT_RIGHTS
                              on new { ReportId = u.REPORT_ID, UserId = id } equals
                               new { ReportId = j.REPORT_ID, UserId = j.USER_ID }
                               into rights
                              from ctx in rights.DefaultIfEmpty()
                              where u.ILEVEL == 2
                              select new
                              {
                                  ReportRightsId = (ctx.REPORT_RIGHTS_ID == null ? 0 : ctx.REPORT_RIGHTS_ID),
                                  UserId = (ctx.USER_ID == null ? 0 : ctx.USER_ID),
                                  ReportId = (u.REPORT_ID == null ? 0 : u.REPORT_ID),
                                  ReportName = (u.REPORT_NAME == null ? null : u.REPORT_NAME)
                              }).AsEnumerable().Select((x, index) => new POS_REPORT_RIGHTS
                              {
                                  USER_ID = x.UserId,
                                  REPORT_RIGHTS_ID = x.ReportRightsId,
                                  REPORT_ID = x.ReportId,
                                  ReportName = x.ReportName,
                                  Selection = (x.ReportRightsId != 0 ? true : false)
                              }).ToList();
                if (result != null)
                {
                    objList = result;
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
            return objList;
        }
        public int UpdateRights(POS_MENU menu,long id)
        {
            int isRowUpdated = 0;
            try
            {
                DeleteMenuRightsByUserId(id);
                isRowUpdated = UpdateMenuRights(menu.MenuRightsList, id);
                DeleteReportRightsByUserId(id);
                isRowUpdated = UpdateReportRights(menu.ReportRightsList, id);
            }
                catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new UIException("User Rights Info not completed in Data Layer");
            }
            return isRowUpdated;
        }
        public int DeleteMenuRightsByUserId(long id)
        {
            int isRowsDeleted = 0;
            try
            {
                var result = (from u in _objEntityModel.POS_MENU_RIGHTS
                              where u.USER_ID == id
                              select u).ToList();
                foreach (var items in result)
                {
                    _objEntityModel.POS_MENU_RIGHTS.Remove(items);
                    isRowsDeleted = _objEntityModel.SaveChanges();
                }
                return isRowsDeleted;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int DeleteReportRightsByUserId(long id)
        {
            int isRowsDeleted = 0;
            try
            {
                var result = (from u in _objEntityModel.POS_REPORT_RIGHTS
                              where u.USER_ID == id
                              select u).ToList();
                foreach (var items in result)
                {
                    _objEntityModel.POS_REPORT_RIGHTS.Remove(items);
                    isRowsDeleted = _objEntityModel.SaveChanges();
                }
                return isRowsDeleted;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
        }
        public int UpdateMenuRights(List<POS_MENU_RIGHTS> lstMenuRights, long userId)
        {
            int isRowsCreated = 0;
          
            try
            {
                foreach (var item in lstMenuRights)
                {
                    if (item.INSERTION_FLAG == true || item.UPDATION_FLAG == true || item.DELETION_FLAG == true || item.SELECTION_FLAG == true)
                    {
                        POS_MENU_RIGHTS entity = new POS_MENU_RIGHTS();
                        entity.MENU_RIGHTS_ID = GetMaxMenuRightsId();
                        entity.MENU_ID = item.MENU_ID;
                        entity.USER_ID = userId;
                        entity.INSERTION_FLAG = item.INSERTION_FLAG;
                        entity.UPDATION_FLAG = item.UPDATION_FLAG;
                        entity.DELETION_FLAG = item.DELETION_FLAG;
                        entity.SELECTION_FLAG = item.SELECTION_FLAG;
                        entity.ISPOSTED_FLAG = false;
                        entity.CREATEDBY = item.CREATEDBY;
                        entity.CREATEDWHEN = item.CREATEDWHEN;

                        _objEntityModel.POS_MENU_RIGHTS.Add(entity);
                        isRowsCreated = _objEntityModel.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
               // ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
            return isRowsCreated;
        }
        public int UpdateReportRights(List<POS_REPORT_RIGHTS> lstReportRights, long userId)
        {
            int isRowsCreated = 0;
           
            try
            {
                foreach (var item in lstReportRights)
                {
                    if (item.Selection == true)
                    {
                        POS_REPORT_RIGHTS entity = new POS_REPORT_RIGHTS();
                        entity.REPORT_RIGHTS_ID = GetMaxReportRightsId();
                        entity.REPORT_ID = item.REPORT_ID;
                        entity.USER_ID = userId;
                        entity.ISPOSTED_FLAG = false;
                        entity.CREATEDBY = item.CREATEDBY;
                        entity.CREATEDWHEN = item.CREATEDWHEN;

                        _objEntityModel.POS_REPORT_RIGHTS.Add(entity);
                        isRowsCreated = _objEntityModel.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                //ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException(ex.Message.ToString());
            }
            return isRowsCreated;
        }
        public long GetMaxMenuRightsId()
        {
            POS_MENU_RIGHTS entity = new POS_MENU_RIGHTS();
            long id = 0;
            try
            {
                entity = _objEntityModel.POS_MENU_RIGHTS.OrderByDescending(x => x.MENU_RIGHTS_ID).FirstOrDefault();
                if (entity == null)
                    id = 1;
                else
                    id = entity.MENU_RIGHTS_ID + 1;

                return id;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
        public long GetMaxReportRightsId()
        {
            POS_REPORT_RIGHTS entity = new POS_REPORT_RIGHTS();
            long id = 0;
            try
            {
                entity = _objEntityModel.POS_REPORT_RIGHTS.OrderByDescending(x => x.REPORT_RIGHTS_ID).FirstOrDefault();
                if (entity == null)
                    id = 1;
                else
                    id = entity.REPORT_RIGHTS_ID + 1;

                return id;
            }
            catch (Exception ex)
            {
                ExceptionLogger.WriteExceptionInDB(ex, ExceptionLevel.DAL, ExceptionType.Error);
                throw new DALException();
            }
        }
    }
}
