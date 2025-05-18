using FCxLabs.TechLibraryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess;

public class TechLibraryDbContext : DbContext
{
    public TechLibraryDbContext(DbContextOptions<TechLibraryDbContext> options) : base(options) {}
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
                    .HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId);                  
    }
}
