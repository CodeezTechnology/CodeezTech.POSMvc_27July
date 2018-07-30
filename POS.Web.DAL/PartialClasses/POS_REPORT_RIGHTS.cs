using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.Web.DAL.EntityDataModel
{
    public partial class POS_REPORT_RIGHTS
    {
        [NotMapped]
        public string ReportName { get; set; }
        [NotMapped]
        public bool Selection { get; set; }
    }
}
