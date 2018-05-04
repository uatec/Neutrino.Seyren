using System;
using System.Net.Http;
using System.Threading.Tasks;
using Neutrino.Seyren.Domain;
using Newtonsoft.Json;

namespace Neutrino.Seyren
{
    public interface IAlerts
    {
        Task<SeyrenResponse<Alert>> GetByCheckId(string checkId);
        Task<SeyrenResponse<Alert>> GetByCheckId(string checkId, int start, int items);

        Task Delete(string checkId);
        Task Delete(string checkId, DateTimeOffset before);

        Task<SeyrenResponse<Alert>> GetAll();
        Task<SeyrenResponse<Alert>> GetAll(int start, int items);
    }

    /// <summary>
    /// https://github.com/scobal/seyren/blob/master/seyren-api/src/main/java/com/seyren/api/jaxrs/AlertsResource.java
    /// </summary>
    public partial class SeyrenClient : IAlerts
    {
        public IAlerts Alerts => (IAlerts) this;

        async Task IAlerts.Delete(string checkId)
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync($"/api/checks/{checkId}/alerts");

            response.EnsureSuccessStatusCode();
        }

        async Task IAlerts.Delete(string checkId, DateTimeOffset before)
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync($"/api/checks/{checkId}/alerts?before={before:o}");

            response.EnsureSuccessStatusCode();
        }

        async Task<SeyrenResponse<Alert>> IAlerts.GetAll()
        {
            string serialisedResponse = await this.httpClient.GetStringAsync($"/api/alerts");

            return JsonConvert.DeserializeObject<SeyrenResponse<Alert>>(serialisedResponse);
        }

        /// /api/alerts
        async Task<SeyrenResponse<Alert>> IAlerts.GetAll(int start, int items)
        {
            string serialisedResponse = await this.httpClient.GetStringAsync($"/api/alerts?start={start}&items={items}");

            return JsonConvert.DeserializeObject<SeyrenResponse<Alert>>(serialisedResponse);
        }

        // /api/checks/{checkid}/alerts
        async Task<SeyrenResponse<Alert>> IAlerts.GetByCheckId(string checkId)
        {
            string serialisedResponse = await this.httpClient.GetStringAsync($"/api/checks/{checkId}/alerts");

            return JsonConvert.DeserializeObject<SeyrenResponse<Alert>>(serialisedResponse);
        }

        // /api/checks/{checkid}/alerts
        async Task<SeyrenResponse<Alert>> IAlerts.GetByCheckId(string checkId, int start, int items)
        {
            string serialisedResponse = await this.httpClient.GetStringAsync($"/api/checks/{checkId}/alerts?start={start}&items={items}");

            return JsonConvert.DeserializeObject<SeyrenResponse<Alert>>(serialisedResponse);
        }
    }
}
