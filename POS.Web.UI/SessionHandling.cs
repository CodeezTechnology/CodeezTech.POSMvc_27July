using CodeezTech.POS.CommonProject;
using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace POS.Web.UI
{
    public class SessionHandling
    {
        public static HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }
        private static POS_USER _objUserInformation = null;
        private static POS_COMPANY _objCompanyDetail = null;
        private static POS_USER_SESSION _objUserSession = null;

        public static POS_USER UserInformation
        {
            get
            {
                try
                {
                    if (Context.Session[SessionVariables.Session_UserInfo] != null)
                    {
                        _objUserInformation = (POS_USER)Context.Session[SessionVariables.Session_UserInfo];
                    }
                }
                catch
                {

                }
                return _objUserInformation;
            }
        }
        public static POS_COMPANY CompanyInformation
        {
            get
            {
                try
                {
                    if (Context.Session[SessionVariables.Session_UserInfo] != null)
                    {
                        _objCompanyDetail = (POS_COMPANY)Context.Session[SessionVariables.Session_CompanyInfo];
                    }
                }
                catch
                {

                }
                return _objCompanyDetail;
            }
        }
        public static POS_USER_SESSION UserLoginSession
        {
            get
            {
                try
                {
                    if (Context.Session[SessionVariables.Session_UserLoginSession] != null)
                    {
                        _objUserSession = (POS_USER_SESSION)Context.Session[SessionVariables.Session_UserLoginSession];
                    }
                }
                catch
                {

                }
                return _objUserSession;
            }
        }
        public static long UserId
        {
            get
            {
                if (Context.Session[StateKeys.UserId] == null)
                    return 0;
                return Convert.ToInt32(Context.Session[StateKeys.UserId]);
            }
            set
            {
                Context.Session[StateKeys.UserId] = value;
            }
        }
        public static int LoginLevel
        {
            get
            {
                if (Context.Session[StateKeys.ActiveRoleId] == null)
                    return 0;
                return Convert.ToInt32(Context.Session[StateKeys.ActiveRoleId]);
            }
            set
            {
                Context.Session[StateKeys.ActiveRoleId] = value;
            }
        }
    }
    static class StateKeys
    {
        public const string UserId = "UserId";
        public const string ActiveRoleId = "ActiveRoleId";

    }
}