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
    
    public partial class POS_VENDOR
    {
        public long VENDOR_ID { get; set; }
        public string VENDOR_DESC { get; set; }
        public string VENDOR_NAME { get; set; }
        public string TELEPHONE { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public string NTN_NO { get; set; }
        public long CITY_ID { get; set; }
        public long STATE_ID { get; set; }
        public Nullable<long> COUNTRY_ID { get; set; }
        public bool ISACTIVE_FLAG { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public System.DateTime MODIFIEDWHEN { get; set; }
    }
}
