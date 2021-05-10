using File.Shared.Extensions;
using Microsoft.Extensions.Configuration;

namespace File.Shared.Utils
{
    public class ApplicationSettings
    {
        private IConfiguration _configuration;

        public ApplicationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int FileSizeLimit => _configuration.GetKeyAsInt($"{Constants.File}:{Constants.FileSizeLimit}");
        public string StoredFilesPath => _configuration.GetKey($"{Constants.File}:{Constants.StoredFilesPath}");
    }
}
