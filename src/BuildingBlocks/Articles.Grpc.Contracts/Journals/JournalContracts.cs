using ProtoBuf;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Journals.Grpc;

[ServiceContract]
public interface IJournalService
{
    [OperationContract]
    ValueTask<IsEditorAssignedToJournalResponse> IsEditorAssignedToJournalAsync(IsEditorAssignedToJournalRequest request, CallContext context = default);
}

[ProtoContract]
public class IsEditorAssignedToJournalRequest
{
    [ProtoMember(1)]
    public int JournalId { get; set; } = default!;

    [ProtoMember(2)]
    public int UserId { get; set; } = default!;
}

[ProtoContract]
public class IsEditorAssignedToJournalResponse
{
    [ProtoMember(1)]
    public bool IsAssigned { get; set; }
}
