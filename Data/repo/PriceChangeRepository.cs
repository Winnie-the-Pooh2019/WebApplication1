using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo;

public class PriceChangeRepository : IPriceChangeRepository {
    private readonly DataContext context;

    public PriceChangeRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<PriceChange>> getAll() => await context.priceChanges.ToListAsync();

    public async Task<List<PriceChange>> getAllByDate(DateTime date) =>
        await context.priceChanges.Where(change => change.priceChanged == date).ToListAsync();

    public async Task<PriceChange?> getById(int id) =>
        await context.priceChanges.Where(change => change.id == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var change = await context.priceChanges.Where(priceChange => priceChange.id == id).FirstOrDefaultAsync();

        if (change == null)
            return false;

        context.priceChanges.Remove(change);
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
        var chs = await context.priceChanges.Where(change => change.priceChanged == date).ToListAsync();

        if (chs.Count == 0)
            return false;

        context.priceChanges.RemoveRange(chs);
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
        var chs = await context.priceChanges.ToListAsync();

        context.priceChanges.RemoveRange(chs);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<PriceChange?> createPriceChange(PriceChange priceChange) {
        try {
            var res = await context.priceChanges.AddAsync(priceChange);

            await context.SaveChangesAsync();
            return res.Entity;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<bool> updatePriceChange(PriceChange priceChange) {
        var price = await context.priceChanges.Where(change => change.id == priceChange.id).FirstOrDefaultAsync();

        if (price == null)
            return false;

        price.priceChanged = priceChange.priceChanged;
        price.newPrice = priceChange.newPrice;
        
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