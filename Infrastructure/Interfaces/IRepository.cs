namespace Phonebook.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);
        public Task Create(T entity);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
    }
}
