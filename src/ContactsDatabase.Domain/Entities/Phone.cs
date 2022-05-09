namespace ContactsDatabase.Domain.Entities;

public class Phone : Auditable
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string PhoneNumber { get; set; }
}