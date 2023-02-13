using Microsoft.AspNetCore.Identity;


namespace Chess.Data.Models
{
    public class Player : IdentityUser
    {
        public int Rating { get; set; }
    }
}
