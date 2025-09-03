using FCxLabs.TechLibraryAPI.Domain.Enums;

namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class Loan
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } = default!;
    public long BookCopyId { get; set; }
    public BookCopy BookCopy { get; set; } = default!;
    public DateTime BorrowedAt { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnedAt { get; set; }
    public string Status { get; set; } = LoanStatus.ACTIVE;
}
