using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Authorize.DtoModels
{
    public record RegisterDto(string Email, string Password, string ConfirmPassword);
}
