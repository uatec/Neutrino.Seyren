using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Neutrino.Seyren
{
    public interface IMetrics
    {
        // GET - /api/metrics/{target}/total
        Task<Dictionary<string, long>> GetMetricCount(string target);  
    }

    public partial class SeyrenClient : IMetrics
    {
        public IMetrics Metrics => (IMetrics) this;

        async Task<Dictionary<string, long>> IMetrics.GetMetricCount(string target)
        {
            string serialisedConfig = await this.httpClient.GetStringAsync($"/api/metrics/{target}/total");

            return JsonConvert.DeserializeObject<Dictionary<string, long>>(serialisedConfig);
        }
    }
}
