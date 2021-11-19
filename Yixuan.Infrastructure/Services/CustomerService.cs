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
    public class CustomerService : ICustomerService
    {
        protected readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerResponseModel> AddNewCustomer(CustomerCreateModel createModel)
        {
            var customer = new Customer
            {
                RoomNo = createModel.RoomNo,
                CName = createModel.CName,
                Address = createModel.Address,
                Phone = createModel.Phone,
                Email = createModel.Email,
                CheckIn = createModel.CheckIn,
                TotalPersons = createModel.TotalPersons,
                BookingDays = createModel.BookingDays
            };
            var newCustomer = await _customerRepository.Add(customer);

            var customerResponseModel = new CustomerResponseModel
            {
                Id = newCustomer.Id,
                CName = newCustomer.CName
            };
            return customerResponseModel;   
        }

        public async Task<CustomerResponseModel> DeleteCustomer(int id)
        {

            var customer = await _customerRepository.GetById(id);
            if(customer == null)
            {
                return null;
            }
            var deletedCustomer = await _customerRepository.Delete(customer);
            var customerResponseModel = new CustomerResponseModel
            {
                Id = deletedCustomer.Id,
                CName = deletedCustomer.CName
            };
            return customerResponseModel;
        }

        public async Task<CustomerDetailsModel> GetCustomerDetails(int id)
        {
            var customer = await _customerRepository.GetCustomerDetails(id);
            var customerDetailsModel = new CustomerDetailsModel
            {
                Id = customer.Id,
                RoomNo = customer.RoomNo.GetValueOrDefault(),
                CName = customer.CName,
                Address = customer.Address,
                Phone = customer.Phone,
                Email = customer.Email,
                CheckIn = customer.CheckIn.GetValueOrDefault(),
                TotalPersons = customer.TotalPersons.GetValueOrDefault(),
                BookingDays = customer.BookingDays.GetValueOrDefault(),
                Advance = customer.Advance.GetValueOrDefault(),
                Room = new RoomResponseModel
                {
                    Id = customer.Room.Id,
                    RTCode = customer.Room.RTCode.GetValueOrDefault(),
                    Status = customer.Room.Status.GetValueOrDefault()
                }
            };
            return customerDetailsModel;
        }

        public async Task<IEnumerable<CustomerResponseModel>> ListAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            var customerResponseModels = new List<CustomerResponseModel>();
            foreach (var customer in customers)
            {
                customerResponseModels.Add(new CustomerResponseModel
                {
                    Id = customer.Id,
                    CName = customer.CName
                });
            }
            return customerResponseModels;
        }

        public async Task<CustomerResponseModel> UpdateCustomer(CustomerRequestModel requestModel)
        {
            var customer = new Customer
            {
                Id = requestModel.Id,
                RoomNo = requestModel.RoomNo,
                CName = requestModel.CName,
                Address = requestModel.Address,
                Phone = requestModel.Phone,
                Email = requestModel.Email,
                CheckIn = requestModel.CheckIn,
                TotalPersons = requestModel.TotalPersons,
                BookingDays = requestModel.BookingDays
            };
            var updatedCustomer = await _customerRepository.Update(customer);
            var customerResponseModel = new CustomerResponseModel
            {
                Id = updatedCustomer.Id,
                CName = updatedCustomer.CName
            };
            return customerResponseModel;
        }
    }
}
