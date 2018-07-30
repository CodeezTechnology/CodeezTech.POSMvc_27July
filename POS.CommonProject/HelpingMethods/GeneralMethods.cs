using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class GeneralMethods
    {
        public static string CloseModal(string controlId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#" + controlId + "').modal('hide');");
            sb.Append(@"</script>");

            return sb.ToString();
        }
        public static string OpenModal(string controlId)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$('#" + controlId + "').modal('show');");
            sb.Append(@"</script>");

            return sb.ToString();
        }
        public static string CustomAlert(string title,string message,string alertType)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("swal('" + title + "','" + message + "','" + alertType + "');");
            sb.Append(@"</script>");
            return sb.ToString();
        }
        public static string SuccessUpdateAlert()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("swal('Good job!','Updation Successfull..!','success');");
            sb.Append(@"</script>");
            return sb.ToString();
        }
        public static string ErrorUpdateAlert()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("swal('Error Occured!','Information not updated','error');");
            sb.Append(@"</script>");
            return sb.ToString();
        }
    }
}
