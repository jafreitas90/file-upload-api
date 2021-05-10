using System.IO;
using MediatR;

namespace File.Service.Models.Request.File
{
    public class UploadFileRequest : IRequest<Unit>
    {
        public string ContentType { get; private set; }
        public Stream Body { get; private set; }

        public UploadFileRequest(string contentType, Stream body)
        {
            ContentType = contentType;
            Body = body;
        }
    }
}
