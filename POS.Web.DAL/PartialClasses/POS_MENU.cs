
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.Web.DAL.EntityDataModel
{
    public partial class POS_MENU
    {
        public POS_MENU()
        {
            MenuRights = new POS_MENU_RIGHTS();
            Menus = new List<ParentMenu>();
            MenuRightsList = new List<POS_MENU_RIGHTS>();
            ReportRightsList = new List<POS_REPORT_RIGHTS>();
        }
        [NotMapped]
        public POS_MENU_RIGHTS MenuRights { get; set; }
        [NotMapped]
        public List<ParentMenu> Menus { get; set; }
        [NotMapped]
        public List<POS_MENU_RIGHTS> MenuRightsList { get; set; }
        [NotMapped]
        public List<POS_REPORT_RIGHTS> ReportRightsList { get; set; }
    }
    public class ParentMenu
    {
        public long ParentId { get; set; }
        public string ParentName { get; set; }
        public List<POS_MENU> ChildItems { get; set; }
    }
   
}
