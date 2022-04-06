using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    [DataContract]
    public class JobApplication
    {
        private int Id;
        private int jobId;
        private int jobApplicantId;

        [DataMember]
        public int JobApplicationId
        {
            get { return Id; }
            set { Id = value; }
        }
        [DataMember]
        public int JobId
        {
            get { return jobId; }
            set { jobId = value; }
        }
        [DataMember]
        public int JobApplicantId
        {
            get { return jobApplicantId; }
            set { jobApplicantId = value; }
        }
    }
}
