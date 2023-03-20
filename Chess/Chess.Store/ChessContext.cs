using Chess.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chess.Store
{
    public class ChessContext : IdentityDbContext<Player>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Piece> PiecesInGames { get; set; }

        public ChessContext(DbContextOptions<ChessContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piece>()
                  .HasKey(model => new { model.GameId, model.PosX, model.PosY });


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Chess;Trusted_Connection=True;");
        }
    }
}
