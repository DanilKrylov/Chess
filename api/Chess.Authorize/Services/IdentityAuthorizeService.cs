using Chess.Authorize.DtoModels;
using Chess.Authorize.Interfaces;
using Chess.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Chess.Authorize.Services
{
    internal class IdentityAuthorizeService : IAuthorizer
    {
        private readonly SignInManager<Player> _signInManager;
        private readonly UserManager<Player> _userManager;
        private readonly IJwtService _jwtService;

        public IdentityAuthorizeService(SignInManager<Player> signInManager, UserManager<Player> userManager, IJwtService jwtService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<AuthorizeOperationResult> TryLoginAsync(LoginDto loginData)
        {
            var player = await _userManager.FindByEmailAsync(loginData.Email);

            if(player is null || !(await _signInManager.CheckPasswordSignInAsync(player, loginData.Password, false)).Succeeded)
            {
                var result = new AuthorizeOperationResult(false);

                result.AddError("password", "login or password entered incorectly");
                return result;
            }

            return new AuthorizeOperationResult(true, _jwtService.CreateToken(player));
        }

        public async Task<AuthorizeOperationResult> TryRegisterAsync(RegisterDto registerData)
        {
            var player = new Player() { Email = registerData.Email, UserName = registerData.Email };
            var creationResult = await _userManager.CreateAsync(player, registerData.Password);

            if (creationResult.Succeeded)
            {
                return new AuthorizeOperationResult(true, _jwtService.CreateToken(player));
            }

            var result = new AuthorizeOperationResult(false);
            foreach(var error in creationResult.Errors)
            {
                result.AddError(error.Code, error.Description);
            }

            return result;
        }
    }
}
