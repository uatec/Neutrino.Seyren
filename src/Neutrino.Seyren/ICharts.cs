namespace Neutrino.Seyren
{
    public interface ICharts
    {
        // /api/checks/{checkid}/image
        void GetChart(string checkId);
        void GetChart(string checkId, int width = 0, int height = 0, string from = null, string to = null, bool hideThresholds = false, bool hideLegend = false, bool hideAxes = false);

        // /api/chart/{target}
        byte[] GetChartForTarget(string target);
        byte[] GetChartForTarget(string target, int width = 0, int height = 0, string from = null, string to = null, bool hideThresholds = false, bool hideLegend = false, bool hideAxes = false);
    }
}
