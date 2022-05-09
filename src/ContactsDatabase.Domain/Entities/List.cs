namespace ContactsDatabase.Domain.Entities;

public class List : Auditable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<ContactList> Contacts { get; set; }
}