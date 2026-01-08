using Blocks.FluentValidation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Submission.Application.Features.UploadFile;

public record UploadManuscriptFileCommand : ArticleCommand
{
    /// <summary>
    /// The asset type of the file.
    /// </summary>
    [Required]
    public AssetType AssetType { get; init; }

    /// <summary>
    /// The file to be uploaded.
    /// </summary>    
    [Required]
    public IFormFile File { get; init; } = null!;

    public override ArticleActionType ActionType => ArticleActionType.UploadAsset;
}

public abstract class UploadManuscriptFileCommand<TUploadFileCommand> : ArticleCommandValidator<UploadManuscriptFileCommand>
{
    protected UploadManuscriptFileCommand()
    {
        RuleFor(x => x.File)
            .NotNullWithMessage();

        // todo - validate filesize and the file extension

        RuleFor(r => r.AssetType).Must(IsAssetTypeAllowed)
            .WithMessage(x => $"{x.AssetType} not allowed");

    }

    private bool IsAssetTypeAllowed(AssetType assetType)
        => AllowedAssetTypes.Contains(assetType);

    public IReadOnlyCollection<AssetType> AllowedAssetTypes => new HashSet<AssetType> { AssetType.Manuscript };
}



