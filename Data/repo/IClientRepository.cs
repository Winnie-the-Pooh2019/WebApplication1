using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IClientRepository {
    public Task<List<Customer>> getAll();
    public Task<List<Customer>> getAllByLastName(string lastName);
    public Task<List<Customer>> getAllByFirstName(string firstName);
    public Task<Customer?> getById(int id);

    public Task<bool> deleteById(int id);
    public Task<bool> deleteAllByFirstName(string firstName);
    public Task<bool> deleteAllByLastName(string lastName);
    public Task<bool> deleteAll();

    public Task<Customer?> createClient(Customer customer);

    public Task<bool> updateClient(Customer customer);
}