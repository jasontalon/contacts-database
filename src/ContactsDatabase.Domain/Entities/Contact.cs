namespace ContactsDatabase.Domain.Entities;

public class Contact : Auditable
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Surname { get; set; }
    public string? Middlename { get; set; }
    public string? Email { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Notes { get; set; }
    public string? Website { get; set; }
    //public ICollection<ContactPhone> Phones { get; set; }
    //public ICollection<ContactList> Lists { get; set; }
}