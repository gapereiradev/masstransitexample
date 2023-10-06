using Domain.Common;
using Domain.Customer.Dtos;

namespace Domain.Customer
{
    public interface ICreateCustomerService
    {
        Task<ServiceResult<CustomerDto>> Create(NewCustomerDto data);
    }
}