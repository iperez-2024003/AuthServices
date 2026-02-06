using AuthService2024003.Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace AuthService2024003.Application.Services;

public class CloudinaryService(IConfiguration configuration) : ICloudinaryService
{
    private readonly Cloudinary _cloudinary = new(new Account(
        configuration["CloudinarySettings:CloudName"],
        configuration["CloudinarySettings:ApiKey"],
        configuration["CloudinarySettings:ApiSecret"]
    ));

   public async Task<string> UploadImageAsync(IFileData imageFile)
    {
        try
        {
            using var stream = new MemoryStream(imageFile.Data);

            var folder = configuration["CloudinarySettings:Folder"]
                        ?? "auth_service/profiles";

            // Usamos imageFile.FileName que viene dentro del objeto de la interfaz
            var cleanName = Path.GetFileNameWithoutExtension(imageFile.FileName);

            var publicId = $"{folder}/{cleanName}";

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, stream),
                PublicId = publicId,
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                throw new InvalidOperationException($"Error uploading image: {uploadResult.Error.Message}");

            // Retornamos el formato esperado
            return $"v{uploadResult.Version}/{uploadResult.PublicId}.{uploadResult.Format}";
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to upload image to Cloudinary: {ex.Message}", ex);
        }
    }

    public async Task<bool> DeleteImageAsync(string fileName)
    {
        try
        {
            var folder = configuration["CloudinarySettings:Folder"]
                        ?? "auth_service/profiles";

            var withoutVersion = fileName.Contains('/')
                ? string.Join('/', fileName.Split('/').Skip(1))
                : fileName;

            var withoutExtension = Path.Combine(
                Path.GetDirectoryName(withoutVersion) ?? "",
                Path.GetFileNameWithoutExtension(withoutVersion)
            ).Replace("\\", "/");


            var deleteParams = new DelResParams
            {
                PublicIds = [withoutExtension]
            };

            var result = await _cloudinary.DeleteResourcesAsync(deleteParams);
            return result.Deleted?.ContainsKey(withoutExtension) == true;
        }
        catch
        {
            return false;
        }
    }


    public string GetDefaultAvatarUrl()
    {
        var defaultFile = configuration["CloudinarySettings:DefaultAvatarPath"]
                        ?? "default-avatar.png";

        return defaultFile;
    }

    public string GetFullImageUrl(string fileName)
    {
        var baseUrl = configuration["CloudinarySettings:BaseUrl"]
                    ?? "https://res.cloudinary.com/dqx1m6nxh/image/upload/";

        if (string.IsNullOrWhiteSpace(fileName))
        {
            var defaultFile = configuration["CloudinarySettings:DefaultAvatarPath"]
                            ?? "default-avatar.png";
            return $"{baseUrl}{defaultFile}";
        }

        return $"{baseUrl}w_400,h_400,c_fill,g_auto,q_auto,f_auto/{fileName}";
    }

}
