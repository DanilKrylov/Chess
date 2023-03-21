namespace Chess.GameLogic.Models
{
    public class GameResultInfo
    {
        public bool IsEnded { get; set; }

        public bool IsDraw { get; set; }

        public string WinnerPlayerEmail { get; set; }


        public GameResultInfo(bool isEnded)
        {
            IsEnded = isEnded;
        }

        public GameResultInfo(bool isEnded, bool isDraw) : this(isEnded)
        {
            IsDraw = isDraw;
        }

        public GameResultInfo(bool isEnded, bool isDraw, string winnerPlayerEmail) : this(isEnded, isDraw)
        {
            WinnerPlayerEmail = winnerPlayerEmail;
        }
    }
}
