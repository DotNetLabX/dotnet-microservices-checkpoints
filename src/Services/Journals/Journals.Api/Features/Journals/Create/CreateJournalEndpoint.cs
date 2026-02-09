using Articles.Abstractions;
using Articles.Abstractions.Enums;
using Blocks.Exceptions;
using Blocks.Redis;
using FastEndpoints;
using Journals.Domain.Journals;
using Journals.Domain.Journals.Events;
using Mapster;
using Microsoft.AspNetCore.Authorization;

namespace Journals.Api.Features.Journals.Create;

[Authorize(Roles = Role.EOF)]
[HttpPost("journals")]
[Tags("Journals")]
public class CreateJournalEndpoint(Repository<Journal> _journalRepository, Repository<Editor> _editorRepository) 
    : Endpoint<CreateJournalCommand, IdResponse>
{
    public async override Task HandleAsync(CreateJournalCommand command, CancellationToken ct)
    {
        if (_journalRepository.Collection.Any(j => j.Abbreviation == command.Abbreviation || j.Name == command.Name))
            throw new BadRequestException("Journal with the same name or abbreviation already exists");

        if (!_editorRepository.Collection.Any(e => e.Id == command.ChiefEditorId))
        {
            //todo - get the editor from Auth service
        }

        var journal = command.Adapt<Journal>();

        await _journalRepository.AddAsync(journal);

        await _journalRepository.SaveAllAsync();

        //todo publish the JournalCreated event

        await PublishAsync(new JournalCreated(journal));

        await Send.OkAsync(new IdResponse(journal.Id));
    }
}

