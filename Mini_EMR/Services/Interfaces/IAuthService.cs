using Mini_EMR.Entities;
using Mini_EMR.Models.Auth;
using Mini_EMR.Models.Users;

namespace Mini_EMR.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseModel?> LoginAsync(LoginRequestModel model);
        Task<List<DoctorModel>> GetDoctorsAsync();
    }
}
