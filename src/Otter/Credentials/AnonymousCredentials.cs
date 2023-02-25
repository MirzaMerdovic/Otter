using System.Net.Http;

namespace Otter
{
    public class AnonymousCredentials : Credentials
    {
        public override bool IsTlsCredentials()
        {
            return false;
        }

        public override void Dispose()
        {
        }

        public override HttpMessageHandler GetHandler(HttpMessageHandler innerHandler)
        {
            return innerHandler;
        }
    }
}