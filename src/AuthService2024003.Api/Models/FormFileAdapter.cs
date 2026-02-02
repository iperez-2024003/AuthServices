using AuthService2024003.Application.Interfaces;

namespace AuthService2024003.Api.Models;

public class FormFileAdapter : IfileData
{
    private readonly IformFile _formFile;
    private byte[]? data;

    public FormFileAdapter(IformFile formFile)
    {
        ArgumenNullException.ThrowIfull(formFile);
        _formFile = formFile;
    }

    public byte[] Data
    {
        get
        {
            if(_data == null)
            {
                using var memoryStream = new MemoryStream();
                _formFile.CopyTo(memoryStream);
                _data = memoryStream.ToArray();

            }
            return _data;
        }
    }

    public string ContentType => _formFile.ContentType;
    public string FileName => _formFile.FileName;
    public long Size => _formFile.Length;

}