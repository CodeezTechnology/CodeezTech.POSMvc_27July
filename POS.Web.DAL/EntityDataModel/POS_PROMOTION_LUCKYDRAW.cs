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
    
    public partial class POS_PROMOTION_LUCKYDRAW
    {
        public long LUCKYDRAW_ID { get; set; }
        public long LUCKYDRAW_NO { get; set; }
        public short LUCKYDRAW_TITLE { get; set; }
        public string VALID_DATE_FROM { get; set; }
        public string VALID_DATE_TO { get; set; }
        public Nullable<bool> ISACTIVE_FLAG { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public Nullable<System.DateTime> MODIFIEDWHEN { get; set; }
    }
}
