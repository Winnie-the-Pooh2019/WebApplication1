using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IUsersRepository {
    public Task<List<User>> getAll();
    public Task<User?> getByUsername(string username);
    public Task<User?> getById(int id);
    public Task<User?> createUser(SignUpDto signUpDto);
    public Task<bool> updateUser(SignUpDto signUpDto);
    public Task<bool> updateUser(User user);
    public Task<bool> deleteById(int id);
}