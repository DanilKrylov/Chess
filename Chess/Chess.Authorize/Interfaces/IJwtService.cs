using Chess.Authorize.DtoModels;
using Chess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Authorize.Interfaces
{
    internal interface IJwtService
    {
        string CreateToken(Player user);
    }
}
