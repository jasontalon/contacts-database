namespace ContactsDatabase.Domain.Entities;

public class ContactPhone : Auditable
{
    public Guid ContactId { get; set; }
    public Guid PhoneId { get; set; }
    public bool IsPrimary { get; set; }
    
    public Contact Contact { get; set; }
    public Phone Phone { get; set; }
}