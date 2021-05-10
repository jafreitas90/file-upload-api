using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace File.Service.Utils
{
    public static class FileHelpers
    {
        public static async Task<byte[]> ProcessStreamedFile(
            MultipartSection section, long sizeLimit)
        {
            using (var memoryStream = new MemoryStream())
            {
                await section.Body.CopyToAsync(memoryStream);

                // Check if the file is empty or exceeds the size limit.
                if (memoryStream.Length == 0)
                {
                    throw new InvalidDataException("The file is empty.");
                }
                else if (memoryStream.Length > sizeLimit)
                {
                    var megabyteSizeLimit = sizeLimit / 1048576;
                    throw new InvalidDataException($"The file exceeds {megabyteSizeLimit:N1} MB.");
                }
                else
                {
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
