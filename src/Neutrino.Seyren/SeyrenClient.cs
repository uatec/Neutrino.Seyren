using System.Net.Http;

namespace Neutrino.Seyren
{
    public partial class SeyrenClient
    {
        private readonly HttpClient httpClient;

        public SeyrenClient(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
        }
    }
}
