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
    
    public partial class POS_RFQ_LOG
    {
        public long RFQ_LOG_ID { get; set; }
        public long RFQ_ID { get; set; }
        public System.DateTime DATE { get; set; }
        public string ORDER_STATUS { get; set; }
        public long VENDOR_ID { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
    }
}
