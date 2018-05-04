using Neutrino.Seyren.Domain;

namespace Neutrino.Seyren
{
    public interface IChecks
    {
        // /api/checks
        SeyrenResponse<Check> GetAll();
        SeyrenResponse<Check> GetAll(AlertType[] states, bool enabled, string name, string fields, string regexes);

        // POST /api/checks
        Check Create(Check check);

        // /api/checks/{checkId}
        Check Get(string checkId);

        // PUT /api/checks/{checkId}
        Check Update(string checkId, Check check);

        // DELETE - /api/checks/{checkId}
        void Delete(string checkId);
    }
}
