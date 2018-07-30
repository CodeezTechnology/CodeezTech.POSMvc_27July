
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.Web.DAL.EntityDataModel
{
   public partial class POS_MENU_RIGHTS
    {
       //public POS_MENU_RIGHTS()
       //{
       //    Menu = new POS_MENU();
       //}
       //public POS_MENU Menu { get; set; }
       [NotMapped]
       public string MenuName { get; set; }
    }
}
