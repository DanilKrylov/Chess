using Chess.Authorize.DtoModels;
using Chess.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Chess.Authorize.Interfaces
{
    public interface IAuthorizer
    {
        Task<AuthorizeOperationResultDto> TryLoginAsync(LoginDto loginData);

        Task<AuthorizeOperationResultDto> TryRegisterAsync(RegisterDto registerData);
    }
}
