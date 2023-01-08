using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IPriceChangeRepository {
    public Task<List<PriceChange>> getAll();
    public Task<List<PriceChange>> getAllByDate(DateTime date);
    public Task<PriceChange?> getById(int id);

    public Task<bool> deleteById(int id);
    public Task<bool> deleteAllByDate(DateTime date);
    public Task<bool> deleteAll();

    public Task<PriceChange?> createPriceChange(PriceChange priceChange);

    public Task<bool> updatePriceChange(PriceChange priceChange);
}