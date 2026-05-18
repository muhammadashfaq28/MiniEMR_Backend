using Microsoft.AspNetCore.Identity;
using Mini_EMR.Entities;
using Mini_EMR.Mappings;
using Mini_EMR.Models.Auth;
using Mini_EMR.Repositories.Interfaces;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }



        public async Task<LoginResponseModel?> LoginAsync(LoginRequestModel model)
        {
            var user = await _authRepository.GetUsernameAsync(model.Username);

            if (user == null) {
                return null;
            }

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user, 
                user.PasswordHash, 
                model.Password
                );

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var token = "ThisIsAshfaqInternSuperJWtKey12345678901";

            var response = AuthMapper.ToLoginResponseModel(user, token);

            return response;

        }
    }
}
