using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IBookRepository {
    public Task<List<Book>> getAll();
    public Task<List<Book>> getAllByName(string name);
    public Task<List<Book>> getAllByPublisherId(int publisherId);
    public Task<List<Book>> getAllByCategoryId(int categoryId);
    public Task<Book?> getById(int id);
    
    public Task<bool> deleteById(int id);
    public Task<bool> deleteAllByName(string name);
    public Task<bool> deleteAll();
    
    public Task<Book?> createBook(Book book);
    
    public Task<bool> updateBook(Book book);
}