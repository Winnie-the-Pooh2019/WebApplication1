using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IPublisherRepository {
    public Task<List<Publisher>> getAll();
    public Task<List<Publisher>> getAllByName(string name);
    public Task<Publisher?> getById(int id);
    
    public Task<Publisher?> createPublisher(Publisher publisher);

    public Task<bool> deleteAll();
    public Task<bool> deleteAllByName(string name);
    public Task<bool> deleteById(int id);

    public Task<bool> updatePublisher(Publisher publisher);
}