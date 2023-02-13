using Chess.Authorize.DtoModels;
using Chess.Authorize.Interfaces;
using Chess.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Chess.Authorize.Services
{
    internal class IdentityAuthorizer : IAuthorizer
    {
        private readonly SignInManager<Player> _signInManager;
        private readonly UserManager<Player> _userManager;
        private readonly IJwtService _jwtService;

        public IdentityAuthorizer(SignInManager<Player> signInManager, UserManager<Player> userManager, IJwtService jwtService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthorizeOperationResultDto> TryLoginAsync(LoginDto loginData)
        {
            var player = await _userManager.FindByEmailAsync(loginData.Email);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(new Player { UserName = loginData.Email }, loginData.Password, false);

            if(player is null || !signInResult.Succeeded)
            {
                var result = new AuthorizeOperationResultDto(false);

                result.AddError("password", "login or password entered incorectly");
                return result;
            }

            return new AuthorizeOperationResultDto(true, _jwtService.CreateToken(player));
        }

        public async Task<AuthorizeOperationResultDto> TryRegisterAsync(RegisterDto registerData)
        {
            var player = new Player() { Email = registerData.Email, UserName = registerData.Email };
            var creationResult = await _userManager.CreateAsync(player, registerData.Password);

            if (creationResult.Succeeded)
            {
                return new AuthorizeOperationResultDto(true, _jwtService.CreateToken(player));
            }

            var result = new AuthorizeOperationResultDto(false);
            foreach(var error in creationResult.Errors)
            {
                result.AddError(error.Code, error.Description);
            }

            return result;
        }
    }
}
