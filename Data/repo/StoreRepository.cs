using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo;

public class StoreRepository : IStoreRepository {
    private readonly DataContext context;

    public StoreRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Store>> getAll() => await context.stores.ToListAsync();

    public async Task<Store?> getById(int id) =>
        await context.stores.Where(store => store.bookId == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var res = await context.stores.Where(s => s.bookId == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.stores.Remove(res);
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
        var clients = await getAll();
        context.stores.RemoveRange(clients);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<Store?> createStore(Store store) {
        try {
            var res = await context.stores.AddAsync(store);
            
            await context.SaveChangesAsync();
            return res.Entity;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<bool> updateStore(Store store) {
        var s = await context.stores.Where(c => c.bookId == store.bookId).FirstOrDefaultAsync();

        if (s == null)
            return false;

        s.booksCount = store.booksCount;
        s.priceChangeId = store.priceChangeId;
        
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