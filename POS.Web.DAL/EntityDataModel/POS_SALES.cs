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
    
    public partial class POS_SALES
    {
        public long SALE_ID { get; set; }
        public string CUSTOMER_CODE { get; set; }
        public string SALE_CODE { get; set; }
        public System.DateTime SALE_DATE { get; set; }
        public decimal GRAND_TOTAL { get; set; }
        public decimal CASH_RECIEVE { get; set; }
        public decimal CASH_RETURN { get; set; }
        public Nullable<int> EXTRA_DISCOUNT { get; set; }
        public long BRANCH_ID { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public Nullable<System.DateTime> MODIFIEDWHEN { get; set; }
    }
}
