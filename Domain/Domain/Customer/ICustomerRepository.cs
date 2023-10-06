namespace Domain.Customer
{
    public interface ICustomerRepository
    {
        Task<Customer> WithId(CustomerId customerId);
        Task<Customer> CreateCustomer(NewCustomer customer);
        Task ChangeBirthDate(Customer customer);
    }
}