namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class BookCopy
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public bool IsAvailable { get; set; } = true;

    //public Loan? CurrentLoan { get; private set; }

    public void MarkAsLoaned(Loan loan)
    {
        IsAvailable = false;
    }

    public void MarkAsReturned()
    {
        IsAvailable = true;
        //CurrentLoan = null;
    }
}
