using System.Net.Http;
using System.Threading.Tasks;
using Neutrino.Seyren.Domain;
using Newtonsoft.Json;

namespace Neutrino.Seyren
{
    public interface ISubscriptions
    {
        Task<Subscription> Create(string checkId, Subscription subscription);

        Task<Subscription> Update(string checkId, string subscriptionId, Subscription subscription);
    
        Task Delete(string checkId, string subscriptionId);

        Task Test(string checkId, string subscriptionId);
    }

    public partial class SeyrenClient : ISubscriptions
    {
        public ISubscriptions Subscriptions => (ISubscriptions) this;

        // POST - /api/checks/{checkId}/subscriptions
        async Task<Subscription> ISubscriptions.Create(string checkId, Subscription subscription)
        {
            string serialisedCheck = JsonConvert.SerializeObject(subscription);

            HttpResponseMessage response = await this.httpClient.PostAsync($"/api/checks/{checkId}/subscriptions", new StringContent(serialisedCheck));

            response.EnsureSuccessStatusCode();

            string serialisedResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Subscription>(serialisedResponse);
        }

        // DELETE - /api/checks/{checkId}/subscriptions/{subscriptionId}
        async Task ISubscriptions.Delete(string checkId, string subscriptionId)
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync($"/api/checks/{checkId}/subscription");

            response.EnsureSuccessStatusCode();
        }

        // PUT - /api/checks/{checkId}/subscriptions/{subscriptionId}/test
        async Task ISubscriptions.Test(string checkId, string subscriptionId)
        {
            HttpResponseMessage response = await this.httpClient.PutAsync($"/checks/{checkId}/subscriptions/{subscriptionId}/test", new StringContent(""));

            response.EnsureSuccessStatusCode();
        }

        // PUT - /api/checks/{checkId}/subscriptions/{subscriptionId}
        async Task<Subscription> ISubscriptions.Update(string checkId, string subscriptionId, Subscription subscription)
        {
            string serialisedCheck = JsonConvert.SerializeObject(subscription);

            HttpResponseMessage response = await this.httpClient.PutAsync($"/api/checks/{checkId}/subscriptions", new StringContent(serialisedCheck));

            response.EnsureSuccessStatusCode();

            string serialisedResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Subscription>(serialisedResponse);
        }
    }
}
