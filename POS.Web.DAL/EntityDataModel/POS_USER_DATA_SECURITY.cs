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
    
    public partial class POS_USER_DATA_SECURITY
    {
        public long ID { get; set; }
        public long USER_ID { get; set; }
        public int SERIAL_NO { get; set; }
        public int PARAMETER_TYPE { get; set; }
        public string PARAMETER_TABLE { get; set; }
        public string PARAMETER_VALUE { get; set; }
        public Nullable<bool> ISACTIVE_FLAG { get; set; }
        public bool ISPOSTED_FLAG { get; set; }
        public string CREATEDBY { get; set; }
        public string MODIFIEDBY { get; set; }
        public System.DateTime CREATEDWHEN { get; set; }
        public System.DateTime MODIFIEDWHEN { get; set; }
    }
}
