using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Backend.Domain.Interfaces.Repository;
using Test.Backend.Domain.Models;
using Test.Backend.Repository.Context;

namespace Test.Backend.Repository.SQL
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly TestBackendContext _context;

        public CustomerRepository(TestBackendContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(i => i.Id.Equals(id), cancellationToken);

            if (customer == null)
            {
                return -1;
            }

            _context.Remove(customer);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Customer customer, CancellationToken cancellationToken)
        {
            var customerUpdating = await _context.Customers.FirstOrDefaultAsync(i => i.Id.Equals(customer.Id), cancellationToken);

            if (customerUpdating == null)
            {
                return -1;
            }

            customerUpdating.Name = customer.Name;
            customerUpdating.Age = customer.Age;

            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken) =>
            await _context.Customers.Select(i => new Customer { Id = i.Id, Age = i.Age, Name = i.Name }).ToListAsync(cancellationToken);

        public async Task<Customer> GetAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Customers.FirstOrDefaultAsync(i => i.Id.Equals(id), cancellationToken);

        public async Task<int> RegisterAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
