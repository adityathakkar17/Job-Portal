using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    [DataContract]
    public class Job
    {
        private int Id;
        private int companyId;
        private int categoryId;
        private int vacancy;
        private int salary;
        private int duration;
        [DataMember]
        public int JobId
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember]
        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }
        [DataMember]
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        [DataMember]
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        [DataMember]
        public int Vacancy
        {
            get { return vacancy; }
            set { vacancy = value; }
        }
        [DataMember]
        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }


    }
}
