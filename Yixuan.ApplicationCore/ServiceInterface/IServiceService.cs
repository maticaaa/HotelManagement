using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface IServiceService
    {
        Task<ServiceResponseModel> AddNewService(ServiceCreateModel createModel);
        Task<ServiceResponseModel> UpdateService(ServiceRequestModel requestModel);
        Task<ServiceResponseModel> DeleteService(int id);
        Task<IEnumerable<ServiceResponseModel>> ListAllServices();
    }
}
