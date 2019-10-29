using Microsoft.EntityFrameworkCore;

namespace Lexical.Models
{
  public class LexicalContext : DbContext
  {
    public LexicalContext(DbContextOptions<LexicalContext> options)
        : base(options)
    {
    }

    public DbSet<Word> Words { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Word>()
          .HasData(
              new Word {WordId = 1, Name = "moist", Rating = 2, RatingCount = 1},
              new Word {WordId = 2, Name = "damp", Rating = 1, RatingCount = 1},
              new Word {WordId = 3, Name = "hug", Rating = 4, RatingCount = 1},
              new Word {WordId = 4, Name = "burnt", Rating = 5, RatingCount = 1},
              new Word {WordId = 5, Name = "vomit", Rating = 1, RatingCount = 1}
          );
    }
  
  }
}