using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Backend.Domain.Models;
using Test.Backend.Domain.Models.ViewModel;

namespace Test.Backend.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken);
        Task<Customer> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<RequestResult> RegisterAsync(RegisterCustomer customer, CancellationToken cancellationToken);
        Task<RequestResult> DeleteAsync(Guid guid, CancellationToken cancellationToken);
        Task<RequestResult> UpdateAsync(UpdateCustomer customer, CancellationToken cancellationToken);
    }
}
