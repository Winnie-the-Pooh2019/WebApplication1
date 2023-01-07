using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface ICategoryRepository {
    public Task<List<Category>> getAll();
    public Task<List<Category>> getAllByName(string name);
    public Task<Category?> getById(int id);

    public Task<bool> create(Category category);

    public Task<bool> deleteAll();
    public Task<bool> deleteAllByName(string name);
    public Task<bool> deleteById(int id);

    public Task<bool> updateCategory(Category category);
}