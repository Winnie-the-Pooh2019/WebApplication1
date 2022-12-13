using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public interface IUsersRepository {
    public UserDto getByUsername(string username);
}