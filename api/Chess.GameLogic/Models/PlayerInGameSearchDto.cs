namespace Chess.GameLogic.Models
{
    internal class PlayerInGameSearchDto
    {
        public string Email { get; set; }

        public int Rating { get; set; }

        public int SecondsInSearching { get; set; }

        public PlayerInGameSearchDto(string email, int rating) 
        {
            Email = email;
            Rating = rating;
        }
    }
}
