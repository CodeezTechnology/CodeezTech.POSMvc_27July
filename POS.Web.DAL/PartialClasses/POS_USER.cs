using CodeezTech.POS.Web.DAL.EntityDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeezTech.POS.Web.DAL.EntityDataModel
{
   public partial class POS_USER
    {
       public POS_USER()
       {
           Company = new POS_COMPANY();
           Branch = new POS_BRANCH();
       }
       [NotMapped]
       public string ConfirmPassword { get; set; }
       [NotMapped]
       public string NotifyMessage { get; set; }
       [NotMapped]
       public int RowEffected { get; set; }
       [NotMapped]
       public string BranchName { get; set; }
       [NotMapped]
       public List<POS_BRANCH> listCompanyBranch { get; set; }
       [NotMapped]
       public POS_BRANCH Branch { get; set; }
       [NotMapped]
       public long BranchId
       {
           get { return Branch.BRANCH_ID; }
           set { Branch.BRANCH_ID = value; }
       }
       [NotMapped]
       public POS_COMPANY Company { get; set; }
       [NotMapped]
       public long? CompanyId
       {
           get { return Company.COMPANY_ID; }
           set { Company.COMPANY_ID = (long)value; }
       }

    }
}
