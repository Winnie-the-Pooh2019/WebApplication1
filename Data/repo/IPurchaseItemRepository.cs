using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IPurchaseItemRepository {
    public Task<List<PurchaseItem>> getAll();
    public Task<List<PurchaseItem>> getAllByPurchaseId(int purchaseId);
    public Task<List<PurchaseItem>> getAllByBookId(int bookId);
    public Task<PurchaseItem?> getById(int id);

    public Task<bool> deleteById(int id);
    public Task<bool> deleteAllByPurchaseId(int purchaseId);
    public Task<bool> deleteAllByBookId(int bookId);
    public Task<bool> deleteAll();

    public Task<bool> createPurchaseItem(PurchaseItem purchaseItem);

    public Task<bool> updatePurchaseItem(PurchaseItem purchaseItem);
}