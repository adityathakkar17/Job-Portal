using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    [ServiceContract]
    public interface IManageUserService
    {
        //Company Services
        [OperationContract]
        int AddCompany(Company c);
        [OperationContract]
        int DeleteCompany(int id);


        //JobApplicant Services
        [OperationContract]
        int AddJobApplicant(JobApplicant c);
        [OperationContract]
        int DeleteJobApplicant(int id);

        //General Services
        [OperationContract]
        User LogIn(string email, string password, int role);
        //role=0->Admin,1->Company,2->JobApplicant
    }
}
