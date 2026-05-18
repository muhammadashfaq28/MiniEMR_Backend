using Mini_EMR.Entities;
using Mini_EMR.Models.Auth;

namespace Mini_EMR.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseModel?> LoginAsync(LoginRequestModel model);
    }
}
