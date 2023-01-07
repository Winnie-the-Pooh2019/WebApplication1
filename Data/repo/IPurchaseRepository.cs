using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IPurchaseRepository {
    public Task<List<Purchase>> getAll();
    public Task<List<Purchase>> getAllByCustomerId(int id);
    public Task<List<Purchase>> getAllByDate(DateTime date);
    public Task<Purchase?> getById(int id);
    
    public Task<bool> deleteById(int id);
    public Task<bool> deleteAllByCustomerId(int customerId);
    public Task<bool> deleteAllByDate(DateTime date);
    public Task<bool> deleteAll();

    public Task<bool> createPurchase(Purchase purchase);

    public Task<bool> updatePurchase(Purchase purchase);
}