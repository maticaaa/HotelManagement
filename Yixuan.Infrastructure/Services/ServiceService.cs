using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class ServiceService : IServiceService
    {
        protected readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<ServiceResponseModel> AddNewService(ServiceCreateModel createModel)
        {
            var service = new Service
            {
                RoomNo = createModel.RoomNo,
                SDesc = createModel.SDesc,
                ServiceDate = createModel.ServiceDate,
                Amount = createModel.Amount
            };
            var newService = await _serviceRepository.Add(service);
            var serviceResponseModel = new ServiceResponseModel
            {
                Id = newService.Id,
                RoomNo = newService.RoomNo.GetValueOrDefault(),
                SDesc = newService.SDesc,
                ServiceDate = newService.ServiceDate.GetValueOrDefault(),
                Amount = newService.Amount.GetValueOrDefault()
            };
            return serviceResponseModel;
        }

        public async Task<ServiceResponseModel> DeleteService(int id)
        {
            var service = await _serviceRepository.GetById(id);
            if (service == null) return null;
            var deletedService = await _serviceRepository.Delete(service);
            var serviceResponseModel = new ServiceResponseModel
            {
                Id = deletedService.Id,
                RoomNo = deletedService.RoomNo.GetValueOrDefault(),
                SDesc = deletedService.SDesc,
                ServiceDate = deletedService.ServiceDate.GetValueOrDefault(),
                Amount = deletedService.Amount.GetValueOrDefault()
            };
            return serviceResponseModel;
        }

        public async Task<IEnumerable<ServiceResponseModel>> ListAllServices()
        {
            var services = await _serviceRepository.GetAll();
            var serviceResponseModels = new List<ServiceResponseModel>();
            foreach (var service in services)
            {
                serviceResponseModels.Add(new ServiceResponseModel
                {
                    Id = service.Id,
                    RoomNo = service.RoomNo.GetValueOrDefault(),
                    SDesc = service.SDesc,
                    ServiceDate = service.ServiceDate.GetValueOrDefault(),
                    Amount = service.Amount.GetValueOrDefault()
                });
            }
            return serviceResponseModels;
        }

        public async Task<ServiceResponseModel> UpdateService(ServiceRequestModel requestModel)
        {
            var service = new Service
            {
                Id = requestModel.Id,
                RoomNo = requestModel.RoomNo,
                SDesc = requestModel.SDesc,
                ServiceDate = requestModel.ServiceDate,
                Amount = requestModel.Amount
            };
            var updatedService = await _serviceRepository.Update(service);
            var serviceResponseModel = new ServiceResponseModel
            {
                Id = updatedService.Id,
                RoomNo = updatedService.RoomNo.GetValueOrDefault(),
                SDesc = updatedService.SDesc,
                ServiceDate = updatedService.ServiceDate.GetValueOrDefault(),
                Amount = updatedService.Amount.GetValueOrDefault()
            };
            return serviceResponseModel;
        }
    }
}
