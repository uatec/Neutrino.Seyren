using System;
using Neutrino.Seyren.Domain;

namespace Neutrino.Seyren
{
    public interface IAlerts
    {
        // /api/checks/{checkid}/alerts
        SeyrenResponse<Alert> GetByCheckId(string checkid);
        SeyrenResponse<Alert> GetByCheckId(string checkid, int start, int items);

        // /api/checks/{checkid}/alerts
        void Delete(string checkId);
        void Delete(string checkId, DateTimeOffset before);

        // /api/alerts
        SeyrenResponse<Alert> GetAll();
        SeyrenResponse<Alert> GetAll(int start, int items);
    }
}
