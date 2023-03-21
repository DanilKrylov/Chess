using Chess.Data.Models;

namespace Chess.Authorize.Interfaces
{
    internal interface IJwtService
    {
        string CreateToken(Player user);
    }
}
