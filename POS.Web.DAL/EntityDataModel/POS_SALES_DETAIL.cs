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
    
    public partial class POS_SALES_DETAIL
    {
        public string SALE_CODE { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public long PRODUCT_ID { get; set; }
        public decimal PRICE { get; set; }
        public int QUANTITY { get; set; }
        public int DISCOUNT_PER { get; set; }
        public int DISCOUNT_AMOUNT { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public System.DateTime MODIFIEDWHEN { get; set; }
    }
}
