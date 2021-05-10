using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace File.Service.Utils
{
    public static class CsvHelpers
    {
        public static IEnumerable<T> GetRecords<T>(byte[] streamedFileContent)
        {
            using (var memoryStream = new MemoryStream(streamedFileContent))
            using (var reader = new StreamReader(memoryStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
