using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    [DataContract]
    public class User
    {
        private int Id;
        private string name = "";
        private string email = "";
        private int role;
        [DataMember]
        public int UserId
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
        public int Role
        {
            get { return role; }
            set { role = value; }
        }
        //role=0->Admin,1->Company,2->JobApplicant
    }
}
