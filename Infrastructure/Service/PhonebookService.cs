using Phonebook.Domain.Entities;
using Phonebook.Infrastructure.DTOs;
using Phonebook.Infrastructure.Interfaces;

namespace Phonebook.Application.Service
{
    public class PhonebookService
    {
        private readonly IContactRepository _contactRepository;
        public PhonebookService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Contact> GetById(int id) => await _contactRepository.GetById(id);
        public async Task<List<Contact>> GetAll() => await _contactRepository.GetAll();
        public async Task<bool> Delete(int id) => await _contactRepository.Delete(id);
        public async Task Create(CreateDTO create)
        {
            var contact = new Contact();
            contact.PhoneNumber = create.PhoneNumber;
            await _contactRepository.Create(contact);
        }
        public async Task<bool> Update(UpdateDTO updateDto)
        {
            if (updateDto.Id == 0) 
            {
                return false; 
            }

            var contact = new Contact
            {
                Id = updateDto.Id, 
                PhoneNumber = updateDto.PhoneNumber
            };
            return await _contactRepository.Update(contact);
        }

    }
}
