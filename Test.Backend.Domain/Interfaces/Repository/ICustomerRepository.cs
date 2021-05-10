using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Backend.Domain.Models;

namespace Test.Backend.Domain.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken);

        Task<int> EditAsync(Customer cliente, CancellationToken cancellationToken);

        Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken);

        Task<Customer> GetAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellation);
    }
}
