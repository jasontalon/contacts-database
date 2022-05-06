namespace ContactsDatabase.Domain.Entities;

public abstract class Auditable
{
    public DateTimeOffset CreatedAtUtc { get; set; }
    public DateTimeOffset UpdatedAtUtc { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
}