using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public class PublisherRepository : IPublisherRepository {
    private readonly DataContext context;
    
    public PublisherRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Publisher>> getAll() => await context.publishers.ToListAsync();

    public async Task<List<Publisher>> getAllByName(string name) =>
        await context.publishers.Where(category => category.name == name).ToListAsync();

    public async Task<Publisher?> getById(int id) =>
        await context.publishers.Where(category => category.id == id).FirstOrDefaultAsync();

    public async Task<bool> createPublisher(Publisher publisher) {
        await context.publishers.AddAsync(publisher);

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
        var categories = await getAll();
        context.publishers.RemoveRange(categories);

        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByName(string name) {
        var categories = await context.publishers.Where(category => category.name == name).ToListAsync();

        if (categories.Count == 0)
            return false;
        
        context.publishers.RemoveRange(categories);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteById(int id) {
        var res = await context.publishers.Where(category => category.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.publishers.Remove(res);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> updatePublisher(Publisher publisher) {
        var categoryDb = await context.publishers.Where(c => c.id == publisher.id).FirstOrDefaultAsync();

        if (categoryDb == null)
            return false;

        categoryDb.name = publisher.name;
        
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