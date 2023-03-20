namespace Chess.GameLogic.Models
{
    public class PlayersMatch
    {
        public bool IsMathced { get;}

        public string WhitePlayerEmail { get;}

        public string BlackPlayerEmail { get;}

        public PlayersMatch(bool isMathced)
        {
            IsMathced = isMathced;
        }

        public PlayersMatch(bool isMathced, string whitePlayerEmail, string blackPlayerEmail) : this(isMathced) 
        {
            WhitePlayerEmail = whitePlayerEmail;
            BlackPlayerEmail = blackPlayerEmail;
        }
    }
}
