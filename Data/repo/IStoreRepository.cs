using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IStoreRepository {
    public Task<List<Store>> getAll();
    public Task<Store?> getById(int id);

    public Task<bool> deleteById(int id);

    public Task<bool> createStore(Store store);

    public Task<bool> updateStore(Store store);
}