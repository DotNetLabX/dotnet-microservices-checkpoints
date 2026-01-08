namespace Submission.Application.Features.UploadFile;

public class UploadManuscriptFileCommandHandler(ArticleRepository _articleRepository, Repository<AssetTypeDefinition> _assetTypeRepository) : IRequestHandler<UploadManuscriptFileCommand, IdResponse>
{
    public async Task<IdResponse> Handle(UploadManuscriptFileCommand command, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetByIdOrThrowAsync(command.ArticleId);

        var assetType = await _assetTypeRepository.FindByIdAsync((int) command.AssetType);

        Asset asset = null;

        if(!assetType.AllowMultipleAssets)
            asset = article.Assets.SingleOrDefault(e => e.Type == assetType.Id);

        if (asset is null)
            asset = article.CreateAsset(assetType);


        //todo - upload the file


        await _articleRepository.SaveChangesAsync();
        return new IdResponse(asset.Id);
    }
}
