using ServiceOne.Model;
using System.Threading.Tasks;
using static ServiceOne.Controllers.HomeController;

namespace ServiceOne.Interfaces
{
    public interface IServiceTwoHelper
    {
        Task<string> GetMessage();
        Task<bool> PublishMessageTopic(int number);
        Task<bool> PublishDataTopic(Order order);

    }
}
