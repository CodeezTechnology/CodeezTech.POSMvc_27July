using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class DBAutoUpdater : DBEngine
    {
        public void DBUpdater()
        {
            try
            {
                #region Database Schema
                if (DBConfigHelper.Provider == DatabaseProviderType.Sql)
                {
                    #region SQL
                    MstrQuery = "spDBAutoUpdator";
                    ExecuteNonQuery();
                    #endregion
                }
                else if (DBConfigHelper.Provider == DatabaseProviderType.Oracle)
                {
                    #region ORACLE
                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_ACCESS_GROUP') THEN
                                    CREATE TABLE POS_ACCESS_GROUP(
	                                    ACCESS_GROUP_ID Number(19) NOT NULL,
	                                    PAG_CODE Varchar2(10) NOT NULL,
	                                    PAG_DESC Varchar2(200) NOT NULL,
	                                    PAG_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PAG_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                        CONSTRAINT PK_POS_ACCESS_GROUP PRIMARY KEY 
                                    (
	                                    ACCESS_GROUP_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_ACCOUNTS_LEVEL-I') THEN
                                        CREATE TABLE POS_ACCOUNTS_LEVEL-I(
	                                    ACCOUNT_ID Number(19) NOT NULL,
	                                    PA_ACCOUNT_NO Varchar2(20) NOT NULL,
	                                    PA_DESC Varchar2(100) NOT NULL,
	                                    PA_ACCOUNT_TYPE Varchar2(50) NOT NULL,
	                                    PA_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PA_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_ACCOUNTS_LEVEL-I PRIMARY KEY 
                                    (
	                                    ACCOUNT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_ACCOUNTS_LEVEL-II') THEN
                                        CREATE TABLE POS_ACCOUNTS_LEVEL-II(
	                                    ACCOUNT_LEVEL_TWO_ID Number(19) NOT NULL,
	                                    PALII_ACCOUNT_NO Varchar2(20) NOT NULL,
	                                    PAII_DESC Varchar2(100) NOT NULL,
	                                    PAII_ACCOUNT_TYPE Varchar2(50) NOT NULL,
	                                    ACCOUNT_ID Number(19) NOT NULL,
	                                    PAII_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PAII_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_ACCOUNT_LEVEL-II PRIMARY KEY 
                                    (
	                                    ACCOUNT_LEVEL_TWO_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_ACCOUNTS_LEVEL-III') THEN
                                        CREATE TABLE POS_ACCOUNTS_LEVEL-III(
	                                    ACCOUNT_LEVEL_THREE_ID Number(19) NOT NULL,
	                                    PALIII_ACCOUNT_NO Varchar2(20) NOT NULL,
	                                    PAIII_DESC Varchar2(100) NOT NULL,
	                                    PAIII_ACCOUNT_TYPE Varchar2(50) NOT NULL,
	                                    ACCOUNT_LEVEL_TWO_ID Number(19) NOT NULL,
	                                    PAIII_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PAIII_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                        CONSTRAINT PK_POS_ACCOUNT_LEVEL-III PRIMARY KEY 
                                    (
	                                    ACCOUNT_LEVEL_THREE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_BANK') THEN
                                        CREATE TABLE POS_BANK(
	                                    BANK_ID Number(19) NOT NULL,
	                                    PB_CODE Varchar2(15) NOT NULL,
	                                    PB_DESC Varchar2(50) NOT NULL,
	                                    PB_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PB_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_BANK PRIMARY KEY 
                                    (
	                                    BANK_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_BANK_BRANCH') THEN
                                        CREATE TABLE POS_BANK_BRANCH(
	                                    BANK_BRANCH_ID Number(19) NOT NULL,
	                                    PBB_CODE Varchar2(15) NOT NULL,
	                                    PBB_DESC Varchar2(50) NOT NULL,
	                                    PBB_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PBB_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_BANK_BRANCH PRIMARY KEY 
                                    (
	                                    BANK_BRANCH_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_BUTTON_RIGHTS') THEN
                                        CREATE TABLE POS_BUTTON_RIGHTS(
	                                    BUTTON_RIGHTS_ID Number(19) NOT NULL,
	                                    USER_ID Number(19) NOT NULL,
	                                    MENU_ID Number(19) NOT NULL,
	                                    MENU_RIGHTS_ID Number(19) NOT NULL,
	                                    PBR_BUTTON_ID Number(5) NOT NULL,
	                                    PBR_BUTTONS Varchar2(50) NOT NULL,
	                                    PBR_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PBR_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_BUTTON_RIGHTS PRIMARY KEY 
                                    (
	                                    BUTTON_RIGHTS_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_CASHIER_COUNTER') THEN
                                        CREATE TABLE POS_CASHIER_COUNTER(
	                                    CASHIER_SESSION_ID Number(19) NOT NULL,
	                                    PCS_DATE date NOT NULL,
	                                    USER_ID Number(19) NOT NULL,
	                                    COUNTER_ID Number(19) NOT NULL,
	                                    PCS_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PCS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_CASHIER_COUNTER PRIMARY KEY 
                                    (
	                                    CASHIER_SESSION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_CITY') THEN
                                        CREATE TABLE POS_CITY(
	                                    CITY_ID Number(19) NOT NULL,
	                                    PCI_CODE Varchar2(15) NOT NULL,
	                                    PCI_DESC Varchar2(50) NOT NULL,
	                                    PCI_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PCI_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_CITY PRIMARY KEY 
                                    (
	                                    CITY_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_COMPANY') THEN
                                        CREATE TABLE POS_COMPANY(
	                                    COMPANY_ID Number(19) NOT NULL,
	                                    PC_COMPANY_CODE Varchar2(20) NOT NULL,
	                                    PC_DESC Varchar2(100) NOT NULL,
	                                    PC_LOGO_PATH Varchar2(100) NOT NULL,
	                                    PC_MOBILE Varchar2(20) NOT NULL,
	                                    PC_TELEPHONE Varchar2(20) NOT NULL,
	                                    PC_EMAIL Varchar2(50) NOT NULL,
	                                    PC_ADDRESS Nvarchar2(500) NOT NULL,
	                                    PC_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PC_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_COMPANY PRIMARY KEY 
                                    (
	                                    COMPANY_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_COUNTER') THEN
                                        CREATE TABLE POS_COUNTER(
	                                    COUNTER_ID Number(19) NOT NULL,
	                                    PCO_DESC Varchar2(100) NULL,
	                                    PCO_NAME nchar(10) NOT NULL,
	                                    PCO_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PCO_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_COUNTER PRIMARY KEY 
                                    (
	                                    COUNTER_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_COUNTRY') THEN
                                        CREATE TABLE POS_COUNTRY(
	                                    COUNTRY_ID Number(19) NOT NULL,
	                                    PCO_CODE Varchar2(15) NOT NULL,
	                                    PCO_DESC Varchar2(50) NOT NULL,
	                                    PCO_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PCO_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_COUNTRY PRIMARY KEY 
                                    (
	                                    COUNTRY_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_CUSTOMER_DETAIL') THEN
                                        CREATE TABLE POS_CUSTOMER_DETAIL(
	                                    CUSTOMER_ID Number(19) NOT NULL,
	                                    PCD_CUSTOMER_NAME Varchar2(50) NULL,
	                                    PCD_CONTACT Varchar2(15) NULL,
	                                    PCD_EMAIL Varchar2(50) NULL,
	                                    ADDRESS Varchar2(50) NULL,
	                                    PCD_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_CUSTOMER PRIMARY KEY 
                                    (
	                                    CUSTOMER_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();


                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_CUSTOMER_PROMOTIONS') THEN
                                        CREATE TABLE POS_CUSTOMER_PROMOTIONS(
	                                    CUSTOMER_PROMOTION_ID Number(19) NOT NULL,
	                                    PROMOTION_ID Number(19) NOT NULL,
	                                    SALE_ID Number(19) NOT NULL,
	                                    PCP_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_CUSTOMER_PROMOTIONS PRIMARY KEY 
                                    (
	                                    CUSTOMER_PROMOTION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_DISPLAY_FLOORS') THEN
                                        CREATE TABLE POS_DISPLAY_FLOORS(
	                                    DISPLAY_FLOOR_ID Number(19) NOT NULL,
	                                    PDF_CODE nchar(10) NOT NULL,
	                                    PDF_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PDF_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    PDF_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_DISPLAY_FLOORS PRIMARY KEY 
                                    (
	                                    DISPLAY_FLOOR_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_DISPLAY_INVENTORY_TRACKING') THEN
                                        CREATE TABLE POS_DISPLAY_INVENTORY_TRACKING(
	                                    DISPLAY_ITRACKING_ID Number(19) NOT NULL,
	                                    DISPLAY_FLOOR_ID Number(19) NOT NULL,
	                                    DISPLAY_SECTION_ID Number(19) NOT NULL,
	                                    DISPLAY_RAG_ID Number(19) NULL,
	                                    DISPLAY_RAG_FLOOR_ID Number(19) NULL,
	                                    PDIT_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_DISPLAY_INVENTORY_TRACKING PRIMARY KEY 
                                    (
	                                    DISPLAY_ITRACKING_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_DISPLAY_RAGS') THEN
                                        CREATE TABLE POS_DISPLAY_RAGS(
	                                    DISPLAY_RAG_ID Number(19) NOT NULL,
	                                    PDR_CODE nchar(10) NOT NULL,
	                                    PDR_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PDR_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    PDR_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_DISPLAY_RAGS PRIMARY KEY 
                                    (
	                                    DISPLAY_RAG_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_DISPLAY_RAGS_FLOOR') THEN
                                        CREATE TABLE POS_DISPLAY_RAGS_FLOOR(
	                                    DISPLAY_RAG_FLOOR_ID Number(19) NOT NULL,
	                                    PDRF_CODE nchar(10) NOT NULL,
	                                    PDRF_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PDRF_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PDRF_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_DISPLAY_RAGS_FLOOR PRIMARY KEY 
                                    (
	                                    DISPLAY_RAG_FLOOR_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_DISPLAY_SECTIONS') THEN
                                        CREATE TABLE POS_DISPLAY_SECTIONS(
	                                    DISPLAY_SECTION_ID Number(19) NOT NULL,
	                                    PDSE_CODE nchar(10) NOT NULL,
	                                    PDSE_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PDSE_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PDSE_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_DISPLAY_SECTIONS PRIMARY KEY 
                                    (
	                                    DISPLAY_SECTION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_DISPLAY_STOCK') THEN
                                        CREATE TABLE POS_DISPLAY_STOCK(
	                                    DSTOCK_ID Number(19) NOT NULL,
	                                    PDS_DATE date NOT NULL,
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    PDS_QUANTITY_IN Number(10) NOT NULL,
	                                    PDS_QUANTITY_OUT Number(10) NOT NULL,
	                                    PDS_STOCK_TYPE Varchar2(20) NOT NULL,
	                                    PDS_UNIT_PRICE Number(18, 0) NOT NULL,
	                                    PDS_TOTAL_PRICE Number(18, 0) NOT NULL,
	                                    VW_SHIPPMENT_ID Number(19) NOT NULL,
	                                    PDS_SHIPPMENT_FROM Varchar2(50) NOT NULL,
	                                    WSTOCK_ID Number(19) NULL,
	                                    SALE_ID Number(19) NOT NULL,
	                                    PDS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_DISPLAY_STOCK PRIMARY KEY 
                                    (
	                                    DSTOCK_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_EMPLOYEE_TYPE') THEN
                                        CREATE TABLE POS_EMPLOYEE_TYPE(
	                                    EMPLOYEE_TYPE_ID Number(19) NOT NULL,
	                                    PET_CODE Varchar2(10) NOT NULL,
	                                    PET_DESC Varchar2(200) NOT NULL,
	                                    PET_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PET_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_EMPLOYEE_TYPE PRIMARY KEY 
                                    (
	                                    EMPLOYEE_TYPE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_GENDER') THEN
                                        CREATE TABLE POS_GENDER(
	                                    GENDER_ID Number(19) NOT NULL,
	                                    PG_CODE Varchar2(10) NOT NULL,
	                                    PG_DESC Varchar2(50) NOT NULL,
	                                    PG_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PG_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_GENDER PRIMARY KEY 
                                    (
	                                    GENDER_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_GENERAL_LEDGER') THEN
                                        CREATE TABLE POS_GENERAL_LEDGER(
	                                    LEDGER_ID Number(19) NOT NULL,
	                                    ACCOUNT_LEVEL_THREE_ID Number(19) NOT NULL,
	                                    PGL_DATE date NOT NULL,
	                                    PGL_POST_REF Varchar2(15) NOT NULL,
	                                    INVOICE_ID Varchar2(20) NOT NULL,
	                                    PGL_JOURNAL_REF Varchar2(3) NULL,
	                                    PGL_DEBIT Number(18, 0) NOT NULL,
	                                    PGL_CREDIT Number(18, 0) NULL,
	                                    PGL_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_GENERAL_LEDGER PRIMARY KEY 
                                    (
	                                    LEDGER_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_INVOICE') THEN
                                        CREATE TABLE POS_INVOICE(
	                                    INVOICE_ID Number(19) NOT NULL,
	                                    PURCHASE_ORDER_ID Number(19) NOT NULL,
	                                    PI_AMOUNT Number(18, 0) NOT NULL,
	                                    PI_DESC Varchar2(50) NOT NULL,
	                                    PI_PAYMENT_DATE date NOT NULL,
	                                    PI_EVIDENCE Raw(100) NULL,
	                                    PI_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PI_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_INVOICE PRIMARY KEY 
                                    (
	                                    INVOICE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_LOCATION') THEN
                                        CREATE TABLE POS_LOCATION(
	                                    LOCATION_ID Number(19) NOT NULL,
	                                    PL_CODE Varchar2(10) NOT NULL,
	                                    PL_DESC Varchar2(200) NOT NULL,
	                                    PL_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PL_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_LOCATION PRIMARY KEY 
                                    (
	                                    LOCATION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_MENU') THEN
                                        CREATE TABLE POS_MENU(
	                                    MENU_ID Number(19) NOT NULL,
	                                    PM_DESC Varchar2(100) NOT NULL,
	                                    PM_NAME Varchar2(100) NOT NULL,
	                                    PM_ILEVEL Number(5) NOT NULL,
	                                    PM_MASTER_MENU_ID Number(5) NOT NULL,
	                                    SYS_APP_MODULE_ID Number(19) NULL,
	                                    PM_ICON_PATH [nvarchar](max) NOT NULL,
	                                    PM_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PM_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_MENU PRIMARY KEY 
                                    (
	                                    MENU_ID 
                                    ) 
                                    );
                    END IF; TEXTIMAGE_ON PRIMARY";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_MENU_RIGHTS') THEN
                                        CREATE TABLE POS_MENU_RIGHTS(
	                                    MENU_RIGHTS_ID Number(19) NOT NULL,
	                                    USER_ID Number(19) NOT NULL,
	                                    MENU_ID Number(19) NOT NULL,
	                                    PMR_SCREEN_NAME Varchar2(100) NOT NULL,
	                                    PMR_SCREEN_DESCRIPTION Varchar2(200) NULL,
	                                    PMR_ISACTIVE_FLAG Number(5) NULL,
	                                    PMR_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_RIGHTS PRIMARY KEY 
                                    (
	                                    MENU_RIGHTS_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PAYMENT_DETAIL') THEN
                                        CREATE TABLE POS_PAYMENT_DETAIL(
	                                    PAYMENT_ID Number(19) NOT NULL,
	                                    PPD_CODE Varchar2(15) NOT NULL,
	                                    PPD_DESC Varchar2(50) NOT NULL,
	                                    BANK_ID Number(19) NOT NULL,
	                                    BANK_BRANCH_ID Number(19) NOT NULL,
	                                    PPD_ACCOUNT_NO Varchar2(50) NOT NULL,
	                                    PPD_ACCOUNT_DESC Varchar2(50) NOT NULL,
	                                    PAYMENT_TYPE_ID Number(19) NOT NULL,
	                                    PPD_TRANSACTION_NO Number(10) NOT NULL,
	                                    PPD_DATE date NOT NULL,
	                                    PURCHASE_ORDER_ID Number(19) NOT NULL,
	                                    PPD_AMOUNT Number(18, 0) NOT NULL,
	                                    PPD_AMOUNT_IN_WORDS Varchar2(300) NULL,
	                                    PPD_ISTAXABLE_FLAG Number(5) NOT NULL,
	                                    PPD_ISCASH_TRANSFERRED Number(5) NOT NULL,
	                                    PPD_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    PPD_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_PAYMENT_DETAIL PRIMARY KEY 
                                    (
	                                    PAYMENT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PAYMENT_TYPE') THEN
                                        CREATE TABLE POS_PAYMENT_TYPE(
	                                    PAYMENT_TYPE_ID Number(19) NOT NULL,
	                                    PPTY_CODE Varchar2(15) NOT NULL,
	                                    PPTY_PAYMENT_METHOD Varchar2(50) NOT NULL,
	                                    PPTY_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PPTY_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_PAYMENT_TYPE PRIMARY KEY 
                                    (
	                                    PAYMENT_TYPE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PRODUCT') THEN
                                        CREATE TABLE POS_PRODUCT(
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    PP_PRODUCT_CODE Varchar2(20) NOT NULL,
	                                    PP_PRODUCT_DESC Varchar2(100) NOT NULL,
	                                    PP_PROFIT_MARGIN_RATE Number(19) NOT NULL,
	                                    PP_PAYBLE_PRICE Number(18, 0) NOT NULL,
	                                    PP_IS_TAX_APPLIED_FLAG Number(5) NOT NULL,
	                                    PP_TAX_PER Number(10) NULL,
	                                    PP_TAX_RS Number(18, 0) NULL,
	                                    TYPE_ID Number(19) NOT NULL,
	                                    CATEGORY_ID Number(19) NOT NULL,
	                                    UNIT_ID Number(19) NOT NULL,
	                                    PP_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PP_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_PRODUCT PRIMARY KEY 
                                    (
	                                    PRODUCT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PRODUCT_CATEGORY') THEN
                                        CREATE TABLE POS_PRODUCT_CATEGORY(
	                                    CATEGORY_ID Number(19) NOT NULL,
	                                    CATOEGORY_CODE Varchar2(20) NULL,
	                                    PPC_PRODUCT_CATEGORY Varchar2(100) NOT NULL,
	                                    PPC_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PPC_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_PRODUCT_CATEGORY PRIMARY KEY 
                                    (
	                                    CATEGORY_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PRODUCT_PROMOTIONS') THEN
                                        CREATE TABLE POS_PRODUCT_PROMOTIONS(
	                                    PROMOTION_PRODUCT_ID Number(19) NOT NULL,
	                                    PROMOTION_ID Number(19) NOT NULL,
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    PPP_QUANTITY Number(10) NOT NULL,
	                                    PPP_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_PRODUCT_PROMOTIONS PRIMARY KEY 
                                    (
	                                    PROMOTION_PRODUCT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PRODUCT_TYPE') THEN
                                        CREATE TABLE POS_PRODUCT_TYPE(
	                                    TYPE_ID Number(19) NOT NULL,
	                                    TYPE_CODE Varchar2(20) NOT NULL,
	                                    PPT_PRODUCT_TYPE Varchar2(100) NOT NULL,
	                                    PPT_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PPT_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_PRODUCT_TYPE PRIMARY KEY 
                                    (
	                                    TYPE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PROMOTION_DETAIL') THEN
                                        CREATE TABLE POS_PROMOTION_DETAIL(
	                                    PROMOTION_DETAIL_ID Number(19) NOT NULL,
	                                    PROMOTION_ID Number(19) NOT NULL,
	                                    PPD_DISCOUNT_PER Number(10) NULL,
	                                    PPD_DISCOUNT_AMOUNT Number(10) NULL,
	                                    PPD_IS_CONDITIONAL_FLAG Number(5) NOT NULL,
	                                    PPD_CONDITIONAL_AMOUNT Number(18, 0) NULL,
	                                    PPD_IS_PRODUCT_BASE_FLAG Number(5) NOT NULL,
	                                    PPD_IS_LUCKYDRAW_FLAG Number(5) NOT NULL,
	                                    PPD_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_PROMOTION_DETAIL PRIMARY KEY 
                                    (
	                                    PROMOTION_DETAIL_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PROMOTIONS') THEN
                                        CREATE TABLE POS_PROMOTIONS(
	                                    PROMOTION_ID Number(19) NOT NULL,
	                                    PPR_CODE Varchar2(15) NOT NULL,
	                                    PPR_TITLE Varchar2(150) NOT NULL,
	                                    PPR_DESCRIPTION Varchar2(150) NOT NULL,
	                                    PPR_DATE_FROM date NOT NULL,
	                                    PPR_DATE_TO date NOT NULL,
	                                    PPR_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PPR_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_PROMOTIONS PRIMARY KEY 
                                    (
	                                    PROMOTION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PURCHASE_ORDER') THEN
                                        CREATE TABLE POS_PURCHASE_ORDER(
	                                    PURCHASE_ORDER_ID Number(19) NOT NULL,
	                                    PPO_SHIPPMENT_ID date NOT NULL,
	                                    PPO_QUANTITY Number(10) NOT NULL,
	                                    PPO_NET_AMOUNT Number(18, 0) NOT NULL,
	                                    PPO_CASH_RELEASE Number(18, 0) NOT NULL,
	                                    VENDOR_ID Number(19) NOT NULL,
	                                    RFQ_ID Number(19) NOT NULL,
	                                    PPO_ORDER_STATUS Number(5) NOT NULL,
	                                    PPO_SPECIAL_INSTRUCTIONS [nvarchar](max) NULL,
	                                    PPO_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PPO_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_PURCHASE_ORDER PRIMARY KEY 
                                    (
	                                    PURCHASE_ORDER_ID 
                                    ) 
                                    );
                    END IF; TEXTIMAGE_ON PRIMARY";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_PURCHASE_ORDER_LOG') THEN
                                        CREATE TABLE POS_PURCHASE_ORDER_LOG(
	                                    PURCHASE_ORDER_LOG_ID Number(19) NOT NULL,
	                                    PURCHASE_ORDER_ID Number(19) NOT NULL,
	                                    PPOL_ORDER_STATUS Varchar2(50) NOT NULL,
	                                    VENDOR_ID Number(19) NOT NULL,
	                                    PPOL_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_PURCHASE_ORDER_LOG PRIMARY KEY 
                                    (
	                                    PURCHASE_ORDER_LOG_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_REFUND_PRODUCTS') THEN
                                        CREATE TABLE POS_REFUND_PRODUCTS(
	                                    REFUND_ID Number(19) NOT NULL,
	                                    PRP_DATE date NOT NULL,
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    SALE_ID Number(19) NOT NULL,
	                                    PRP_AMOUNT Number(18, 0) NOT NULL,
	                                    PRP_QUANTITY Number(10) NOT NULL,
	                                    PRP_TAX Number(18, 0) NULL,
	                                    PRP_SALE_DATE Timestamp(3) NOT NULL,
	                                    PRP_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_REFUND_PRODUCT PRIMARY KEY 
                                    (
	                                    REFUND_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_RFQ') THEN
                                        CREATE TABLE POS_RFQ(
	                                        RFQ_ID Number(19) NOT NULL,
	                                        PRFQ_DATE date NOT NULL,
	                                        PRFQ_NO_OF_ORDERS Number(19) NOT NULL,
	                                        PRFQ_ORDER_STATUS Varchar2(30) NOT NULL,
	                                        VENDOR_ID Number(19) NOT NULL,
	                                        PRFQ_ISACTIVE_FLAG Number(5) NOT NULL,
	                                        PRFQ_ISPOSTED_FLAG Number(5) NOT NULL,
	                                        CREATEDBY Varchar2(60) NOT NULL,
	                                        MODIFIEDBY Varchar2(60) NULL,
	                                        CREATEDWHEN Timestamp(3) NOT NULL,
	                                        MODIFIEDWHEN Timestamp(3) NULL,
                                         CONSTRAINT PK_POS_RFQ PRIMARY KEY 
                                        (
	                                        RFQ_ID 
                                        ) 
                                        );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_RFQ_DETAIL') THEN
                                        CREATE TABLE POS_RFQ_DETAIL(
	                                    RFQ_DETAIL_ID Number(19) NOT NULL,
	                                    RFQ_ID Number(19) NOT NULL,
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    PRFQD_PRODUCT_DESC Varchar2(100) NOT NULL,
	                                    UNIT_ID Number(19) NOT NULL,
	                                    PRFQD_QUANTITY Number(10) NOT NULL,
	                                    PRFQD_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_RFQ_DETAIL PRIMARY KEY 
                                    (
	                                    RFQ_DETAIL_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_RFQ_LOG') THEN
                                        CREATE TABLE POS_RFQ_LOG(
	                                    RFQ_LOG_ID Number(19) NOT NULL,
	                                    RFQ_ID Number(19) NOT NULL,
	                                    PRFQL_DATE date NOT NULL,
	                                    PRFQL_ORDER_STATUS Varchar2(30) NOT NULL,
	                                    VENDOR_ID Number(19) NOT NULL,
	                                    PRFQL_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_RFQ_LOG PRIMARY KEY 
                                    (
	                                    RFQ_LOG_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_RIDER') THEN
                                        CREATE TABLE POS_RIDER(
	                                    RIDER_ID Number(19) NOT NULL,
	                                    PRI_FIRSTNAME Varchar2(50) NOT NULL,
	                                    PRI_LASTNAME Varchar2(50) NOT NULL,
	                                    PRI_MOBILE Varchar2(20) NOT NULL,
	                                    PRI_EMAIL Varchar2(50) NULL,
	                                    PRI_NIC Varchar2(20) NOT NULL,
	                                    PRI_ADDRESS [nvarchar](max) NOT NULL,
	                                    CITY_ID Number(19) NOT NULL,
	                                    STATE_ID Number(19) NOT NULL,
	                                    COUNTRY_ID Number(19) NOT NULL,
	                                    PRI_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PRI_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_RIDER PRIMARY KEY 
                                    (
	                                    RIDER_ID 
                                    ) 
                                    );
                    END IF; TEXTIMAGE_ON PRIMARY";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_SALE_CUSTOMER_DETAIL') THEN
                                        CREATE TABLE POS_SALE_CUSTOMER_DETAIL(
	                                    SALE_ID Number(19) NOT NULL,
	                                    CUSTOMER_ID Number(19) NOT NULL,
	                                    PSCD_SALE_DETAIL Timestamp(3) NOT NULL,
	                                    PSCD_GRAND_TOTAL Number(18, 0) NOT NULL,
	                                    PSCD_CASH_RECIEVE Number(18, 0) NOT NULL,
	                                    PSCD_CASH_RETURN Number(18, 0) NOT NULL,
	                                    PSCD_EXTRA_DISCOUNT Number(10) NULL,
	                                    PSCD_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_SALE_PRODUCT_DETAIL') THEN
                                        CREATE TABLE POS_SALE_PRODUCT_DETAIL(
	                                    SALE_ID Number(19) NOT NULL,
	                                    PSPD_SALE_DATE date NOT NULL,
	                                    CUSTOMER_ID Number(19) NOT NULL,
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    PSPD_PRICE Number(18, 0) NOT NULL,
	                                    PSPD_QUANTITY Number(10) NOT NULL,
	                                    PSPD_DISCOUNT_PER Number(10) NOT NULL,
	                                    DISCOUNT_AMOUNT Number(10) NOT NULL,
	                                    PSPD_TOTAL_AMOUNT Number(18, 0) NOT NULL,
	                                    PSPD_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_SALE_PRODUCT_DETAIL PRIMARY KEY 
                                    (
	                                    SALE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_SECTIONS') THEN
                                        CREATE TABLE POS_SECTIONS(
	                                    SECTION_ID Number(19) NOT NULL,
	                                    PS_CODE Varchar2(10) NOT NULL,
	                                    PS_DESC Varchar2(200) NOT NULL,
	                                    PS_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_SECTIONS PRIMARY KEY 
                                    (
	                                    SECTION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_SHIFT') THEN
                                        CREATE TABLE POS_SHIFT(
	                                    SHIFT_ID Number(19) NOT NULL,
	                                    PSH_CODE Varchar2(10) NOT NULL,
	                                    PSH_DESC Varchar2(200) NOT NULL,
	                                    PSH_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PSH_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_SHIFT PRIMARY KEY 
                                    (
	                                    SHIFT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_STATE') THEN
                                        CREATE TABLE POS_STATE(
	                                    STATE_ID Number(19) NOT NULL,
	                                    PST_CODE Varchar2(15) NOT NULL,
	                                    PST_DESC Varchar2(50) NOT NULL,
	                                    PST_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PST_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_STATE PRIMARY KEY 
                                    (
	                                    STATE_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_SUPERVISOR') THEN
                                        CREATE TABLE POS_SUPERVISOR(
	                                    SUPERVISOR_ID Number(19) NOT NULL,
	                                    PSU_FIRSTNAME Varchar2(50) NOT NULL,
	                                    PSU_LASTNAME Varchar2(50) NOT NULL,
	                                    PSU_MOBILE Varchar2(20) NOT NULL,
	                                    PSU_EMAIL Varchar2(50) NULL,
	                                    PSU_NIC Varchar2(20) NOT NULL,
	                                    PSU_ADDRESS [nvarchar](max) NOT NULL,
	                                    CITY_ID Number(19) NOT NULL,
	                                    STATE_ID Number(19) NOT NULL,
	                                    COUNTRY_ID Number(19) NULL,
	                                    PSU_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PSU_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_SUPERVISOR PRIMARY KEY 
                                    (
	                                    SUPERVISOR_ID 
                                    ) 
                                    );
                    END IF; TEXTIMAGE_ON PRIMARY";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_USER') THEN
                                        CREATE TABLE POS_USER(
	                                    USER_ID Number(19) NOT NULL,
	                                    PU_CODE Varchar2(10) NOT NULL,
	                                    PU_DESC Varchar2(100) NULL,
	                                    PU_LOGIN Varchar2(40) NOT NULL,
	                                    PU_PASSWORD Varchar2(100) NOT NULL,
	                                    PU_ISACTIVE_FLAG Number(5) NULL,
	                                    PU_EPOSTED_FLAG Number(5) NULL,
	                                    PU_ISMASTER_USER_FLAG Number(5) NULL,
	                                    PU_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
	                                    ACCESS_GROUP_ID Number(19) NULL,
                                     CONSTRAINT PK_POS_USERS PRIMARY KEY 
                                    (
	                                    USER_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_USER_DATA_SECURITY') THEN
                                        CREATE TABLE POS_USER_DATA_SECURITY(
	                                    ID Number(19)  NOT NULL,
	                                    USER_ID Number(19) NOT NULL,
	                                    PUDS_SERIAL_NO Number(10) NOT NULL,
	                                    PUDS_PARAMETER_TYPE Number(10) NOT NULL,
	                                    PUDS_PARAMETER_TABLE Varchar2(50) NOT NULL,
	                                    PUDS_PARAMETER_VALUE Varchar2(50) NOT NULL,
	                                    PUDS_ISACTIVE_FLAG Number(5) NULL,
	                                    PUDS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_USER_DATA_SECURITY PRIMARY KEY 
                                    (
	                                    ID 
                                    ) 
                                    );

-- Generate ID using sequence and trigger
CREATE SEQUENCE POS_USER_DATA_SECURITY_seq START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER POS_USER_DATA_SECURITY_seq_tr
                                         BEFORE INSERT ON POS_USER_DATA_SECURITY FOR EACH ROW
                                         WHEN (NEW.ID IS NULL)
                                        BEGIN
 SELECT POS_USER_DATA_SECURITY_seq.NEXTVAL INTO :NEW.ID FROM DUAL;
END;
/
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_USER_LOG') THEN
                                        CREATE TABLE POS_USER_LOG(
	                                    USER_LOG_ID Number(19) NOT NULL,
	                                    USER_ID Number(19) NOT NULL,
	                                    SYS_APP_MODULE_ID Number(19) NOT NULL,
	                                    MENU_ID Number(19) NOT NULL,
	                                    PUL_SCREEN_NAME Varchar2(100) NOT NULL,
	                                    PUL_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_USER_LOG PRIMARY KEY 
                                    (
	                                    USER_LOG_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_VENDOR') THEN
                                        CREATE TABLE POS_VENDOR(
	                                    VENDOR_ID Number(19) NOT NULL,
	                                    PV_VENDOR_DESC Varchar2(100) NOT NULL,
	                                    PV_VENDOR_NAME Varchar2(50) NOT NULL,
	                                    PV_TELEPHONE Varchar2(20) NULL,
	                                    PV_MOBILE Varchar2(15) NOT NULL,
	                                    PV_EMAIL Varchar2(50) NOT NULL,
	                                    PV_NTN_NO nchar(10) NULL,
	                                    CITY_ID Number(19) NOT NULL,
	                                    STATE_ID Number(19) NOT NULL,
	                                    COUNTRY_ID Number(19) NULL,
	                                    PV_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PV_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NOT NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NOT NULL,
                                     CONSTRAINT PK_POS_VENDOR PRIMARY KEY 
                                    (
	                                    VENDOR_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_VENDOR_SHIPPMENT') THEN
                                        CREATE TABLE POS_VENDOR_SHIPPMENT(
	                                    VSHIPPMENT_ID Number(19) NOT NULL,
	                                    PVS_SHIPPMENT_DATE date NOT NULL,
	                                    PVS_PRODUCT_ID Number(19) NOT NULL,
	                                    PVS_PRODUCT_DESC Varchar2(100) NOT NULL,
	                                    PVS_QUANTITY Number(10) NOT NULL,
	                                    PVS_DISTRIBUTED_QUANTITY Number(10) NOT NULL,
	                                    PURCHASE_ORDER_ID Number(19) NOT NULL,
	                                    SUPERVISOR_ID Number(19) NULL,
	                                    RIDER_ID Number(19) NULL,
	                                    PVS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_VENDOR_SHIPPMENT PRIMARY KEY 
                                    (
	                                    VSHIPPMENT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE') THEN
                                        CREATE TABLE POS_WEARHOUSE(
	                                    WEARHOUSE_ID Number(19) NOT NULL,
	                                    PW_WEARHOUSE_DESC Varchar2(100) NOT NULL,
	                                    PW_TELEPHONE Varchar2(20) NULL,
	                                    PW_ADDRESS [nvarchar](max) NOT NULL,
	                                    CITY_ID Number(19) NOT NULL,
	                                    STATE_ID Number(19) NOT NULL,
	                                    COUNTRY_ID Number(19) NULL,
	                                    PW_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PW_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE PRIMARY KEY 
                                    (
	                                    WEARHOUSE_ID 
                                    ) 
                                    );
                    END IF; TEXTIMAGE_ON PRIMARY";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_FLOOR') THEN
                                        CREATE TABLE POS_WEARHOUSE_FLOOR(
	                                    WEARHOUSE_FLOOR_ID Number(19) NOT NULL,
	                                    PWF_CODE nchar(10) NOT NULL,
	                                    PWF_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PWF_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PWF_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_FLOOR PRIMARY KEY 
                                    (
	                                    WEARHOUSE_FLOOR_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_INVENTORY_TRACKING') THEN
                                        CREATE TABLE POS_WEARHOUSE_INVENTORY_TRACKING(
	                                    WEARHOUSE_ITRACKING_ID Number(19) NOT NULL,
	                                    WEARHOUSE_FLOOR_ID Number(19) NOT NULL,
	                                    WEARHOUSE_SECTION_ID Number(19) NOT NULL,
	                                    WEARHOUSE_RAG_ID Number(19) NULL,
	                                    WEARHOUSE_RAG_FLOOR_ID Number(19) NULL,
	                                    PWIT_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_INVENTORY_TRACKING_1 PRIMARY KEY 
                                    (
	                                    WEARHOUSE_ITRACKING_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_RAGS') THEN
                                        CREATE TABLE POS_WEARHOUSE_RAGS(
	                                    WEARHOUSE_RAG_ID Number(19) NOT NULL,
	                                    PWR_CODE nchar(10) NOT NULL,
	                                    PWR_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PWR_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PWR_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_RAGS PRIMARY KEY 
                                    (
	                                    WEARHOUSE_RAG_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_RAGS_FLOOR') THEN
                                        CREATE TABLE POS_WEARHOUSE_RAGS_FLOOR(
	                                    WEARHOUSE_RAG_FLOOR_ID Number(19) NOT NULL,
	                                    PWRF_CODE nchar(10) NOT NULL,
	                                    PWRF_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PWRF_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PWRF_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_RAGS_FLOOR PRIMARY KEY 
                                    (
	                                    WEARHOUSE_RAG_FLOOR_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_SECTIONS') THEN
                                        CREATE TABLE POS_WEARHOUSE_SECTIONS(
	                                    WEARHOUSE_SECTION_ID Number(19) NOT NULL,
	                                    PWSE_CODE nchar(10) NOT NULL,
	                                    PWSE_LABEL_NAME Varchar2(20) NOT NULL,
	                                    PWSE_ISACTIVE_FLAG Number(5) NOT NULL,
	                                    PWSE_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_SECTIONS PRIMARY KEY 
                                    (
	                                    WEARHOUSE_SECTION_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_SHIPPMENT') THEN
                                        CREATE TABLE POS_WEARHOUSE_SHIPPMENT(
	                                    WSHIPPMENT_ID Number(19) NOT NULL,
	                                    PWS_SHIPPMENT_DATE date NOT NULL,
	                                    PWS_PRODUCT_ID Number(19) NOT NULL,
	                                    PWS_PRODUCT_DESC Varchar2(100) NOT NULL,
	                                    PWS_QUANTITY Number(10) NOT NULL,
	                                    PURCHASE_ORDER_ID Number(19) NOT NULL,
	                                    SUPERVISOR_ID Number(19) NULL,
	                                    RIDER_ID Number(19) NULL,
	                                    PWS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_SHIPPMENT PRIMARY KEY 
                                    (
	                                    WSHIPPMENT_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();



                    MstrQuery = @"IF NOT EXISTS
                                    (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME ='POS_WEARHOUSE_STOCK') THEN
                                        CREATE TABLE POS_WEARHOUSE_STOCK(
	                                    WSTOCK_ID Number(19) NOT NULL,
	                                    PWS_DATE date NOT NULL,
	                                    PRODUCT_ID Number(19) NOT NULL,
	                                    PWS_QUANTITY_IN Number(10) NOT NULL,
	                                    PWS_QUANTITY_OUT Number(10) NOT NULL,
	                                    PWS_STOCK_TYPE Varchar2(20) NOT NULL,
	                                    PWS_UNIT_PRICE Number(18, 0) NOT NULL,
	                                    PWS_TOTAL_PRICE Number(18, 0) NOT NULL,
	                                    VSHIPPMENT_ID Number(19) NOT NULL,
	                                    PWS_ISPOSTED_FLAG Number(5) NOT NULL,
	                                    CREATEDBY Varchar2(60) NOT NULL,
	                                    MODIFIEDBY Varchar2(60) NULL,
	                                    CREATEDWHEN Timestamp(3) NOT NULL,
	                                    MODIFIEDWHEN Timestamp(3) NULL,
                                     CONSTRAINT PK_POS_WEARHOUSE_STOCK PRIMARY KEY 
                                    (
	                                    WSTOCK_ID 
                                    ) 
                                    );
                    END IF;";
                    ExecuteNonQuery();
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
