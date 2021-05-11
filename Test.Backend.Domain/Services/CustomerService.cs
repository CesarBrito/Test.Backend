using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Backend.Domain.Extentions;
using Test.Backend.Domain.Interfaces.Repository;
using Test.Backend.Domain.Interfaces.Services;
using Test.Backend.Domain.Models;
using Test.Backend.Domain.Models.ViewModel;

namespace Test.Backend.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken) => await _customerRepository.GetAllAsync(cancellationToken);

        public async Task<Customer> GetAsync(Guid id, CancellationToken cancellationToken) => await _customerRepository.GetAsync(id, cancellationToken);

        public async Task<RequestResult> RegisterAsync(RegisterCustomer registerCustomer, CancellationToken cancellationToken)
        {
            var customer = new Customer() { Id = Guid.NewGuid(), Age = registerCustomer.Age, Name = registerCustomer.Name.Trim() };

            var result = new RequestResult { IsSuccess = true, Errors = customer.Validate() };

            if (result.Errors.Count() < 1)
            {
                var register = await _customerRepository.RegisterAsync(customer, cancellationToken);

                if (register > 0)
                {
                    return result;
                }

                result.Errors = new List<string> { "Erro on register Customer." };
                result.IsSuccess = false;
            }

            return result;

        }

        public async Task<RequestResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = new RequestResult { IsSuccess = true };

            var delete = await _customerRepository.DeleteAsync(id, cancellationToken);

            if (delete < 1)
            {
                result.IsSuccess = false;
                result.Errors = new List<string> { "Erro on delete Customer." };
            }

            return result;
        }

        public async Task<RequestResult> UpdateAsync(UpdateCustomer updateCustomer, CancellationToken cancellationToken)
        {
            var customer = new Customer { Id = updateCustomer.Id, Name = updateCustomer.Name.Trim(), Age = updateCustomer.Age };

            var result = new RequestResult { IsSuccess = true, Errors = customer.Validate() };

            if (result.Errors.Count() < 1)
            {
                var register = await _customerRepository.UpdateAsync(customer, cancellationToken);

                if (register > 0)
                {
                    return result;
                }

                result.Errors = new List<string> { "Erro on update Customer." };
                result.IsSuccess = false;
            }

            return result;
        }
    }
}
