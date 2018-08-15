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
    public partial class POS_PRODUCT
    {
        public POS_PRODUCT()
        {
            ProductCategory = new POS_PRODUCT_CATEGORY();
            ProductType = new POS_PRODUCT_TYPE();
            Units = new POS_UNITS();
        }
        [NotMapped]
        public POS_PRODUCT_CATEGORY ProductCategory { get; set; }
        [NotMapped]
        public long CategoryId
        {
            get { return ProductCategory.CATEGORY_ID; }
            set { ProductCategory.CATEGORY_ID = value; }
        }
        [NotMapped]
        public string CategoryDesc { get; set; }
        [NotMapped]
        public string TypeDesc { get; set; }
        [NotMapped]
        public string UnitDesc { get; set; }
        [NotMapped]
        public POS_PRODUCT_TYPE ProductType { get; set; }
        [NotMapped]
        public long TypeId
        {
            get { return ProductType.TYPE_ID; }
            set { ProductType.TYPE_ID = value; }
        }
        [NotMapped]
        public POS_UNITS Units{ get; set; }
        [NotMapped]
        public long UnitId
        {
            get { return Units.UNIT_ID; }
            set { Units.UNIT_ID = value; }
        }
    }
}
