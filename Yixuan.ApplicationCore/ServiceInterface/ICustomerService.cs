using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yixuan.ApplicationCore.Models;

namespace ApplicationCore.ServiceInterface
{
    public interface ICustomerService
    {
        Task<CustomerDetailsModel> GetCustomerDetails(int id);
        Task<CustomerResponseModel> AddNewCustomer(CustomerCreateModel createModel);
        Task<CustomerResponseModel> UpdateCustomer(CustomerRequestModel requestModel);
        Task<CustomerResponseModel> DeleteCustomer(int id);
        Task<IEnumerable<CustomerResponseModel>> ListAllCustomers();
    }
}
