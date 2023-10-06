using Domain.Common;
using Domain.Customer.Dtos;

namespace Domain.Customer
{
    public interface IUpdateBirthDateService
    {
        Task<ServiceResult<CustomerDto>> Update(UpdateBirthDateDto newDate);
    }
}