using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public class CategoryRepository : ICategoryRepository {
    private readonly DataContext context;
    
    public CategoryRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Category>> getAll() => await context.categories.ToListAsync();

    public async Task<List<Category>> getAllByName(string name) =>
        await context.categories.Where(category => category.name == name).ToListAsync();

    public async Task<Category?> getById(int id) =>
        await context.categories.Where(category => category.id == id).FirstOrDefaultAsync();

    public async Task<bool> create(Category category) {
        await context.categories.AddAsync(category);

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
        context.categories.RemoveRange(categories);

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
        var categories = await context.categories.Where(category => category.name == name).ToListAsync();

        if (categories.Count == 0)
            return false;
        
        context.categories.RemoveRange(categories);
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
        var res = await context.categories.Where(category => category.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.categories.Remove(res);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> updateCategory(Category category) {
        var categoryDb = await context.categories.Where(c => c.id == category.id).FirstOrDefaultAsync();

        if (categoryDb == null)
            return false;

        categoryDb.name = category.name;
        
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