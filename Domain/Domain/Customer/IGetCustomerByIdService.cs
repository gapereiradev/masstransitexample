using Domain.Common;
using Domain.Customer.Dtos;

namespace Domain.Customer
{
    public interface IGetCustomerByIdService
    {
        Task<ServiceResult<CustomerDto>> GetCustomer(Guid customerId);
    }
}