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
    public partial class POS_COMPANY
    {
        [NotMapped]
        public bool IsMultipleBranchh { get; set; }
        [NotMapped]
        public bool IsWarehousee { get; set; }
        [NotMapped]
        public bool IsWarehouseStockk { get; set; }
        [NotMapped]
        public bool IsWarehouseTrackingg { get; set; }
        [NotMapped]
        public bool IsWarehouseShipmentt { get; set; }
        [NotMapped]
        public bool IsVendorr { get; set; }
        [NotMapped]
        public bool IsVendorShipmentt { get; set; }
        [NotMapped]
        public bool IsDisplayTrackingg { get; set; }
        [NotMapped]
        public bool IsRFQQ { get; set; }
        [NotMapped]
        public bool IsAccountingg { get; set; }
        [NotMapped]
        public bool IsCashierCounterr { get; set; }
        [NotMapped]
        public bool IsPromotionn { get; set; }
        [NotMapped]
        public bool IsPaymentSystemm { get; set; }
    }
}
