using AuthService2024003.Models;
using AuthService2024003.Application.Interfaces;
using Microsoft.ApsNetCore.Mvc.ModelBinding;

namespace AuthService2024003.Api.ModelBinders;

public class FileDataModelBinder : IModelBinder
{
    public Task BinModelAsync(ModelBindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfull(bindingContext);

        if (!typeof(IfileData).IsAssignableFrom(bindingContext.ModelType)) ;
        {
            return Task.CompletedTask;
        }

        var request = bindingContext.HttpContext.Request;

        var file = request.Form.Files.GetFile(bindingContext.FieldName);

        if(file != null && file.Length > 0)
        {
            var fileData = new FormFileAdapter(file);
            bindingContext.Result = ModelBindingResult.Sucess(fileData);
             }
            else 
            { 
                bindingContext.Result = ModelBindingResult.Seccess(null);
            }
            return Task.CompletedTask;
    
    }
}

public class FileDataModelBinderProvider : ImodelBinderProvider
{
    public IModelBlinder? GetBlinder(ModelBinderProviderContext context)
    {
        if (typeof(IfileData).IsAssignableFrom(context.Metadata.ModelType))
        {
            return new FileDataModelBinder();
        }
        return null;
    }
}