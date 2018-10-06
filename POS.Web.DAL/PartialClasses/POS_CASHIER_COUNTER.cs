using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeezTech.POS.Web.DAL.PartialClasses
{
    public partial class POS_CASHIER_COUNTER
    {
        [NotMapped]
        public long COUNTER_ID { get; set; }
        [NotMapped]
        public string COUNTER_DESC { get; set; }
        [NotMapped]
        public string PC_NAME { get; set; }
        [NotMapped]
        public string IP_ADDRESS { get; set; }
        [NotMapped]
        public string MAC_ADDRESS { get; set; }
        [NotMapped]
        public long BRANCH_ID { get; set; }
        [NotMapped]
        public bool ISACTIVE_FLAG { get; set; }
        [NotMapped]
        public bool ISPOSTED_FLAG { get; set; }
        [NotMapped]
        public string CREATEDBY { get; set; }
        [NotMapped]
        public string MODIFIEDBY { get; set; }
        [NotMapped]
        public System.DateTime CREATEDWHEN { get; set; }
        [NotMapped]
        public Nullable<System.DateTime> MODIFIEDWHEN { get; set; }
    }
}
