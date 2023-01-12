using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Dto;
using WebApplication1.Data.Models;
using WebApplication1.Utils;

namespace WebApplication1.Data.repo;

public class UserRepository : IUsersRepository {
    private DataContext context;

    public UserRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<User>> getAll() => await context.users.ToListAsync();

    public async Task<User?> getByUsername(string username) {
        var user = await context.users.Where(u => u.login == username).FirstOrDefaultAsync();

        return user;
    }

    public async Task<User?> getById(int id) =>
        await context.users.Where(category => category.id == id).FirstOrDefaultAsync();

    public async Task<User?> createUser(SignUpDto signUpDto) {
        var user = new User {
            role = signUpDto.role,
            password = CryptEncoder.hashPassword(signUpDto.password, out var salt),
            firstName = signUpDto.firstName,
            lastName = signUpDto.lastName,
            login = signUpDto.login,
            salt = salt
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

    public async Task<bool> updateUser(SignUpDto signUpDto) {
        User? user = await context.users.FirstOrDefaultAsync(u => signUpDto.login == u.login);

        if (user == null)
            return false;

        user.role = signUpDto.role;
        user.password = CryptEncoder.hashPassword(signUpDto.password, out var salt);
        user.firstName = signUpDto.firstName;
        user.lastName = signUpDto.lastName;
        user.login = user.login;
        user.salt = salt;

        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> updateUser(User user) {
        var savedUser = await context.users.FirstOrDefaultAsync(u => u.login == user.login);

        if (savedUser == null) return false;

        try {
            savedUser.password = CryptEncoder.hashPassword(user.password, out var salt);
            savedUser.salt = salt;

            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteById(int id) {
        var res = await context.users.Where(category => category.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.users.Remove(res);
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