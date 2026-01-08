namespace Submission.Domain.ValueObjects;

public class File
{
    public required string OriginalName { get; init; } = default!;
    public required string FileServerId { get; init; } = default!;

    public required long Size { get; init; }
    public required FileName Name { get; init; }
    public required FileExtension Extension { get; init; } = default!;
}
