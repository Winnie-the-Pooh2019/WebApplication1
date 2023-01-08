using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo;

public class BookRepository : IBookRepository {
    private DataContext context;

    public BookRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Book>> getAll() {
        var books = await context.books.ToListAsync();
        return new(books);
    }

    public async Task<List<Book>> getAllByName(string name) =>
        new(await context.books.Where(book => book.name == name).ToListAsync());

    public async Task<List<Book>> getAllByPublisherId(int publisherId) => new(await context.books
        .Include(book => book.publisher).Where(book => book.publisherId == publisherId).ToListAsync());

    public async Task<List<Book>> getAllByCategoryId(int categoryId) => new(await context.books
        .Include(book => book.category)
        .Where(book => book.categoryId == categoryId).ToListAsync());

    public async Task<Book?> getById(int id) => await context.books.Where(book => book.id == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var res = await context.books.Where(book => book.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.books.Remove(res);
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
        var books = await context.books.Where(book => book.name == name).ToListAsync();

        if (books.Count == 0)
            return false;
        
        context.books.RemoveRange(books);
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
        var books = await getAll();
        context.books.RemoveRange(books);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<Book?> createBook(Book book) {
        try {
            var res = await context.books.AddAsync(book);
            await context.SaveChangesAsync();
            return res.Entity;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public async Task<bool> updateBook(Book book) {
        var bookDb = await context.books.Where(b => b.id == book.id).FirstOrDefaultAsync();

        if (bookDb == null)
            return false;

        bookDb.categoryId = book.categoryId;
        bookDb.publisherId = book.publisherId;
        bookDb.name = book.name;
        
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