using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Authorize.Options
{
    public class JwtConfigure
    {
        public string Key { get; set; }

        public int ExpirationMinutes { get; set; }
    }
}
