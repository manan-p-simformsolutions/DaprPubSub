using ServiceOne.Interfaces;
using ServiceOne.Model;
using System.Net.Http;
using System.Threading.Tasks;
using static ServiceOne.Controllers.HomeController;

namespace ServiceOne.Helpers
{
    public class ServiceTwoHelper : IServiceTwoHelper
    {
        private readonly IDaprClientHelper _daprClientHelper;

        public ServiceTwoHelper(IDaprClientHelper daprClientHelper)
        {
            _daprClientHelper = daprClientHelper;
        }
        public async Task<string> GetMessage()
        {
            var response = await _daprClientHelper.ResponseByDaprClient<string>(HttpMethod.Get, "servicetwoapp", "/Home/GetMessage");
            return response;
        }

        public async Task<bool> PublishMessageTopic(int number)
        {
            return await _daprClientHelper.PublishToTopicWithDaprClient("pubsub", "publishmessage", new { Number = number });
        }
        public async Task<bool> PublishDataTopic(Order order)
        {
            return await _daprClientHelper.PublishToTopicWithDaprClient("pubsub", "publishdata", order);
        }
    }
}
