using Moq;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test.Backend.Domain.Interfaces.Repository;
using Test.Backend.Domain.Models;
using Test.Backend.Domain.Models.ViewModel;
using Test.Backend.Domain.Services;
using Xunit;

namespace Test.Backend.Tests.Services
{
    public class CustomerServiceTests
    {
        public readonly Mock<ICustomerRepository> _customerRepository;
        public CustomerServiceTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
        }

        [Fact(DisplayName = "Customer update fail by Customer under 18")]
        public async Task CustomerUpdateFailByCustomerUnder18()
        {

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new UpdateCustomer { Age = 10, Name = "Cesar Brito" };

            var result = await customerService.UpdateAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Customer can't age under 18.", result.Errors);
        }

        [Fact(DisplayName = "Customer update fail by Customer name not is full name")]
        public async Task CustomerUpdateFailByCustomerNameNotIsFullName()
        {

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new UpdateCustomer { Age = 18, Name = "Cesar" };

            var result = await customerService.UpdateAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Customer need it full name.", result.Errors);
        }

        [Fact(DisplayName = "Customer update fail by Customer name length below 3")]
        public async Task CustomerUpdateFailByCustomerNameLengthBelow3()
        {

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new UpdateCustomer { Age = 18, Name = "Ce" };

            var result = await customerService.UpdateAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Customer name can't length under 3 characters.", result.Errors);
        }


        [Fact(DisplayName = "Customer update fail by Can't update Customer")]
        public async Task CustomerUpdateFailByCantUpdateCustomer()
        {

            _customerRepository.Setup(i => i.UpdateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new UpdateCustomer { Age = 18, Name = "Cesar brito" };

            var result = await customerService.UpdateAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Erro on update Customer.", result.Errors);
        }

        [Fact(DisplayName = "Customer update Success")]
        public async Task CustomerUpdateSuccess()
        {

            _customerRepository.Setup(i => i.UpdateAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new UpdateCustomer { Age = 18, Name = "Cesar brito" };

            var result = await customerService.UpdateAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.True(result.IsSuccess);

            var erros = 0;
            Assert.Equal(result.Errors.Count(), erros);
        }




        [Fact(DisplayName = "Customer Register fail by Customer under 18")]
        public async Task CustomerRegisterFailByCustomerUnder18()
        {

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new RegisterCustomer { Age = 10, Name = "Cesar Brito" };

            var result = await customerService.RegisterAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Customer can't age under 18.", result.Errors);
        }

        [Fact(DisplayName = "Customer register fail by Customer name not is full name")]
        public async Task CustomerRegisterFailByCustomerNameNotIsFullName()
        {

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new RegisterCustomer { Age = 18, Name = "Cesar" };

            var result = await customerService.RegisterAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Customer need it full name.", result.Errors);
        }

        [Fact(DisplayName = "Customer update fail by Customer name length below 3")]
        public async Task CustomerRegisterFailByCustomerNameLengthBelow3()
        {

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new RegisterCustomer { Age = 18, Name = "Ce" };

            var result = await customerService.RegisterAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Customer name can't length under 3 characters.", result.Errors);
        }


        [Fact(DisplayName = "Customer register fail by Can't update Customer")]
        public async Task CustomerRegisterFailByCantUpdateCustomer()
        {

            _customerRepository.Setup(i => i.RegisterAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new RegisterCustomer { Age = 18, Name = "Cesar brito" };

            var result = await customerService.RegisterAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.False(result.IsSuccess);
            Assert.Contains("Erro on register Customer.", result.Errors);
        }

        [Fact(DisplayName = "Customer register Success")]
        public async Task CustomerRegisterSuccess()
        {

            _customerRepository.Setup(i => i.RegisterAsync(It.IsAny<Customer>(), It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var customerService = new CustomerService(_customerRepository.Object);

            var updateCustomer = new RegisterCustomer { Age = 18, Name = "Cesar brito" };

            var result = await customerService.RegisterAsync(updateCustomer, It.IsAny<CancellationToken>());

            Assert.True(result.IsSuccess);
            
            var erros = 0;
            Assert.Equal(result.Errors.Count(), erros);
        }


    }
}
