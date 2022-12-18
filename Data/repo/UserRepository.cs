using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public class UserRepository : IUsersRepository {
    private readonly DataContext context;

    public UserRepository(DataContext context) {
        this.context = context;
    }

    public UserDto getByUsername(string username) {
        var user = (from u in context.users
            join ru in context.roleUsers
                on u.id equals ru.usersid
            join r in context.roles
                on ru.usersid equals r.id
            select new UserDto {name = u.name, role = r.name}).FirstOrDefault(u => u.name == username);

        if (user == null)
            throw new NullReferenceException();

        return user;
    }
}