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
    
    public partial class POS_WEARHOUSE_PRODUCTS
    {
        public long WEARHOUSE_PRODUCT_ID { get; set; }
        public string WEARHOUSE_PRODUCT_CODE { get; set; }
        public string PRODUCT_LABEL { get; set; }
        public string PRODUCT_DESC { get; set; }
        public long UNIT_ID { get; set; }
        public string UNIT_RANGE { get; set; }
        public System.DateTime SHIPPING_DATE { get; set; }
        public long VSHIPPMENT_ID { get; set; }
        public Nullable<long> SUPERVISOR_ID { get; set; }
        public Nullable<long> RIDER_ID { get; set; }
        public short PWP_ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public Nullable<System.DateTime> MODIFIEDWHEN { get; set; }
    }
}