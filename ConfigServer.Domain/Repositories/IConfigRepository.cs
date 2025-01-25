namespace ConfigServer.Domain.Repositories
{
    public interface IConfigRepository
    {
        Task<Config> GetByIdAsync(int id); 
        Task<Config> GetByKeyAsync(string key); 
        Task AddAsync(Config config); 
        Task UpdateAsync(Config config); 
        Task DeleteAsync(int id); 
}
