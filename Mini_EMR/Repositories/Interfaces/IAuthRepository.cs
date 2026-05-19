using Mini_EMR.Entities;

namespace Mini_EMR.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetUsernameAsync(string username);
        Task<List<User>> GetDoctorsAsync();
        Task<User?> GetByIdAsync(int id);
    }
}
