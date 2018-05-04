using Neutrino.Seyren.Domain;

namespace Neutrino.Seyren
{

    public interface ISubscription
    {
        // POST - /api/checks/{checkId}/subscriptions
        Subscription Create(Subscription subscription);

        // PUT - /api/checks/{checkId}/subscriptions/{subscriptionId}
        Subscription Update(string checkId, string subscriptionId, Subscription subscription);
    
        // DELETE - /api/checks/{checkId}
        void Delete(string checkId, string subscriptionId);

        // PUT - /api/checks/{checkId}/subscriptions/{subscriptionId}/test
        void Test(string checkId, string subscriptionId);
    }
}
