using ContactsDatabase.Application.Handlers.Commands;
using ContactsDatabase.Application.Handlers.Queries.Contacts;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDatabase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator) => _mediator = mediator;

    [HttpGet("{id}")]
    public Task<GetContactByIdQueryResponse> GetContactById(Guid id) =>
        _mediator.Send(new GetContactByIdQuery {Id = id});
    
    [HttpPost]
    public Task<Guid> CreateContact(CreateContactCommand command) => _mediator.Send(command);

    [HttpPatch("{id}")]
    public Task UpdateContact(Guid id, [FromBody] JsonPatchDocument<UpdateContactDto> patch) =>
        _mediator.Send(new UpdateContactCommand {Id = id, Patch = patch});

    [HttpDelete("{id}")]
    public Task DeleteContact(Guid id) => _mediator.Send(new DeleteContactCommand {Id = id});
}