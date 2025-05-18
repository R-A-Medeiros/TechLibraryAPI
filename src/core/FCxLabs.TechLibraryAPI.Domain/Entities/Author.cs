namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birth { get; set; }
    public string? Nationality { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}
