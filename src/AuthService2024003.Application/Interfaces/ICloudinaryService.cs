namespace AuthService2024003.Application.Interfaces;

public interface ICloudinaryService
{
    Task<string> UploadImageAsync(IFileData fileData);
    Task<bool> DeleteImageAsync(string publicId);
    string GetDefaultAvatarUrl();
    string GetFullImageUrl(string imagePath);
    
}