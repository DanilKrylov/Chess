using Chess.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Store
{
    public class ChessContext : IdentityDbContext<Player>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<PieceInGame> PiecesInGames { get; set; }

        public ChessContext(DbContextOptions<ChessContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PieceInGame>()
                  .HasKey(model => new { model.GameId, model.HorizontalPosition, model.VerticalPosition });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Chess;Trusted_Connection=True;");
        }
    }
}
