using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo;

public class DeliveryRepository : IDeliveryRepository {
    private readonly DataContext context;

    public DeliveryRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Delivery>> getAll() => await context.deliveries.ToListAsync();

    public async Task<List<Delivery>> getAllByBookId(int id) =>
        await context.deliveries.Where(delivery => delivery.bookId == id).ToListAsync();

    public async Task<List<Delivery>> getAllByDeliveryDate(DateTime date) =>
        await context.deliveries.Where(delivery => delivery.deliveryDate == date).ToListAsync();

    public async Task<Delivery?> getById(int id) =>
        await context.deliveries.Where(delivery => delivery.id == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var delivery = await context.deliveries.Where(d => d.id == id).FirstOrDefaultAsync();

        if (delivery == null)
            return false;

        context.deliveries.Remove(delivery);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAll() {
        var deliveries = await getAll();
        context.deliveries.RemoveRange(deliveries);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByBookId(int id) {
        var delivery = await context.deliveries.Where(d => d.bookId == id).ToListAsync();

        if (delivery.Count == 0)
            return false;

        context.deliveries.RemoveRange(delivery);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByDeliveryDate(DateTime date) {
        var delivery = await context.deliveries.Where(d => d.deliveryDate == date).ToListAsync();

        if (delivery.Count == 0)
            return false;

        context.deliveries.RemoveRange(delivery);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<Delivery?> createDelivery(Delivery delivery) {
        try {
            var res = await context.deliveries.AddAsync(delivery);

            await context.SaveChangesAsync();
            return res.Entity;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<bool> updateDelivery(Delivery delivery) {
        var d = await context.deliveries.Where(del => del.id == delivery.id).FirstOrDefaultAsync();

        if (d == null)
            return false;

        d.bookId = delivery.bookId;
        d.deliveryDate = delivery.deliveryDate;
        d.booksCount = delivery.booksCount;
        d.price = delivery.price;
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }
}