using FCxLabs.TechLibraryAPI.Domain.Enums;

namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class Loan
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; } = default!;
    public int BookCopyId { get; set; }
    public BookCopy BookCopy { get; set; } = default!;
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;
    public int loanTermDays { get; set; } = LoanTerm.STARNDARD;
    public DateTime DueDate => LoanDate.AddDays(loanTermDays);
    public DateTime? ReturnedAt { get; set; }
    public string Status { get; set; } = LoanStatus.ACTIVE;
    public bool IsReturned => ReturnedAt.HasValue;
    public void Return()
    {
        ReturnedAt = DateTime.UtcNow;
    }
}
