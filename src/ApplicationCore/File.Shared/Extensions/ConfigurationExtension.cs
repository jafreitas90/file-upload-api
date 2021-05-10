using System;
using Microsoft.Extensions.Configuration;

namespace File.Shared.Extensions
{
    public static class ConfigurationExtension
    {
        public static string GetKey(this IConfiguration configuration, string key)
        {
            if (string.IsNullOrWhiteSpace(configuration[key]))
            {
                throw new ArgumentException(String.Format($"It is missing the argument {key}"));
            }

            return configuration[key];
        }

        public static int GetKeyAsInt(this IConfiguration configuration, string key)
        {
            if (string.IsNullOrWhiteSpace(configuration[key]))
            {
                throw new ArgumentException(String.Format($"It is missing the argument {key}"));
            }
            if (Int32.TryParse(configuration[key], out int result))
            {
                return result;
            }
            throw new Exception($"Error converting to int. Key: {key}");
        }
    }
}
