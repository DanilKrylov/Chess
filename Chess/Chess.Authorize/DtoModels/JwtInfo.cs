using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Authorize.DtoModels
{
    public class JwtInfo
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
