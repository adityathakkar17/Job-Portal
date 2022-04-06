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
    public interface IJobApplicationService
    {
        [OperationContract]
        DataSet GetJobApplicationsOfApplicant(int jobApplicantId);

        [OperationContract]
        DataSet GetJobApplicationsOfJobCategory(int jobId);
        [OperationContract]
        int ApplyJob(JobApplication ja);
    }
}
