using Mini_EMR.Entities;
using Mini_EMR.Models.Auth;

namespace Mini_EMR.Mappings
{
    public static class AuthMapper
    {
        public static LoginResponseModel ToLoginResponseModel(
            User user,
            string token)
        {
            return new LoginResponseModel
            {
                Token = token,
                Username = user.Username,
                FullName = user.FullName,
                Role = user.Role,
                Specialization = user.Specialization
            };
        }
    }
}