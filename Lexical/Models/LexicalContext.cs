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

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //   builder.Entity<Word>()
    //       .HasData(
    //           new Word {WordId = 1; }
    //       );
    // }
  }
}