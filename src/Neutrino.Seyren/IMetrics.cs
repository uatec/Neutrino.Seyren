namespace Neutrino.Seyren
{
    public interface IMetrics
    {
        // GET - /api/metrics/{target}/total
        int GetMetricCount(string target);  
    }
}
