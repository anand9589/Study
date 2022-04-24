using System.Security.Cryptography;
using System.Text;

namespace StringProblems
{
    public class Codec
    {
        Dictionary<string, byte[]> data;
        int num = 0;
        private readonly string baseUrl; 
        public Codec()
        {
            data = new Dictionary<string, byte[]>();
            num = 0;
            baseUrl = "http://ak.com/";
        }
        // Encodes a URL to a shortened URL
        public string Encode(string longUrl)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(longUrl);
            num++;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(baseUrl);
            stringBuilder.Append(num);
            data.Add(num.ToString(),bytes);
            return stringBuilder.ToString();
        }

        // Decodes a shortened URL to its original URL.
        public string Decode(string shortUrl)
        {
            shortUrl = shortUrl.ToLower().Replace(baseUrl, string.Empty);

            byte[] bytes = data[shortUrl];
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
