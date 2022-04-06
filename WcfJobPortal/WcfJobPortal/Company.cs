using System.Runtime.Serialization;

namespace WcfJobPortal
{
    [DataContract]
    public class Company
    {
        private int Id;
        private string name = "";
        private string email = "";
        private string password = "";
        private string location = "";

        [DataMember]
        public int CompanyId
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
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}