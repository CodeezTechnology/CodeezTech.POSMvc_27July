//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeezTech.POS.Web.DAL.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class POS_WEARHOUSE_STOCK
    {
        public long WSTOCK_ID { get; set; }
        public string WSTOCK_CODE { get; set; }
        public long WEARHOUSE_ID { get; set; }
        public System.DateTime DATE { get; set; }
        public long PRODUCT_ID { get; set; }
        public int QUANTITY_IN { get; set; }
        public int QUANTITY_OUT { get; set; }
        public string STOCK_TYPE { get; set; }
        public decimal UNIT_PRICE { get; set; }
        public decimal TOTAL_PRICE { get; set; }
        public string VSHIPPMENT_CODE { get; set; }
        public long COMPANY_ID { get; set; }
        public short ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public Nullable<System.DateTime> MODIFIEDWHEN { get; set; }
    }
}
