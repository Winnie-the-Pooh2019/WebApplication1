using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo;

public class UserRepository : IUsersRepository {
    private readonly DataContext context;

    public UserRepository(DataContext context) {
        this.context = context;
    }

    public async Task<UserDto?> getByUsername(string username) {
        var user = await (from u in context.users
                select new UserDto { login = u.loginName, role = u.role.ToString() })
            .FirstOrDefaultAsync(dto => dto.login == username);

        return user;
    }

    public async Task<User?> createUser(UserDto userDto) {
        // Role? role = await 
        //     (from r in context.roles
        //     select new Role() { name = r.name }).FirstOrDefaultAsync(role1 => role1.name == userDto.role);
        //
        // if (role == null)
        //     return null;

        User user = new User {
            role = userDto.role,
            password = userDto.password,
            firstName = userDto.firstName,
            lastName = userDto.lastName,
            loginName = userDto.login
        };

        try {
            var res = await context.users.AddAsync(user);
            await context.SaveChangesAsync();
            return res.Entity;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<bool> updateUser(UserDto userDto) {
        User? user = await context.users.FirstOrDefaultAsync(u => userDto.login == u.loginName);

        if (user == null)
            return false;

        user.role = userDto.role;
        user.password = userDto.password;
        user.firstName = userDto.firstName;
        user.lastName = userDto.lastName;
        user.loginName = user.loginName;

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