using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Neutrino.Seyren
{
    public interface ICharts
    {
        Task GetChart(string checkId);
        Task GetChart(string checkId, 
            int? width = null, 
            int? height = null, 
            string from = null, 
            string to = null, 
            bool? hideThresholds = null, 
            bool? hideLegend = null, 
            bool? hideAxes = null);

        Task<Stream> GetChartForTarget(string target);
        Task<Stream> GetChartForTarget(string target,
            int? width, 
            int? height, 
            string from, 
            string to, 
            bool? hideThresholds, 
            bool? hideLegend, 
            bool? hideAxes);
    }

    /// <summary>
    /// https://github.com/scobal/seyren/blob/master/seyren-api/src/main/java/com/seyren/api/jaxrs/ChartsResource.java
    /// </summary>
    public partial class SeyrenClient : ICharts
    {
        public ICharts Charts => (ICharts) this;

        // /api/checks/{checkid}/image
        Task ICharts.GetChart(string checkId)
        {
            return this.httpClient.GetStreamAsync($"/api/checks/{checkId}/image");
        }

        // /api/checks/{checkid}/image
        Task ICharts.GetChart(string checkId, 
            int? width, 
            int? height, 
            string from, 
            string to, 
            bool? hideThresholds, 
            bool? hideLegend, 
            bool? hideAxes)
        {
            StringBuilder queryString = new StringBuilder();

            if ( width != null )
            {
                queryString.Append($"width={width}&");
            }

            if ( height != null )
            {
                queryString.Append($"height={height}&");
            }

            if ( from != null )
            {
                queryString.Append($"from={from}&");
            }

            if ( to != null )
            {
                queryString.Append($"to={to}&");
            }

            if ( hideThresholds != null )
            {
                queryString.Append($"hideThresholds={hideThresholds}&");
            }

            if ( hideLegend != null )
            {
                queryString.Append($"hideLegend={hideLegend}&");
            }

            if ( hideAxes != null )
            {
                queryString.Append($"hideAxes={hideAxes}&");
            }

            return this.httpClient.GetStreamAsync($"/api/checks/{checkId}/image");
        }

        // /api/chart/{target}
        Task<Stream> ICharts.GetChartForTarget(string target)
        {
            return this.httpClient.GetStreamAsync($"/api/chart/{target}");
        }

        // /api/chart/{target}
        Task<Stream> ICharts.GetChartForTarget(string target,
            int? width, 
            int? height, 
            string from, 
            string to, 
            bool? hideThresholds, 
            bool? hideLegend, 
            bool? hideAxes)
        {
            StringBuilder queryString = new StringBuilder();

            if ( width != null )
            {
                queryString.Append($"width={width}&");
            }

            if ( height != null )
            {
                queryString.Append($"height={height}&");
            }

            if ( from != null )
            {
                queryString.Append($"from={from}&");
            }

            if ( to != null )
            {
                queryString.Append($"to={to}&");
            }

            if ( hideThresholds != null )
            {
                queryString.Append($"hideThresholds={hideThresholds}&");
            }

            if ( hideLegend != null )
            {
                queryString.Append($"hideLegend={hideLegend}&");
            }

            if ( hideAxes != null )
            {
                queryString.Append($"hideAxes={hideAxes}&");
            }

            return this.httpClient.GetStreamAsync($"/api/chart/{target}?{queryString}");
        }
    }
}
