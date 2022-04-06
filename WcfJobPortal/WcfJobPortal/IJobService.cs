using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfJobPortal
{
    [ServiceContract]
    public interface IJobService
    {
        [OperationContract]
        DataSet GetJobs(int categoryId);
        [OperationContract]
        DataSet GetJobsofCompany(int companyId);
        [OperationContract]
        DataSet GetAllJobs();
        [OperationContract]
        int AddJob(Job j);
        [OperationContract]
        int UpdateJob(Job j);
        [OperationContract]
        int DeleteJob(int id);
        [OperationContract]
        int AddJobCategory(string jobCategory);

    }
}
