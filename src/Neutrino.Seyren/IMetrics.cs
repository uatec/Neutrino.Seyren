using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Neutrino.Seyren
{
    public interface IMetrics
    {
        Task<Dictionary<string, long>> GetMetricCount(string target);  
    }

    /// <summary>
    /// https://github.com/scobal/seyren/blob/e40cdd0bf887ab1ca496fa9ca1772462c91cf263/seyren-api/src/main/java/com/seyren/api/bean/MetricsBean.java
    /// </summary>
    public partial class SeyrenClient : IMetrics
    {
        public IMetrics Metrics => (IMetrics) this;

        // GET - /api/metrics/{target}/total
        async Task<Dictionary<string, long>> IMetrics.GetMetricCount(string target)
        {
            string serialisedConfig = await this.httpClient.GetStringAsync($"/api/metrics/{target}/total");

            return JsonConvert.DeserializeObject<Dictionary<string, long>>(serialisedConfig);
        }
    }
}
