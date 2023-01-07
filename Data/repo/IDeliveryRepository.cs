using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IDeliveryRepository {
    public Task<List<Delivery>> getAll();
    public Task<List<Delivery>> getAllByBookId(int id);
    public Task<List<Delivery>> getAllByDeliveryDate(DateTime date);
    public Task<Delivery?> getById(int id);

    public Task<bool> deleteById(int id);
    public Task<bool> deleteAllByBookId(int id);
    public Task<bool> deleteAllByDeliveryDate(DateTime date);

    public Task<bool> createDelivery(Delivery delivery);

    public Task<bool> updateDelivery(Delivery delivery);
}