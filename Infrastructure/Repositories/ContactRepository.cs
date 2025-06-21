using Microsoft.EntityFrameworkCore;
using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.Data;
using Phonebook.Infrastructure.Interfaces;

namespace Phonebook.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts != null)
            {
                _context.Contacts.Remove(contacts);
            }
            var result =  await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Update(Contact entity)
        {
            _context.Contacts.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<List<Contact>> GetAll() => await _context.Contacts.ToListAsync();
        public async Task<Contact> GetById(int id) => await _context.Contacts.FindAsync(id);

        
    }
}
