using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Backend.Domain.Interfaces.Repository;
using Test.Backend.Domain.Models;

namespace Test.Backend.Repository.SQL
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditAsync(Customer cliente, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
