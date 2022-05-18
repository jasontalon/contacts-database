using ContactsDatabase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public interface IApplicationDbContext 
{
    DbSet<Contact> Contacts { get; }
    //DbSet<ContactPhone> ContactPhones { get; }
    //DbSet<ContactList> ContactLists { get; }
    //DbSet<List> Lists { get; }
    //DbSet<Phone> Phones { get; set; }
}