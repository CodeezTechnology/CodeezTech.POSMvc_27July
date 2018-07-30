using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.Web.BAL
{
    public class BALMenu
    {
        DALMenu mobjDALMenu = new DALMenu();
        Notify mobjNotify = new Notify();

        public IEnumerable<POS_MENU> GetAllMenu()
        {
            IEnumerable<POS_MENU> lstMenu = null;
            try
            {
                lstMenu = mobjDALMenu.GetAllMenu();
                return lstMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ParentMenu> GetParentMenu()
        {
            List<ParentMenu> parentMenu = new List<ParentMenu>();
            try
            {
               
                return parentMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public POS_MENU GetChildMenuForAdmin()
        {
            POS_MENU objMenu = new POS_MENU();
            try
            {

                objMenu.Menus = mobjDALMenu.GetParentMenu();
                foreach (var item in objMenu.Menus)
                {
                    item.ChildItems = mobjDALMenu.GetChildMenuForAdmin(item.ParentId);
                }
                return objMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public POS_MENU GetChildMenuForUser(long userId)
        {
            POS_MENU objMenu = new POS_MENU();
            try
            {
                objMenu.Menus = mobjDALMenu.GetParentMenu();
                foreach (var item in objMenu.Menus)
                {
                    item.ChildItems = mobjDALMenu.GetChildMenuForUser(item.ParentId, userId);
                }
                return objMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<POS_MENU_RIGHTS> GetMenuRightsByUserId(long id)
        {
            List<POS_MENU_RIGHTS> objList = new List<POS_MENU_RIGHTS>();
            try
            {
                objList = mobjDALMenu.GetMenuRightsByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex ;
            }
            return objList;
        }
        public List<POS_REPORT_RIGHTS> GetReportRightsByUserId(long id)
        {
            List<POS_REPORT_RIGHTS> objList = new List<POS_REPORT_RIGHTS>();
            try
            {
                objList = mobjDALMenu.GetReportRightsByUserId(id);
            }
            catch (Exception ex)
            {

                throw ex; ;
            }
            return objList;
        }
        public Notify UpdateRights(POS_MENU menu, long id)
        {
            int isRowUpdated = 0;
            try
            {
                isRowUpdated = mobjDALMenu.UpdateRights(menu, id);
                mobjNotify.RowEffected = isRowUpdated;
                if (isRowUpdated > 0)
                {
                    mobjNotify.NotifyMessage = "User rights updated successfully!";
                }
                else
                {
                    mobjNotify.NotifyMessage = "User rights not updated.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mobjNotify;
        }
      
      
    }
}
