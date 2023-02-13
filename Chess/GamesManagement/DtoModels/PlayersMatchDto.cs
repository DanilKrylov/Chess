using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.DtoModels
{
    public class PlayersMatchDto
    {
        public bool IsMathced { get;}

        public string WhitePlayerEmail { get;}

        public string BlackPlayerEmail { get;}

        public PlayersMatchDto(bool isMathced)
        {
            IsMathced = isMathced;
        }

        public PlayersMatchDto(bool isMathced, string whitePlayerEmail, string blackPlayerEmail) : this(isMathced) 
        {
            WhitePlayerEmail = whitePlayerEmail;
            BlackPlayerEmail = blackPlayerEmail;
        }
    }
}
