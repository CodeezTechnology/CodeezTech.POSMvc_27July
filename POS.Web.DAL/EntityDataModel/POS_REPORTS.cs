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
    
    public partial class POS_REPORTS
    {
        public long REPORT_ID { get; set; }
        public short ILEVEL { get; set; }
        public short MASTER_MENU_ID { get; set; }
        public string CONTROLLER { get; set; }
        public string ACTION { get; set; }
        public string REPORT_NAME { get; set; }
        public short ISACTIVE_FLAG { get; set; }
        public Nullable<bool> ISGROUPING_FLAG { get; set; }
        public Nullable<bool> ISFROM_DATE { get; set; }
        public Nullable<bool> ISTO_DATE { get; set; }
        public Nullable<bool> ISSHIFT { get; set; }
        public Nullable<bool> ISCHART { get; set; }
        public Nullable<bool> ISEXPORT { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
    }
}
