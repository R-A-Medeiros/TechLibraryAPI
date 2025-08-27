namespace FCxLabs.TechLibraryAPI.Domain.Entities;

public class LogAction
{
    public int Id { get; set; }
    public string Entity { get; set; } = string.Empty; // "Book" ou "Author"
    public string Action { get; set; } = string.Empty; // "Create", "Update", "Delete"
    public long UserId { get; set; }               // quem fez
    public int? EntityId { get; set; }                // Id do registro afetado
    public string? Payload { get; set; }              // dados extras (json simples)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
