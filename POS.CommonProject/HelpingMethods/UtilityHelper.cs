using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CodeezTech.POS.CommonProject
{
    public class UtilityHelper
    {
        public void ManageToolbarRights(HtmlGenericControl toolbarPane, DataRow drFormRights)
        {
            if (drFormRights != null)
            {
                Button btnNew = (Button)toolbarPane.FindControl("btnNew");
                Button btnUpdate = (Button)toolbarPane.FindControl("btnUpdate");
                Button btnDelete = (Button)toolbarPane.FindControl("btnDelete");
                Button btnNavigate = (Button)toolbarPane.FindControl("btnNavigate");

                if (drFormRights["PMR_INSERTION_FLAG"] != null)
                {
                    if (btnNew != null)
                    {
                        if (drFormRights["PMR_INSERTION_FLAG"] == null || Formatter.SetValidValueToBoolean(drFormRights["PMR_INSERTION_FLAG"]) == false)
                        {
                            btnNew.Enabled = false;
                        }
                        else
                        {
                            if (btnNew.Enabled == false)
                            {
                                btnNew.Enabled = true;
                            }
                        }
                    }
                }
                if (drFormRights["PMR_UPDATION_FLAG"] != null)
                {
                    if (btnUpdate != null)
                    {
                        if (drFormRights["PMR_UPDATION_FLAG"] == null || Formatter.SetValidValueToBoolean(drFormRights["PMR_UPDATION_FLAG"]) == false)
                        {
                            btnUpdate.Enabled = false;
                        }
                        else
                        {
                            if (btnUpdate.Enabled == false)
                            {
                                btnUpdate.Enabled = true;
                            }
                        }
                    }
                }
                if (drFormRights["[PMR_DELETION_FLAG"] != null)
                {
                    if (btnDelete != null)
                    {
                        if (drFormRights["[PMR_DELETION_FLAG"] == null || Formatter.SetValidValueToBoolean(drFormRights["[PMR_DELETION_FLAG"]) == false)
                        {
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            if (btnDelete.Enabled == false)
                            {
                                btnDelete.Enabled = true;
                            }
                        }
                    }
                }
                if (drFormRights["PMR_SELECTION_FLAG"] != null)
                {
                    if (btnNavigate != null)
                    {
                        if (drFormRights["PMR_SELECTION_FLAG"] == null || Formatter.SetValidValueToBoolean(drFormRights["[PMR_SELECTION_FLAG"]) == false)
                        {
                            btnNavigate.Enabled = false;
                        }
                        else
                        {
                            if (btnNavigate.Enabled == false)
                            {
                                btnNavigate.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        
    }
   

}
