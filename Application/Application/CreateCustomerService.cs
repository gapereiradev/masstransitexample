using AutoMapper;
using Domain.Common;
using Domain.Customer;
using Domain.Customer.Dtos;

namespace Application
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CreateCustomerService(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CustomerDto>> Create(NewCustomerDto data)
        {
            try
            {
                var newCustomer = _mapper.Map<NewCustomer>(data);
                var createdCustomer = await _repo.CreateCustomer(newCustomer);

                return ServiceResult<CustomerDto>.Success(_mapper.Map<CustomerDto>(createdCustomer));
            }
            catch (ArgumentException e)
            {
                return ServiceResult<CustomerDto>.Error("ERR_VALIDATION", e.Message);
            }
        }
    }
}