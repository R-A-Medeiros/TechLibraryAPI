using FCxLabs.TechLibraryAPI.Domain.Entities;
using FCxLabs.TechLibraryAPI.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

public static class DatabaseSeed
{
    public static async Task SeedAsync(TechLibraryDbContext context)
    {
        // Garante idempotência
        if (await context.Authors.AnyAsync())
            return;

        // ========================
        // 5 AUTORES
        // ========================
        var authors = new List<Author>
        {
            new Author { Name = "Robert C. Martin" },
            new Author { Name = "Martin Fowler" },
            new Author { Name = "Eric Evans" },
            new Author { Name = "Kent Beck" },
            new Author { Name = "Joshua Bloch" }
        };

        context.Authors.AddRange(authors);
        await context.SaveChangesAsync();

        // ========================
        // 5 LIVROS
        // ========================
        var books = new List<Book>
        {
            new Book
            {
                Title = "Clean Code",
                AuthorId = authors[0].Id,
                PublicationYear = new DateOnly(2008, 8, 1),
                Genre = "Tech"
            },
            new Book
            {
                Title = "Refactoring",
                AuthorId = authors[1].Id,
                PublicationYear = new DateOnly(1999, 8, 1),
                Genre = "Tech"
            },
            new Book
            {
                Title = "Domain-Driven Design",
                AuthorId = authors[2].Id,
                PublicationYear = new DateOnly(2003, 8, 1),
                Genre = "Tech"
            },
            new Book
            {
                Title = "Test Driven Development",
                AuthorId = authors[3].Id,
                PublicationYear = new DateOnly(2002, 8, 1),
                Genre = "Tech"
            },
            new Book
            {
                Title = "Effective Java",
                AuthorId = authors[4].Id,
                PublicationYear = new DateOnly(2001, 8, 1),
                Genre = "Tech"
            }
        };

        context.Books.AddRange(books);
        await context.SaveChangesAsync();     

        // ========================
        // 4️⃣ CÓPIAS (5 POR LIVRO)
        // ========================
        var copies = new List<BookCopy>();

        foreach (var book in books)
        {
            for (int i = 0; i < 5; i++)
            {
                copies.Add(new BookCopy
                {
                    BookId = book.Id
                });
            }
        }

        context.BookCopies.AddRange(copies);
        await context.SaveChangesAsync();

      
    }
}
