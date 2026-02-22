using Blocks.Redis;
using Journals.Domain.Journals;
using Journals.Grpc;
using ProtoBuf.Grpc;

namespace Journals.Api.Features.Journals;

public class JournalGrpcService(Repository<Journal> _journalRepository) : IJournalService
{
    public async ValueTask<IsEditorAssignedToJournalResponse> IsEditorAssignedToJournalAsync(IsEditorAssignedToJournalRequest request, CallContext context = default)
    {
        var journal = await _journalRepository.GetByIdOrThrowAsync(request.JournalId);

        return new IsEditorAssignedToJournalResponse
        {
            IsAssigned = journal.ChiefEditorId == request.UserId
        };
    }
}
