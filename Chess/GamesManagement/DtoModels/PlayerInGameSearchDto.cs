using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesManagement.DtoModels
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
