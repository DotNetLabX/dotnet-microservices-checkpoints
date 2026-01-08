using Articles.Abstractions.Enums;
using Blocks.Domain.ValueObjects;

namespace Submission.Domain.ValueObjects;

public class AssetName : StringValueObject
{
    private AssetName(string value) => Value = value;

    public static AssetName FromAssetType(AssetTypeDefinition assetType)
        => new AssetName(assetType.Name.ToString());
}
