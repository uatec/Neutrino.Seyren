using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Neutrino.Seyren.Domain;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Neutrino.Seyren
{
    public class FieldRegex
    {
        public string FieldName { get; set; }
        public string Regex { get; set; }
    }

    public interface IChecks
    {
        Task<SeyrenResponse<Check>> GetAllAsync();
        Task<SeyrenResponse<Check>> GetAllAsync(
            AlertType[] states, 
            bool? enabled, 
            string name, 
            FieldRegex[] fieldRegexes);

        Task<Check> CreateAsync(Check check);

        Task<Check> GetAsync(string checkId);

        Task<Check> UpdateAsync(string checkId, Check check);

        Task Delete(string checkId);
    }

    /// <summary>
    /// https://github.com/scobal/seyren/blob/master/seyren-api/src/main/java/com/seyren/api/jaxrs/ChecksResource.java
    /// </summary>
    public partial class SeyrenClient : IChecks
    {
        public IChecks Checks => this;

        // POST /api/checks
        async Task<Check> IChecks.CreateAsync(Check check)
        {
            string serialisedCheck = JsonConvert.SerializeObject(check);
            HttpResponseMessage response = await this.httpClient.PostAsync("/api/checks", new StringContent(serialisedCheck));

            response.EnsureSuccessStatusCode();

            string serialisedResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Check>(serialisedResponse);
        }

        // DELETE - /api/checks/{checkId}
        async Task IChecks.Delete(string checkId)
        {
            HttpResponseMessage response = await this.httpClient.DeleteAsync($"/api/checks/{checkId}");

            response.EnsureSuccessStatusCode();
        }

        // /api/checks
        async Task<SeyrenResponse<Check>> IChecks.GetAllAsync()
        {
            string serialisedResponse = await this.httpClient.GetStringAsync("/api/checks");

            return JsonConvert.DeserializeObject<SeyrenResponse<Check>>(serialisedResponse);
        }

        // /api/checks
        async Task<SeyrenResponse<Check>> IChecks.GetAllAsync(
            AlertType[] states, 
            bool? enabled, 
            string name, 
            FieldRegex[] fieldRegexes)
        {
            StringBuilder queryString = new StringBuilder();

            if ( states != null )
            {
                foreach ( AlertType state in states )
                {
                    queryString.Append($"state={Enum.GetName(typeof(AlertType), state)}&");
                }
            }

            if ( enabled != null ) 
            {
                queryString.Append($"enabled={enabled.Value}&");
            }

            if ( name != null ) 
            {
                queryString.Append($"name={name}&");
            }

            if ( fieldRegexes != null )
            {
                foreach ( FieldRegex fieldRegex in fieldRegexes ) 
                {
                    queryString.Append($"fields={fieldRegex.FieldName}&regexes={fieldRegex.Regex}&");
                }
            }

            string serialisedResponse = await this.httpClient.GetStringAsync($"/api/checks?{queryString}");

            return JsonConvert.DeserializeObject<SeyrenResponse<Check>>(serialisedResponse);
        }

        // /api/checks/{checkId}
        async Task<Check> IChecks.GetAsync(string checkId)
        {
            string serialisedResponse = await this.httpClient.GetStringAsync($"/api/checks/{checkId}");

            return JsonConvert.DeserializeObject<Check>(serialisedResponse);
        }

        async Task<Check> IChecks.UpdateAsync(string checkId, Check check)
        {
            string serialisedCheck = JsonConvert.SerializeObject(check);
            HttpResponseMessage response = await this.httpClient.PutAsync($"/api/checks/{checkId}", new StringContent(serialisedCheck));

            response.EnsureSuccessStatusCode();

            string serialisedResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Check>(serialisedResponse);
        }
    }
}
