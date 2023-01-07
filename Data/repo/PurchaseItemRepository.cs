using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public class PurchaseItemRepository : IPurchaseItemRepository {
    private readonly DataContext context;

    public PurchaseItemRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<PurchaseItem>> getAll() => await context.purchaseItems.ToListAsync();

    public async Task<List<PurchaseItem>> getAllByPurchaseId(int purchaseId) =>
        await context.purchaseItems.Where(item => item.purchaseId == purchaseId).ToListAsync();

    public async Task<List<PurchaseItem>> getAllByBookId(int bookId) =>
        await context.purchaseItems.Where(item => item.bookId == bookId).ToListAsync();

    public async Task<PurchaseItem?> getById(int id) =>
        await context.purchaseItems.Where(item => item.id == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var res = await context.purchaseItems.Where(item => item.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.purchaseItems.Remove(res);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByPurchaseId(int purchaseId) {
        var res = await context.purchaseItems.Where(item => item.purchaseId == purchaseId).ToListAsync();

        if (res.Count == 0)
            return false;

        context.purchaseItems.RemoveRange(res);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByBookId(int bookId) {
        var res = await context.purchaseItems.Where(item => item.bookId == bookId).ToListAsync();

        if (res.Count == 0)
            return false;

        context.purchaseItems.RemoveRange(res);
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
        var items = await getAll();
        context.purchaseItems.RemoveRange(items);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> createPurchaseItem(PurchaseItem purchaseItem) {
        await context.purchaseItems.AddAsync(purchaseItem);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> updatePurchaseItem(PurchaseItem purchaseItem) {
        var item = await context.purchaseItems.Where(i => i.id == purchaseItem.id).FirstOrDefaultAsync();

        if (item == null)
            return false;

        item.purchaseId = purchaseItem.purchaseId;
        item.bookId = purchaseItem.bookId;
        item.booksCount = purchaseItem.booksCount;
        item.priceId = purchaseItem.priceId;
        
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