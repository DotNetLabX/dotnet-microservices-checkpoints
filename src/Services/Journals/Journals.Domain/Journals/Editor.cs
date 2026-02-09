using Blocks.Redis;
using Redis.OM.Modeling;

namespace Journals.Domain.Journals;

[Document(StorageType = StorageType.Hash)]

public class Editor : Entity
{
    [Indexed]
    public required string FullName { get; set; }
    public required string Affiliation { get; set; }

    [Indexed]
    public int PersonId { get; set; }
}
