using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeezTech.POS.CommonProject
{
   public class StateHelper
    {
        public static HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }
        private static BOfrmUserLogin _objUserInformation = null;
        private static BOfrmCompanyDetail _objCompanyDetail = null;
        private static BOUserLoginSession _objUserSession = null;

        public static BOfrmUserLogin UserInformation
        {
            get
            {
                try
                {
                    if (Context.Session[SessionVariables.Session_UserInfo] != null)
                    {
                        _objUserInformation = (BOfrmUserLogin)Context.Session[SessionVariables.Session_UserInfo];
                    }
                }
                catch
                {

                }
                return _objUserInformation;
            }
        }
        public static BOfrmCompanyDetail CompanyInformation
        {
            get
            {
                try
                {
                    if (Context.Session[SessionVariables.Session_UserInfo] != null)
                    {
                        _objCompanyDetail = (BOfrmCompanyDetail)Context.Session[SessionVariables.Session_CompanyInfo];
                    }
                }
                catch
                {

                }
                return _objCompanyDetail;
            }
        }
        public static BOUserLoginSession UserLoginSession
        {
            get
            {
                try
                {
                    if (Context.Session[SessionVariables.Session_UserLoginSession] != null)
                    {
                        _objUserSession = (BOUserLoginSession)Context.Session[SessionVariables.Session_UserLoginSession];
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
