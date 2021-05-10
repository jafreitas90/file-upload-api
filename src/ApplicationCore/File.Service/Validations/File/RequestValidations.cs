using System.IO;
using File.Service.Models.Request.File;
using File.Service.Utils;

namespace File.Service.Validations.File
{
    public static class RequestValidations
    {
        public static void Validate(this UploadFileRequest request)
        {
            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType))
            {
                throw new InvalidDataException($"The file could not be processed. Missing multipart content-type");
            }
        }
    }
}
