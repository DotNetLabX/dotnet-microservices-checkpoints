namespace Submission.Domain.Entities;

public partial class Asset
{
    private Asset() {/* use factory method*/}

    internal static Asset Create(Article article, AssetTypeDefinition type)
    {
        return new Asset()
        {
            ArticleId = article.Id,
            Article = article,
            Name = AssetName.FromAssetType(type),
            Type = type.Name
        };
    }
}
