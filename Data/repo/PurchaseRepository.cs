using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo;

public class PurchaseRepository : IPurchaseRepository {
    private readonly DataContext context;

    public PurchaseRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Purchase>> getAll() => await context.purchases.ToListAsync();

    public async Task<List<Purchase>> getAllByCustomerId(int id) =>
        await context.purchases.Where(purchase => purchase.customerId == id).ToListAsync();

    public async Task<List<Purchase>> getAllByDate(DateTime date) =>
        await context.purchases.Where(purchase => purchase.purchaseDate == date).ToListAsync();

    public async Task<Purchase?> getById(int id) =>
        await context.purchases.Where(purchase => purchase.id == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var res = await context.purchases.Where(purchase => purchase.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.purchases.Remove(res);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByCustomerId(int customerId) {
        var purchases = await context.purchases.Where(purchase => purchase.customerId == customerId).ToListAsync();

        if (purchases.Count == 0)
            return false;

        context.purchases.RemoveRange(purchases);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByDate(DateTime date) {
        var purchases = await context.purchases.Where(purchase => purchase.purchaseDate == date).ToListAsync();

        if (purchases.Count == 0)
            return false;
        
        context.purchases.RemoveRange(purchases);
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
        var purchases = await getAll();
        context.purchases.RemoveRange(purchases);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> createPurchase(Purchase purchase) {
        await context.purchases.AddAsync(purchase);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> updatePurchase(Purchase purchase) {
        var pur = await context.purchases.Where(p => p.id == purchase.id).FirstOrDefaultAsync();

        if (pur == null)
            return false;

        pur.customerId = purchase.customerId;
        pur.purchaseDate = purchase.purchaseDate;
        
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