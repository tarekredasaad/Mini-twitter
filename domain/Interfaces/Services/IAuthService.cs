using Domain.DTO;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ResultDTO> Register(UserDTO userDTO);
        Task<ResultDTO> Login(UserDTO userDTO);
        Task<ResultDTO> Logout( );
        //ResultDTO GetAllUsers();
        Task<ResultDTO> DeleteUser(string emial);
        bool Authenticate_User {  get; }
        bool CheckAuthenticateUser(string username, string password);
        void SignOut();
    }
}
