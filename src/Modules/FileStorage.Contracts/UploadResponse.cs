namespace FileStorage.Contracts;

public record UploadResponse(string FilePath, string FileName, long FileSize, string FileId);
