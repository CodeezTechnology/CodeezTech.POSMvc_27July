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
    
    public partial class POS_USER_LOG
    {
        public long USER_SESSION_ID { get; set; }
        public Nullable<long> SYS_APP_MODULE_ID { get; set; }
        public long MENU_ID { get; set; }
        public string SCREEN_NAME { get; set; }
        public short ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
    }
}
