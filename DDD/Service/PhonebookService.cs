using Phonebook.Api.DTOs;
using Phonebook.Api.Service.Abs;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;

namespace Phonebook.Api.Service
{
    public class PhonebookService : IPhoneBookService
    {
        private readonly IContactRepository _contactRepository;
        public PhonebookService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Contact> GetByIdAsync(int id) => await _contactRepository.GetById(id);
        public async Task<List<GetAllDto>> GetAllAsync()
        {
            var data = await _contactRepository.GetAll();
            var result = new List<GetAllDto>();
            foreach (var item in data)
            {
                result.Add(new GetAllDto
                {
                    Id = item.Id,
                    PhoneNumber = item.PhoneNumber,
                });
            }
            return result;
        }
        public async Task<bool> DeleteAsync(int id) => await _contactRepository.Delete(id);
        public async Task Createasync(CreateDTO create)
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
