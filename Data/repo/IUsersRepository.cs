using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IUsersRepository {
    public Task<UserDto?> getByUsername(string username);
    public Task<User?> createUser(UserDto userDto);
    public Task<bool> updateUser(UserDto userDto);
}