using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Counter ID")]
        public long COUNTER_IDD { get; set; }
        [NotMapped]
        [DisplayName("Counter Description")]
        public string COUNTER_DESCC { get; set; }
        [NotMapped]
        [DisplayName("PC Name")]
        public string PC_NAMEE { get; set; }
        [NotMapped]
        [DisplayName("PC Address")]
        public string IP_ADDRESSS { get; set; }
        [NotMapped]
        [DisplayName("MAC Address")]
        public string MAC_ADDRESSS { get; set; }
        [NotMapped]
        [DisplayName("Branch Name")]
        public Nullable<int> BRANCH_IDD { get; set; }
        //public long BRANCH_IDD { get; set; }
        [NotMapped]
        [DisplayName("Active")]
        public bool ISACTIVE_FLAGG { get; set; }
        [NotMapped]
        [DisplayName("Posted")]
        public bool ISPOSTED_FLAGG { get; set; }
        [NotMapped]
        [DisplayName("Created By")]
        public string CREATEDBYY { get; set; }
        [NotMapped]
        [DisplayName("Modified By")]
        public string MODIFIEDBYY { get; set; }
        [NotMapped]
        [DisplayName("Created On")]
        public System.DateTime CREATEDWHENN { get; set; }
        [NotMapped]
        [DisplayName("Modified On")]
        public Nullable<System.DateTime> MODIFIEDWHENN { get; set; }
    }
}
