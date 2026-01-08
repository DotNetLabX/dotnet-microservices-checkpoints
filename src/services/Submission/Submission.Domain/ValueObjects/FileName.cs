using Blocks.Domain.ValueObjects;
using Submission.Domain.Entities;

namespace Submission.Domain.ValueObjects;

public class FileName : StringValueObject
{
    private FileName(string value) => Value = value;

    public static FileName Create(Asset asset, FileExtension extension)
    {
        var assetName = asset.Name.Value;
        return new FileName($"{assetName}.{extension}");
    }
}
