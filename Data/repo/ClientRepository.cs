using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.repo; 

public class ClientRepository : IClientRepository {
    private readonly DataContext context;
    
    public ClientRepository(DataContext context) {
        this.context = context;
    }

    public async Task<List<Customer>> getAll() => await context.clients.ToListAsync();

    public async Task<List<Customer>> getAllByLastName(string lastName) => 
        await context.clients.Where(customer => customer.lastName == lastName).ToListAsync();

    public async Task<List<Customer>> getAllByFirstName(string firstName) => 
        await context.clients.Where(customer => customer.firstName == firstName).ToListAsync();

    public async Task<Customer?> getById(int id) =>
        await context.clients.Where(customer => customer.id == id).FirstOrDefaultAsync();

    public async Task<bool> deleteById(int id) {
        var res = await context.clients.Where(customer => customer.id == id).FirstOrDefaultAsync();

        if (res == null)
            return false;

        context.clients.Remove(res);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByFirstName(string firstName) {
        var clients = await context.clients.Where(customer => customer.firstName == firstName).ToListAsync();

        if (clients.Count == 0)
            return false;
        
        context.clients.RemoveRange(clients);
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> deleteAllByLastName(string lastName) {
        var clients = await context.clients.Where(customer => customer.lastName == lastName).ToListAsync();

        if (clients.Count == 0)
            return false;
        
        context.clients.RemoveRange(clients);
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
        var clients = await getAll();
        context.clients.RemoveRange(clients);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> createClient(Customer customer) {
        await context.clients.AddAsync(customer);
        
        try {
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e.StackTrace);
            return false;
        }
    }

    public async Task<bool> updateClient(Customer customer) {
        var client = await context.clients.Where(c => c.id == customer.id).FirstOrDefaultAsync();

        if (client == null)
            return false;

        client.firstName = customer.firstName;
        client.lastName = customer.lastName;
        
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