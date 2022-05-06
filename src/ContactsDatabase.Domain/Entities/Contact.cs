namespace ContactsDatabase.Domain.Entities;

public class Contact : Auditable
{
    public Guid Id { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Middlename { get; set; }
    public string Email { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
    public string Website { get; set; }
    public virtual ICollection<ContactPhone> Phones { get; set; }
    public virtual ICollection<ContactList> Lists { get; set; }
}

public class ContactPhone : Auditable
{
    public Guid ContactId { get; set; }
    public bool IsPrimary { get; set; }
    public string Type { get; set; }
    public string Phone { get; set; }
    public virtual Contact Contact { get; set; }
}

public class ContactList : Auditable
{
    public Guid ContactId { get; set; }
    public Guid ListId { get; set; }
    public virtual Contact Contact { get; set; }
    public virtual List List { get; set; }
}

public class List : Auditable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<ContactList> Contacts { get; set; }
}