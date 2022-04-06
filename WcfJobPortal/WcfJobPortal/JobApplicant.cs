using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    [DataContract]
    public class JobApplicant
    {
        private int Id;
        private string name = "";
        private string email = "";
        private string password = "";
        private string phone = "";

        [DataMember]
        public int JobApplicantId
        {
            get { return Id; }
            set { Id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
