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
    
    public partial class POS_STATE
    {
        public long STATE_ID { get; set; }
        public string CODE { get; set; }
        public string STATE_DESC { get; set; }
        public long COUNTRY_ID { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public System.DateTime MODIFIEDWHEN { get; set; }
    }
}
