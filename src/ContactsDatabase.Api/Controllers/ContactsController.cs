using ContactsDatabase.Application.Handlers.Commands.Contact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDatabase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public Task<Guid> CreateContact(CreateContactCommand command) => _mediator.Send(command);
}