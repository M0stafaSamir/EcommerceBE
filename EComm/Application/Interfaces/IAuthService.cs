using EComm.API.DTOs;

namespace EComm.Application.Interfaces
{
    public interface IAuthService
    {
        bool IsAuthenticated { get; }
        public Task<string> login(string email, string password);
        public Task<bool> logout();
        public Task<string> register(RegisterDTO registerDTO);
    }
}
