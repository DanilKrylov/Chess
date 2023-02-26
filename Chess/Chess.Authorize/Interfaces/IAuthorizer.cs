using Chess.Authorize.DtoModels;
using Chess.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Chess.Authorize.Interfaces
{
    public interface IAuthorizer
    {
        Task<AuthorizeOperationResult> TryLoginAsync(LoginDto loginData);

        Task<AuthorizeOperationResult> TryRegisterAsync(RegisterDto registerData);
    }
}
