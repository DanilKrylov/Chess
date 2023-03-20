using Chess.Authorize.DtoModels;
using Microsoft.AspNetCore.Identity;

namespace Chess.Authorize.Interfaces
{
    public interface IAuthorizer
    {
        Task<AuthorizeOperationResult> TryLoginAsync(LoginDto loginData);

        Task<AuthorizeOperationResult> TryRegisterAsync(RegisterDto registerData);
    }
}
