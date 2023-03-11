using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chess.Data.Models
{
    public class Player : IdentityUser
    {
        public int Rating { get; set; }
    }
}
