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
    public partial class POS_BRANCH
    {
        public POS_BRANCH()
        {
            Company = new POS_COMPANY();
            City = new POS_CITY();
            State = new POS_STATE();
            Country = new POS_COUNTRY();
        }
        [NotMapped]
        public POS_COMPANY Company { get; set; }
        [NotMapped]
        public POS_CITY City { get; set; }
        [NotMapped]
        public POS_STATE State { get; set; }
        [NotMapped]
        public POS_COUNTRY Country { get; set; }

        [NotMapped]
        public long CompanyId
        {
            get { return Company.COMPANY_ID; }
            set { Company.COMPANY_ID = value; }
        }
        [NotMapped]
        public long CityId
        {
            get { return City.CITY_ID; }
            set { City.CITY_ID = value; }
        }
        [NotMapped]
        public long StateId
        {
            get { return State.STATE_ID; }
            set { State.STATE_ID = value; }
        }
        [NotMapped]
        public long CountryId
        {
            get { return Country.COUNTRY_ID; }
            set { Country.COUNTRY_ID = value; }
        }
     
        [NotMapped]
        public string CompanyName { get; set; }
        [NotMapped]
        public string CityName { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string CountryName { get; set; }
    }
}
