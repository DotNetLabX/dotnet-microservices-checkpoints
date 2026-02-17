using Blocks.Redis;
using Redis.OM.Modeling;

namespace Journals.Domain.Journals;

[Document(StorageType = StorageType.Json)]
public class Journal : Entity
{
    [Searchable]
    public required string Name { get; set; }
    [Indexed]
    public required string Abbreviation { get; set; }

    [Searchable]
    public required string Description { get; set; }
    public required string ISSN { get; set; } //unique ID in the publishing world
    
    public int ChiefEditorId { get; set; }

    [Indexed(JsonPath ="$.Name")]
    public List<Section> Sections { get; set; } = new();

    public int ArticlesCount { get; set; }
}
