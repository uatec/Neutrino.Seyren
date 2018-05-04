namespace Neutrino.Seyren.Domain
{
    public static class AlertTypeExtensions
    {
        public static bool IsWorseThan(this AlertType self, AlertType other)
        {
           return self > other;
        }
    }
}
