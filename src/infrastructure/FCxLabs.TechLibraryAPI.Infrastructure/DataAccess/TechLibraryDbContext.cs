using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FCxLabs.TechLibraryAPI.Infrastructure.DataAccess;

public class TechLibraryDbContext : DbContext
{
    public TechLibraryDbContext(DbContextOptions<TechLibraryDbContext> options) : base(options) {}
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<LogAction> Logs { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Book>()
        //            .HasOne(b => b.Author)
        //            .WithMany(a => a.Books)
        //            .HasForeignKey(b => b.AuthorId)
        //            .OnDelete(DeleteBehavior.Restrict);


        //modelBuilder.Entity<Book>()
        //            .HasMany(b => b.Copies)
        //            .WithOne(c => c.Book)
        //            .HasForeignKey(c => c.BookId)
        //            .OnDelete(DeleteBehavior.Cascade);



        //modelBuilder.Entity<BookCopy>()
        //            .HasOne(c => c.CurrentLoan)
        //            .WithOne(l => l.BookCopy)
        //            .HasForeignKey<Loan>(l => l.BookCopyId)
        //            .OnDelete(DeleteBehavior.Restrict);


        //modelBuilder.Entity<User>()
        //            .HasMany(u => u.Loans)
        //            .WithOne(l => l.User)
        //            .HasForeignKey(l => l.UserId)
        //            .OnDelete(DeleteBehavior.Cascade);
 
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

    
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Copies)
            .WithOne(c => c.Book)
            .HasForeignKey(c => c.BookId)
            .OnDelete(DeleteBehavior.Cascade);

  
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.BookCopy)
            .WithMany() // histórico, não há navegação inversa
            .HasForeignKey(l => l.BookCopyId)
            .OnDelete(DeleteBehavior.Restrict);

  
        modelBuilder.Entity<User>()
            .HasMany(u => u.Loans)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Cascade);

    
        modelBuilder.Entity<BookCopy>()
            .HasIndex(c => new { c.BookId, c.IsAvailable });

        modelBuilder.Entity<Loan>()
            .HasIndex(l => new { l.BookCopyId, l.Status });

        modelBuilder.Entity<Loan>()
            .HasIndex(l => new { l.UserId, l.Status });

    }
}
