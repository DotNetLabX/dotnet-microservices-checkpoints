using Blocks.Domain.Entities;

namespace Submission.Domain.Entities;

public partial class Journal : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }


    private readonly List<Article> _articles = new();
    public IReadOnlyList<Article> Articles => _articles.AsReadOnly();
}

