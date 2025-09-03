namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class BookCopy
{
    public long Id { get; set; }
    public long BookId { get; set; }
    public Book Book { get; set; } = default!;
    public bool IsAvailable { get; set; } = true;
}
