using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test.Backend.Domain.Interfaces.Services;
using Test.Backend.Domain.Models;
using Test.Backend.WebApi.Support;
using Microsoft.Extensions.Options;
using Test.Backend.Domain.Models.ViewModel;

namespace Test.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        private readonly ICustomerService _customerService;

        private readonly ApplicationOption _options;

        public CustomerController(ICustomerService customerService, IOptions<ApplicationOption> options, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _options = options.Value;
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                using (CancellationTokenSource cn = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    cn.CancelAfter(_options.CancellationTokenDefault);
                    return await _customerService.GetAllAsync(cancellationToken);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get all customers");
                throw;
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Customer> Get(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                using (CancellationTokenSource cn = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    cn.CancelAfter(_options.CancellationTokenDefault);
                    return await _customerService.GetAsync(id, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error get customers {id}");
                throw;
            }
        }

        [HttpPost]
        public async Task<RequestResult> Post(RegisterCustomer registerCustomer, CancellationToken cancellationToken)
        {
            try
            {
                return await _customerService.RegisterAsync(registerCustomer, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro on register Customer");
                throw;
            }
        }

        [HttpPut]
        public async Task<RequestResult> Put(UpdateCustomer updateCustomer, CancellationToken cancellationToken)
        {
            try
            {
                using (CancellationTokenSource cn = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    cn.CancelAfter(_options.CancellationTokenDefault);
                    return await _customerService.UpdateAsync(updateCustomer, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on update customers");
                throw;
            }
        }

        [HttpDelete]
        public async Task<RequestResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                using (CancellationTokenSource cn = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                {
                    cn.CancelAfter(_options.CancellationTokenDefault);
                    return await _customerService.DeleteAsync(id, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error on delete customers");
                throw;
            }
        }

    }
}
