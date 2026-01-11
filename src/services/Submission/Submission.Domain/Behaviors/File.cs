using FileStorage.Contracts;

namespace Submission.Domain.ValueObjects;

public partial class File
{
    private File(){ }

    internal static File CreateFile(UploadResponse uploadResponse, Asset asset, AssetTypeDefinition assetType)
    {
        var fileName = Path.GetFileName(uploadResponse.FilePath);
        var extension = FileExtension.FromFileName(fileName, assetType);

        var file = new File()
        {
            Name = FileName.Create(asset, extension),
            Extension = extension,
            OriginalName = fileName,
            Size = uploadResponse.FileSize,
            FileServerId = uploadResponse.FileId
        };

        return file;
    }
}
