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
    
    public partial class POS_VENDOR_SHIPPMENT
    {
        public long VSHIPPMENT_ID { get; set; }
        public string VSHIPPMENT_CODE { get; set; }
        public System.DateTime VSHIPPMENT_DATE { get; set; }
        public long PURCHASE_ORDER_ID { get; set; }
        public long WEARHOUSE_ID { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public Nullable<System.DateTime> MODIFIEDWHEN { get; set; }
    }
}
