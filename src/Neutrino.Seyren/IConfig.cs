using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Neutrino.Seyren
{
    public interface IConfig
    {
        Task<SeyrenConfig> GetConfig();
    }

    public partial class SeyrenClient : IConfig
    {
        public IConfig Config => (IConfig) this;

        // GET - /api/config
        async Task<SeyrenConfig> IConfig.GetConfig()
        {
            string serialisedConfig = await this.httpClient.GetStringAsync("/api/config");

            return JsonConvert.DeserializeObject<SeyrenConfig>(serialisedConfig);
        }
    }
}
