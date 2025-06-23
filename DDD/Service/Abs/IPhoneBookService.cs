using Phonebook.Api.DTOs;
using Phonebook.Domain.Entities;

namespace Phonebook.Api.Service.Abs
{
    public interface IPhoneBookService
    {
        Task Createasync(CreateDTO create);
        Task<bool> DeleteAsync(int id);
        Task<List<GetAllDto>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<bool> Update(UpdateDTO updateDto);
    }
}
