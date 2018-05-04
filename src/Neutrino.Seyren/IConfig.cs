namespace Neutrino.Seyren
{
    public interface IConfig
    {
        // GET - /config
        IConfig GetConfig();

        // GET - /api/metrics/{target}/total
        int GetMetricCount(string target);  
    }
}
