﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<POS_ACCESS_GROUP> POS_ACCESS_GROUP { get; set; }
        public virtual DbSet<POS_ACCOUNTS_LEVEL_I> POS_ACCOUNTS_LEVEL_I { get; set; }
        public virtual DbSet<POS_ACCOUNTS_LEVEL_II> POS_ACCOUNTS_LEVEL_II { get; set; }
        public virtual DbSet<POS_ACCOUNTS_LEVEL_III> POS_ACCOUNTS_LEVEL_III { get; set; }
        public virtual DbSet<POS_BANK> POS_BANK { get; set; }
        public virtual DbSet<POS_BANK_BRANCH> POS_BANK_BRANCH { get; set; }
        public virtual DbSet<POS_BRANCH> POS_BRANCH { get; set; }
        public virtual DbSet<POS_CASHIER_COUNTER> POS_CASHIER_COUNTER { get; set; }
        public virtual DbSet<POS_CITY> POS_CITY { get; set; }
        public virtual DbSet<POS_COMPANY> POS_COMPANY { get; set; }
        public virtual DbSet<POS_COUNTRY> POS_COUNTRY { get; set; }
        public virtual DbSet<POS_CUSTOMER> POS_CUSTOMER { get; set; }
        public virtual DbSet<POS_CUSTOMER_PROMOTIONS> POS_CUSTOMER_PROMOTIONS { get; set; }
        public virtual DbSet<POS_DISPLAY_FLOORS> POS_DISPLAY_FLOORS { get; set; }
        public virtual DbSet<POS_DISPLAY_INVENTORY_TRACKING> POS_DISPLAY_INVENTORY_TRACKING { get; set; }
        public virtual DbSet<POS_DISPLAY_RAGS> POS_DISPLAY_RAGS { get; set; }
        public virtual DbSet<POS_DISPLAY_RAGS_FLOOR> POS_DISPLAY_RAGS_FLOOR { get; set; }
        public virtual DbSet<POS_DISPLAY_SECTIONS> POS_DISPLAY_SECTIONS { get; set; }
        public virtual DbSet<POS_DISPLAY_STOCK> POS_DISPLAY_STOCK { get; set; }
        public virtual DbSet<POS_EMPLOYEE_TYPE> POS_EMPLOYEE_TYPE { get; set; }
        public virtual DbSet<POS_EXCEPTION_LOG> POS_EXCEPTION_LOG { get; set; }
        public virtual DbSet<POS_GENDER> POS_GENDER { get; set; }
        public virtual DbSet<POS_GENERAL_LEDGER> POS_GENERAL_LEDGER { get; set; }
        public virtual DbSet<POS_INVOICE> POS_INVOICE { get; set; }
        public virtual DbSet<POS_LOCATION> POS_LOCATION { get; set; }
        public virtual DbSet<POS_MENU> POS_MENU { get; set; }
        public virtual DbSet<POS_MENU_RIGHTS> POS_MENU_RIGHTS { get; set; }
        public virtual DbSet<POS_PAYMENT_DETAIL> POS_PAYMENT_DETAIL { get; set; }
        public virtual DbSet<POS_PAYMENT_TYPE> POS_PAYMENT_TYPE { get; set; }
        public virtual DbSet<POS_PRODUCT> POS_PRODUCT { get; set; }
        public virtual DbSet<POS_PRODUCT_CATEGORY> POS_PRODUCT_CATEGORY { get; set; }
        public virtual DbSet<POS_PRODUCT_PROMOTIONS> POS_PRODUCT_PROMOTIONS { get; set; }
        public virtual DbSet<POS_PRODUCT_TYPE> POS_PRODUCT_TYPE { get; set; }
        public virtual DbSet<POS_PROMOTION_LUCKDRAW_COUPON> POS_PROMOTION_LUCKDRAW_COUPON { get; set; }
        public virtual DbSet<POS_PROMOTION_LUCKYDRAW> POS_PROMOTION_LUCKYDRAW { get; set; }
        public virtual DbSet<POS_PROMOTIONS> POS_PROMOTIONS { get; set; }
        public virtual DbSet<POS_PURCHASE_ORDER> POS_PURCHASE_ORDER { get; set; }
        public virtual DbSet<POS_PURCHASE_ORDER_LOG> POS_PURCHASE_ORDER_LOG { get; set; }
        public virtual DbSet<POS_REFUND_PRODUCTS> POS_REFUND_PRODUCTS { get; set; }
        public virtual DbSet<POS_REPORT_RIGHTS> POS_REPORT_RIGHTS { get; set; }
        public virtual DbSet<POS_REPORTS> POS_REPORTS { get; set; }
        public virtual DbSet<POS_RFQ> POS_RFQ { get; set; }
        public virtual DbSet<POS_RFQ_DETAIL> POS_RFQ_DETAIL { get; set; }
        public virtual DbSet<POS_RFQ_LOG> POS_RFQ_LOG { get; set; }
        public virtual DbSet<POS_RIDER> POS_RIDER { get; set; }
        public virtual DbSet<POS_SALES> POS_SALES { get; set; }
        public virtual DbSet<POS_SECTIONS> POS_SECTIONS { get; set; }
        public virtual DbSet<POS_SHIFT> POS_SHIFT { get; set; }
        public virtual DbSet<POS_STATE> POS_STATE { get; set; }
        public virtual DbSet<POS_SUPERVISOR> POS_SUPERVISOR { get; set; }
        public virtual DbSet<POS_SYS_APP_MODULE> POS_SYS_APP_MODULE { get; set; }
        public virtual DbSet<POS_SYS_TRANSACTION_LOG> POS_SYS_TRANSACTION_LOG { get; set; }
        public virtual DbSet<POS_USER> POS_USER { get; set; }
        public virtual DbSet<POS_USER_DATA_SECURITY> POS_USER_DATA_SECURITY { get; set; }
        public virtual DbSet<POS_USER_SESSION> POS_USER_SESSION { get; set; }
        public virtual DbSet<POS_VENDOR> POS_VENDOR { get; set; }
        public virtual DbSet<POS_VENDOR_SHIPPMENT> POS_VENDOR_SHIPPMENT { get; set; }
        public virtual DbSet<POS_VENDOR_SHIPPMENT_DETAIL> POS_VENDOR_SHIPPMENT_DETAIL { get; set; }
        public virtual DbSet<POS_WEARHOUSE> POS_WEARHOUSE { get; set; }
        public virtual DbSet<POS_WEARHOUSE_FLOOR> POS_WEARHOUSE_FLOOR { get; set; }
        public virtual DbSet<POS_WEARHOUSE_INVENTORY_TRACKING> POS_WEARHOUSE_INVENTORY_TRACKING { get; set; }
        public virtual DbSet<POS_WEARHOUSE_PRODUCTS> POS_WEARHOUSE_PRODUCTS { get; set; }
        public virtual DbSet<POS_WEARHOUSE_RAGS> POS_WEARHOUSE_RAGS { get; set; }
        public virtual DbSet<POS_WEARHOUSE_RAGS_FLOOR> POS_WEARHOUSE_RAGS_FLOOR { get; set; }
        public virtual DbSet<POS_WEARHOUSE_SECTIONS> POS_WEARHOUSE_SECTIONS { get; set; }
        public virtual DbSet<POS_WEARHOUSE_SHIPPMENT> POS_WEARHOUSE_SHIPPMENT { get; set; }
        public virtual DbSet<POS_WEARHOUSE_SHIPPMENT_DETAIL> POS_WEARHOUSE_SHIPPMENT_DETAIL { get; set; }
        public virtual DbSet<POS_WEARHOUSE_STOCK> POS_WEARHOUSE_STOCK { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<POS_CUSTOMER_PROMOTION_DETAIL> POS_CUSTOMER_PROMOTION_DETAIL { get; set; }
        public virtual DbSet<POS_SALES_DETAIL> POS_SALES_DETAIL { get; set; }
        public virtual DbSet<POS_USER_LOG> POS_USER_LOG { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spCrudPOSUser(Nullable<long> uSER_ID, string pU_CODE, string pU_USERNAME, string pU_PASSWORD, string pU_EMAIL, Nullable<short> pU_ISACTIVE_FLAG, Nullable<short> pU_LOGIN_TYPE, string pU_MASTER_PASSWORD, Nullable<long> bRANCH_ID, Nullable<short> pU_ISPOSTED_FLAG, string cREATEDBY, string mODIFIEDBY, Nullable<System.DateTime> cREATEDWHEN, Nullable<System.DateTime> mODIFIEDWHEN)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var pU_CODEParameter = pU_CODE != null ?
                new ObjectParameter("PU_CODE", pU_CODE) :
                new ObjectParameter("PU_CODE", typeof(string));
    
            var pU_USERNAMEParameter = pU_USERNAME != null ?
                new ObjectParameter("PU_USERNAME", pU_USERNAME) :
                new ObjectParameter("PU_USERNAME", typeof(string));
    
            var pU_PASSWORDParameter = pU_PASSWORD != null ?
                new ObjectParameter("PU_PASSWORD", pU_PASSWORD) :
                new ObjectParameter("PU_PASSWORD", typeof(string));
    
            var pU_EMAILParameter = pU_EMAIL != null ?
                new ObjectParameter("PU_EMAIL", pU_EMAIL) :
                new ObjectParameter("PU_EMAIL", typeof(string));
    
            var pU_ISACTIVE_FLAGParameter = pU_ISACTIVE_FLAG.HasValue ?
                new ObjectParameter("PU_ISACTIVE_FLAG", pU_ISACTIVE_FLAG) :
                new ObjectParameter("PU_ISACTIVE_FLAG", typeof(short));
    
            var pU_LOGIN_TYPEParameter = pU_LOGIN_TYPE.HasValue ?
                new ObjectParameter("PU_LOGIN_TYPE", pU_LOGIN_TYPE) :
                new ObjectParameter("PU_LOGIN_TYPE", typeof(short));
    
            var pU_MASTER_PASSWORDParameter = pU_MASTER_PASSWORD != null ?
                new ObjectParameter("PU_MASTER_PASSWORD", pU_MASTER_PASSWORD) :
                new ObjectParameter("PU_MASTER_PASSWORD", typeof(string));
    
            var bRANCH_IDParameter = bRANCH_ID.HasValue ?
                new ObjectParameter("BRANCH_ID", bRANCH_ID) :
                new ObjectParameter("BRANCH_ID", typeof(long));
    
            var pU_ISPOSTED_FLAGParameter = pU_ISPOSTED_FLAG.HasValue ?
                new ObjectParameter("PU_ISPOSTED_FLAG", pU_ISPOSTED_FLAG) :
                new ObjectParameter("PU_ISPOSTED_FLAG", typeof(short));
    
            var cREATEDBYParameter = cREATEDBY != null ?
                new ObjectParameter("CREATEDBY", cREATEDBY) :
                new ObjectParameter("CREATEDBY", typeof(string));
    
            var mODIFIEDBYParameter = mODIFIEDBY != null ?
                new ObjectParameter("MODIFIEDBY", mODIFIEDBY) :
                new ObjectParameter("MODIFIEDBY", typeof(string));
    
            var cREATEDWHENParameter = cREATEDWHEN.HasValue ?
                new ObjectParameter("CREATEDWHEN", cREATEDWHEN) :
                new ObjectParameter("CREATEDWHEN", typeof(System.DateTime));
    
            var mODIFIEDWHENParameter = mODIFIEDWHEN.HasValue ?
                new ObjectParameter("MODIFIEDWHEN", mODIFIEDWHEN) :
                new ObjectParameter("MODIFIEDWHEN", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCrudPOSUser", uSER_IDParameter, pU_CODEParameter, pU_USERNAMEParameter, pU_PASSWORDParameter, pU_EMAILParameter, pU_ISACTIVE_FLAGParameter, pU_LOGIN_TYPEParameter, pU_MASTER_PASSWORDParameter, bRANCH_IDParameter, pU_ISPOSTED_FLAGParameter, cREATEDBYParameter, mODIFIEDBYParameter, cREATEDWHENParameter, mODIFIEDWHENParameter);
        }
    
        public virtual int spDBAutoUpdator()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDBAutoUpdator");
        }
    
        public virtual int spDeletePOSUser(Nullable<long> uSER_ID)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeletePOSUser", uSER_IDParameter);
        }
    
        public virtual ObjectResult<spGetAllMenus_Result> spGetAllMenus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetAllMenus_Result>("spGetAllMenus");
        }
    
        public virtual ObjectResult<spGetCompanyBranch_Result> spGetCompanyBranch()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetCompanyBranch_Result>("spGetCompanyBranch");
        }
    
        public virtual ObjectResult<spGetCompanyInfo_Result> spGetCompanyInfo(Nullable<long> bRANCH_ID)
        {
            var bRANCH_IDParameter = bRANCH_ID.HasValue ?
                new ObjectParameter("BRANCH_ID", bRANCH_ID) :
                new ObjectParameter("BRANCH_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetCompanyInfo_Result>("spGetCompanyInfo", bRANCH_IDParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> spGetCounterByIpAddress(string pCC_IP_ADDRESS)
        {
            var pCC_IP_ADDRESSParameter = pCC_IP_ADDRESS != null ?
                new ObjectParameter("PCC_IP_ADDRESS", pCC_IP_ADDRESS) :
                new ObjectParameter("PCC_IP_ADDRESS", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("spGetCounterByIpAddress", pCC_IP_ADDRESSParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> spGetDeveloperUserId()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("spGetDeveloperUserId");
        }
    
        public virtual ObjectResult<spGetFormRights_Result> spGetFormRights(Nullable<long> uSER_ID, string fORMNAME)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var fORMNAMEParameter = fORMNAME != null ?
                new ObjectParameter("FORMNAME", fORMNAME) :
                new ObjectParameter("FORMNAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetFormRights_Result>("spGetFormRights", uSER_IDParameter, fORMNAMEParameter);
        }
    
        public virtual ObjectResult<spGetLoginLevel_Result> spGetLoginLevel(Nullable<long> uSER_ID)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetLoginLevel_Result>("spGetLoginLevel", uSER_IDParameter);
        }
    
        public virtual int spGetMaxID(string cOLUMN_NAME, string tABLE_NAME)
        {
            var cOLUMN_NAMEParameter = cOLUMN_NAME != null ?
                new ObjectParameter("COLUMN_NAME", cOLUMN_NAME) :
                new ObjectParameter("COLUMN_NAME", typeof(string));
    
            var tABLE_NAMEParameter = tABLE_NAME != null ?
                new ObjectParameter("TABLE_NAME", tABLE_NAME) :
                new ObjectParameter("TABLE_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spGetMaxID", cOLUMN_NAMEParameter, tABLE_NAMEParameter);
        }
    
        public virtual ObjectResult<spGetPOSUser_Result> spGetPOSUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetPOSUser_Result>("spGetPOSUser");
        }
    
        public virtual ObjectResult<spGetUserMenuRights_Result> spGetUserMenuRights(Nullable<long> uSER_ID)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetUserMenuRights_Result>("spGetUserMenuRights", uSER_IDParameter);
        }
    
        public virtual int spInsertPOSUser(Nullable<long> uSER_ID, string pU_CODE, string pU_USERNAME, string pU_PASSWORD, string pU_EMAIL, Nullable<short> pU_ISACTIVE_FLAG, Nullable<short> pU_LOGIN_TYPE, string pU_MASTER_PASSWORD, Nullable<long> bRANCH_ID, Nullable<short> pU_ISPOSTED_FLAG, string cREATEDBY, Nullable<System.DateTime> cREATEDWHEN)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var pU_CODEParameter = pU_CODE != null ?
                new ObjectParameter("PU_CODE", pU_CODE) :
                new ObjectParameter("PU_CODE", typeof(string));
    
            var pU_USERNAMEParameter = pU_USERNAME != null ?
                new ObjectParameter("PU_USERNAME", pU_USERNAME) :
                new ObjectParameter("PU_USERNAME", typeof(string));
    
            var pU_PASSWORDParameter = pU_PASSWORD != null ?
                new ObjectParameter("PU_PASSWORD", pU_PASSWORD) :
                new ObjectParameter("PU_PASSWORD", typeof(string));
    
            var pU_EMAILParameter = pU_EMAIL != null ?
                new ObjectParameter("PU_EMAIL", pU_EMAIL) :
                new ObjectParameter("PU_EMAIL", typeof(string));
    
            var pU_ISACTIVE_FLAGParameter = pU_ISACTIVE_FLAG.HasValue ?
                new ObjectParameter("PU_ISACTIVE_FLAG", pU_ISACTIVE_FLAG) :
                new ObjectParameter("PU_ISACTIVE_FLAG", typeof(short));
    
            var pU_LOGIN_TYPEParameter = pU_LOGIN_TYPE.HasValue ?
                new ObjectParameter("PU_LOGIN_TYPE", pU_LOGIN_TYPE) :
                new ObjectParameter("PU_LOGIN_TYPE", typeof(short));
    
            var pU_MASTER_PASSWORDParameter = pU_MASTER_PASSWORD != null ?
                new ObjectParameter("PU_MASTER_PASSWORD", pU_MASTER_PASSWORD) :
                new ObjectParameter("PU_MASTER_PASSWORD", typeof(string));
    
            var bRANCH_IDParameter = bRANCH_ID.HasValue ?
                new ObjectParameter("BRANCH_ID", bRANCH_ID) :
                new ObjectParameter("BRANCH_ID", typeof(long));
    
            var pU_ISPOSTED_FLAGParameter = pU_ISPOSTED_FLAG.HasValue ?
                new ObjectParameter("PU_ISPOSTED_FLAG", pU_ISPOSTED_FLAG) :
                new ObjectParameter("PU_ISPOSTED_FLAG", typeof(short));
    
            var cREATEDBYParameter = cREATEDBY != null ?
                new ObjectParameter("CREATEDBY", cREATEDBY) :
                new ObjectParameter("CREATEDBY", typeof(string));
    
            var cREATEDWHENParameter = cREATEDWHEN.HasValue ?
                new ObjectParameter("CREATEDWHEN", cREATEDWHEN) :
                new ObjectParameter("CREATEDWHEN", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertPOSUser", uSER_IDParameter, pU_CODEParameter, pU_USERNAMEParameter, pU_PASSWORDParameter, pU_EMAILParameter, pU_ISACTIVE_FLAGParameter, pU_LOGIN_TYPEParameter, pU_MASTER_PASSWORDParameter, bRANCH_IDParameter, pU_ISPOSTED_FLAGParameter, cREATEDBYParameter, cREATEDWHENParameter);
        }
    
        public virtual int spInsertTransLog(Nullable<System.DateTime> pSTL_DATE, Nullable<int> pSTL_ACTIVITY_CODE, string pSTL_ACTIVITY_ON, Nullable<int> pSTL_UPDATER_ID, Nullable<System.DateTime> pSTL_UPDATER_DATETIME, string pSTL_REMARKS, string pSTL_ACTION, string pSTL_REFERENCE_NAME, string pSTL_REFERENCE_VALUES, string pSTL_FIELD_NAMES, string pSTL_FIELD_OLD_VALUES, string pSTL_FIELD_NEW_VALUES, string pSTL_UPDATE_PREVIOUS_DATETIME, string pSTL_CHANGES_IN)
        {
            var pSTL_DATEParameter = pSTL_DATE.HasValue ?
                new ObjectParameter("PSTL_DATE", pSTL_DATE) :
                new ObjectParameter("PSTL_DATE", typeof(System.DateTime));
    
            var pSTL_ACTIVITY_CODEParameter = pSTL_ACTIVITY_CODE.HasValue ?
                new ObjectParameter("PSTL_ACTIVITY_CODE", pSTL_ACTIVITY_CODE) :
                new ObjectParameter("PSTL_ACTIVITY_CODE", typeof(int));
    
            var pSTL_ACTIVITY_ONParameter = pSTL_ACTIVITY_ON != null ?
                new ObjectParameter("PSTL_ACTIVITY_ON", pSTL_ACTIVITY_ON) :
                new ObjectParameter("PSTL_ACTIVITY_ON", typeof(string));
    
            var pSTL_UPDATER_IDParameter = pSTL_UPDATER_ID.HasValue ?
                new ObjectParameter("PSTL_UPDATER_ID", pSTL_UPDATER_ID) :
                new ObjectParameter("PSTL_UPDATER_ID", typeof(int));
    
            var pSTL_UPDATER_DATETIMEParameter = pSTL_UPDATER_DATETIME.HasValue ?
                new ObjectParameter("PSTL_UPDATER_DATETIME", pSTL_UPDATER_DATETIME) :
                new ObjectParameter("PSTL_UPDATER_DATETIME", typeof(System.DateTime));
    
            var pSTL_REMARKSParameter = pSTL_REMARKS != null ?
                new ObjectParameter("PSTL_REMARKS", pSTL_REMARKS) :
                new ObjectParameter("PSTL_REMARKS", typeof(string));
    
            var pSTL_ACTIONParameter = pSTL_ACTION != null ?
                new ObjectParameter("PSTL_ACTION", pSTL_ACTION) :
                new ObjectParameter("PSTL_ACTION", typeof(string));
    
            var pSTL_REFERENCE_NAMEParameter = pSTL_REFERENCE_NAME != null ?
                new ObjectParameter("PSTL_REFERENCE_NAME", pSTL_REFERENCE_NAME) :
                new ObjectParameter("PSTL_REFERENCE_NAME", typeof(string));
    
            var pSTL_REFERENCE_VALUESParameter = pSTL_REFERENCE_VALUES != null ?
                new ObjectParameter("PSTL_REFERENCE_VALUES", pSTL_REFERENCE_VALUES) :
                new ObjectParameter("PSTL_REFERENCE_VALUES", typeof(string));
    
            var pSTL_FIELD_NAMESParameter = pSTL_FIELD_NAMES != null ?
                new ObjectParameter("PSTL_FIELD_NAMES", pSTL_FIELD_NAMES) :
                new ObjectParameter("PSTL_FIELD_NAMES", typeof(string));
    
            var pSTL_FIELD_OLD_VALUESParameter = pSTL_FIELD_OLD_VALUES != null ?
                new ObjectParameter("PSTL_FIELD_OLD_VALUES", pSTL_FIELD_OLD_VALUES) :
                new ObjectParameter("PSTL_FIELD_OLD_VALUES", typeof(string));
    
            var pSTL_FIELD_NEW_VALUESParameter = pSTL_FIELD_NEW_VALUES != null ?
                new ObjectParameter("PSTL_FIELD_NEW_VALUES", pSTL_FIELD_NEW_VALUES) :
                new ObjectParameter("PSTL_FIELD_NEW_VALUES", typeof(string));
    
            var pSTL_UPDATE_PREVIOUS_DATETIMEParameter = pSTL_UPDATE_PREVIOUS_DATETIME != null ?
                new ObjectParameter("PSTL_UPDATE_PREVIOUS_DATETIME", pSTL_UPDATE_PREVIOUS_DATETIME) :
                new ObjectParameter("PSTL_UPDATE_PREVIOUS_DATETIME", typeof(string));
    
            var pSTL_CHANGES_INParameter = pSTL_CHANGES_IN != null ?
                new ObjectParameter("PSTL_CHANGES_IN", pSTL_CHANGES_IN) :
                new ObjectParameter("PSTL_CHANGES_IN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertTransLog", pSTL_DATEParameter, pSTL_ACTIVITY_CODEParameter, pSTL_ACTIVITY_ONParameter, pSTL_UPDATER_IDParameter, pSTL_UPDATER_DATETIMEParameter, pSTL_REMARKSParameter, pSTL_ACTIONParameter, pSTL_REFERENCE_NAMEParameter, pSTL_REFERENCE_VALUESParameter, pSTL_FIELD_NAMESParameter, pSTL_FIELD_OLD_VALUESParameter, pSTL_FIELD_NEW_VALUESParameter, pSTL_UPDATE_PREVIOUS_DATETIMEParameter, pSTL_CHANGES_INParameter);
        }
    
        public virtual int spInsertUserSession(Nullable<long> uSER_ID, Nullable<System.DateTime> lOGIN_DATETIME, Nullable<bool> pUS_ISSUCCESS_LOGIN_FLAG, string pUS_IP_ADDRESS, Nullable<bool> pUS_ISSUCCESS_LOGOUT_FLAG, Nullable<long> cOUNTER_ID)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var lOGIN_DATETIMEParameter = lOGIN_DATETIME.HasValue ?
                new ObjectParameter("LOGIN_DATETIME", lOGIN_DATETIME) :
                new ObjectParameter("LOGIN_DATETIME", typeof(System.DateTime));
    
            var pUS_ISSUCCESS_LOGIN_FLAGParameter = pUS_ISSUCCESS_LOGIN_FLAG.HasValue ?
                new ObjectParameter("PUS_ISSUCCESS_LOGIN_FLAG", pUS_ISSUCCESS_LOGIN_FLAG) :
                new ObjectParameter("PUS_ISSUCCESS_LOGIN_FLAG", typeof(bool));
    
            var pUS_IP_ADDRESSParameter = pUS_IP_ADDRESS != null ?
                new ObjectParameter("PUS_IP_ADDRESS", pUS_IP_ADDRESS) :
                new ObjectParameter("PUS_IP_ADDRESS", typeof(string));
    
            var pUS_ISSUCCESS_LOGOUT_FLAGParameter = pUS_ISSUCCESS_LOGOUT_FLAG.HasValue ?
                new ObjectParameter("PUS_ISSUCCESS_LOGOUT_FLAG", pUS_ISSUCCESS_LOGOUT_FLAG) :
                new ObjectParameter("PUS_ISSUCCESS_LOGOUT_FLAG", typeof(bool));
    
            var cOUNTER_IDParameter = cOUNTER_ID.HasValue ?
                new ObjectParameter("COUNTER_ID", cOUNTER_ID) :
                new ObjectParameter("COUNTER_ID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertUserSession", uSER_IDParameter, lOGIN_DATETIMEParameter, pUS_ISSUCCESS_LOGIN_FLAGParameter, pUS_IP_ADDRESSParameter, pUS_ISSUCCESS_LOGOUT_FLAGParameter, cOUNTER_IDParameter);
        }
    
        public virtual int spIsActiveUser(Nullable<long> uSER_ID, Nullable<short> pU_ISACTIVE_FLAG)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var pU_ISACTIVE_FLAGParameter = pU_ISACTIVE_FLAG.HasValue ?
                new ObjectParameter("PU_ISACTIVE_FLAG", pU_ISACTIVE_FLAG) :
                new ObjectParameter("PU_ISACTIVE_FLAG", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spIsActiveUser", uSER_IDParameter, pU_ISACTIVE_FLAGParameter);
        }
    
        public virtual int spSysExceptionLog(string pEL_EXCEPTION_LAYER, string pEL_SOURCE_LAYER, string pEL_STACKTRACE, string pEL_ERROR_MESSAGE, string pEL_MEMBER_TYPE, string pEL_METHOD, string pEL_FORM, Nullable<System.DateTime> pEL_EXCEPTION_DATETIME, string pEL_CLIENT_IP, string pEL_EXCEPTION_TYPE)
        {
            var pEL_EXCEPTION_LAYERParameter = pEL_EXCEPTION_LAYER != null ?
                new ObjectParameter("PEL_EXCEPTION_LAYER", pEL_EXCEPTION_LAYER) :
                new ObjectParameter("PEL_EXCEPTION_LAYER", typeof(string));
    
            var pEL_SOURCE_LAYERParameter = pEL_SOURCE_LAYER != null ?
                new ObjectParameter("PEL_SOURCE_LAYER", pEL_SOURCE_LAYER) :
                new ObjectParameter("PEL_SOURCE_LAYER", typeof(string));
    
            var pEL_STACKTRACEParameter = pEL_STACKTRACE != null ?
                new ObjectParameter("PEL_STACKTRACE", pEL_STACKTRACE) :
                new ObjectParameter("PEL_STACKTRACE", typeof(string));
    
            var pEL_ERROR_MESSAGEParameter = pEL_ERROR_MESSAGE != null ?
                new ObjectParameter("PEL_ERROR_MESSAGE", pEL_ERROR_MESSAGE) :
                new ObjectParameter("PEL_ERROR_MESSAGE", typeof(string));
    
            var pEL_MEMBER_TYPEParameter = pEL_MEMBER_TYPE != null ?
                new ObjectParameter("PEL_MEMBER_TYPE", pEL_MEMBER_TYPE) :
                new ObjectParameter("PEL_MEMBER_TYPE", typeof(string));
    
            var pEL_METHODParameter = pEL_METHOD != null ?
                new ObjectParameter("PEL_METHOD", pEL_METHOD) :
                new ObjectParameter("PEL_METHOD", typeof(string));
    
            var pEL_FORMParameter = pEL_FORM != null ?
                new ObjectParameter("PEL_FORM", pEL_FORM) :
                new ObjectParameter("PEL_FORM", typeof(string));
    
            var pEL_EXCEPTION_DATETIMEParameter = pEL_EXCEPTION_DATETIME.HasValue ?
                new ObjectParameter("PEL_EXCEPTION_DATETIME", pEL_EXCEPTION_DATETIME) :
                new ObjectParameter("PEL_EXCEPTION_DATETIME", typeof(System.DateTime));
    
            var pEL_CLIENT_IPParameter = pEL_CLIENT_IP != null ?
                new ObjectParameter("PEL_CLIENT_IP", pEL_CLIENT_IP) :
                new ObjectParameter("PEL_CLIENT_IP", typeof(string));
    
            var pEL_EXCEPTION_TYPEParameter = pEL_EXCEPTION_TYPE != null ?
                new ObjectParameter("PEL_EXCEPTION_TYPE", pEL_EXCEPTION_TYPE) :
                new ObjectParameter("PEL_EXCEPTION_TYPE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSysExceptionLog", pEL_EXCEPTION_LAYERParameter, pEL_SOURCE_LAYERParameter, pEL_STACKTRACEParameter, pEL_ERROR_MESSAGEParameter, pEL_MEMBER_TYPEParameter, pEL_METHODParameter, pEL_FORMParameter, pEL_EXCEPTION_DATETIMEParameter, pEL_CLIENT_IPParameter, pEL_EXCEPTION_TYPEParameter);
        }
    
        public virtual int spTruncateDeveloperTable()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spTruncateDeveloperTable");
        }
    
        public virtual int spUpdateCurrentLogOutSession(Nullable<long> uSER_ID, Nullable<long> dEVELOPER_USER_ID, Nullable<int> lOGOUT_FLAG)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var dEVELOPER_USER_IDParameter = dEVELOPER_USER_ID.HasValue ?
                new ObjectParameter("DEVELOPER_USER_ID", dEVELOPER_USER_ID) :
                new ObjectParameter("DEVELOPER_USER_ID", typeof(long));
    
            var lOGOUT_FLAGParameter = lOGOUT_FLAG.HasValue ?
                new ObjectParameter("LOGOUT_FLAG", lOGOUT_FLAG) :
                new ObjectParameter("LOGOUT_FLAG", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateCurrentLogOutSession", uSER_IDParameter, dEVELOPER_USER_IDParameter, lOGOUT_FLAGParameter);
        }
    
        public virtual int spUpdatePOSUser(Nullable<long> uSER_ID, string pU_USERNAME, string pU_PASSWORD, string pU_EMAIL, Nullable<short> pU_ISACTIVE_FLAG, Nullable<short> pU_LOGIN_TYPE, string pU_MASTER_PASSWORD, Nullable<long> bRANCH_ID, Nullable<short> pU_ISPOSTED_FLAG, string mODIFIEDBY, Nullable<System.DateTime> mODIFIEDWHEN)
        {
            var uSER_IDParameter = uSER_ID.HasValue ?
                new ObjectParameter("USER_ID", uSER_ID) :
                new ObjectParameter("USER_ID", typeof(long));
    
            var pU_USERNAMEParameter = pU_USERNAME != null ?
                new ObjectParameter("PU_USERNAME", pU_USERNAME) :
                new ObjectParameter("PU_USERNAME", typeof(string));
    
            var pU_PASSWORDParameter = pU_PASSWORD != null ?
                new ObjectParameter("PU_PASSWORD", pU_PASSWORD) :
                new ObjectParameter("PU_PASSWORD", typeof(string));
    
            var pU_EMAILParameter = pU_EMAIL != null ?
                new ObjectParameter("PU_EMAIL", pU_EMAIL) :
                new ObjectParameter("PU_EMAIL", typeof(string));
    
            var pU_ISACTIVE_FLAGParameter = pU_ISACTIVE_FLAG.HasValue ?
                new ObjectParameter("PU_ISACTIVE_FLAG", pU_ISACTIVE_FLAG) :
                new ObjectParameter("PU_ISACTIVE_FLAG", typeof(short));
    
            var pU_LOGIN_TYPEParameter = pU_LOGIN_TYPE.HasValue ?
                new ObjectParameter("PU_LOGIN_TYPE", pU_LOGIN_TYPE) :
                new ObjectParameter("PU_LOGIN_TYPE", typeof(short));
    
            var pU_MASTER_PASSWORDParameter = pU_MASTER_PASSWORD != null ?
                new ObjectParameter("PU_MASTER_PASSWORD", pU_MASTER_PASSWORD) :
                new ObjectParameter("PU_MASTER_PASSWORD", typeof(string));
    
            var bRANCH_IDParameter = bRANCH_ID.HasValue ?
                new ObjectParameter("BRANCH_ID", bRANCH_ID) :
                new ObjectParameter("BRANCH_ID", typeof(long));
    
            var pU_ISPOSTED_FLAGParameter = pU_ISPOSTED_FLAG.HasValue ?
                new ObjectParameter("PU_ISPOSTED_FLAG", pU_ISPOSTED_FLAG) :
                new ObjectParameter("PU_ISPOSTED_FLAG", typeof(short));
    
            var mODIFIEDBYParameter = mODIFIEDBY != null ?
                new ObjectParameter("MODIFIEDBY", mODIFIEDBY) :
                new ObjectParameter("MODIFIEDBY", typeof(string));
    
            var mODIFIEDWHENParameter = mODIFIEDWHEN.HasValue ?
                new ObjectParameter("MODIFIEDWHEN", mODIFIEDWHEN) :
                new ObjectParameter("MODIFIEDWHEN", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdatePOSUser", uSER_IDParameter, pU_USERNAMEParameter, pU_PASSWORDParameter, pU_EMAILParameter, pU_ISACTIVE_FLAGParameter, pU_LOGIN_TYPEParameter, pU_MASTER_PASSWORDParameter, bRANCH_IDParameter, pU_ISPOSTED_FLAGParameter, mODIFIEDBYParameter, mODIFIEDWHENParameter);
        }
    
        public virtual int spUserSessionCashierCounter(Nullable<bool> isMultipleCashierCounter)
        {
            var isMultipleCashierCounterParameter = isMultipleCashierCounter.HasValue ?
                new ObjectParameter("IsMultipleCashierCounter", isMultipleCashierCounter) :
                new ObjectParameter("IsMultipleCashierCounter", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUserSessionCashierCounter", isMultipleCashierCounterParameter);
        }
    
        public virtual int spValidateMasterUser(string pU_USERNAME, string pU_MASTER_PASSWORD)
        {
            var pU_USERNAMEParameter = pU_USERNAME != null ?
                new ObjectParameter("PU_USERNAME", pU_USERNAME) :
                new ObjectParameter("PU_USERNAME", typeof(string));
    
            var pU_MASTER_PASSWORDParameter = pU_MASTER_PASSWORD != null ?
                new ObjectParameter("PU_MASTER_PASSWORD", pU_MASTER_PASSWORD) :
                new ObjectParameter("PU_MASTER_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spValidateMasterUser", pU_USERNAMEParameter, pU_MASTER_PASSWORDParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> spValidateUser(string pU_USERNAME, string pU_PASSWORD, string pU_MASTER_PASSWORD)
        {
            var pU_USERNAMEParameter = pU_USERNAME != null ?
                new ObjectParameter("PU_USERNAME", pU_USERNAME) :
                new ObjectParameter("PU_USERNAME", typeof(string));
    
            var pU_PASSWORDParameter = pU_PASSWORD != null ?
                new ObjectParameter("PU_PASSWORD", pU_PASSWORD) :
                new ObjectParameter("PU_PASSWORD", typeof(string));
    
            var pU_MASTER_PASSWORDParameter = pU_MASTER_PASSWORD != null ?
                new ObjectParameter("PU_MASTER_PASSWORD", pU_MASTER_PASSWORD) :
                new ObjectParameter("PU_MASTER_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("spValidateUser", pU_USERNAMEParameter, pU_PASSWORDParameter, pU_MASTER_PASSWORDParameter);
        }
    }
}
