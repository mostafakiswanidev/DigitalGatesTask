using DigitalGatesTask.Infastructure.Queues;
using DigitalGatesTask.Shared.Configurations;
using DigitalGatesTask.WebApp.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGatesTask.WebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IQueueProvider  _queueProvider;
        public UsersController(IQueueProvider queueProvider)
        {
            _queueProvider = queueProvider;
            _queueProvider.ConnectionString = AzureConfiguration.UserManagment.ConnectionString;
            _queueProvider.ServiceBusName = AzureConfiguration.UserManagment.Name;
        }

        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            await _queueProvider.SendMessageToTopicAsync(topic: AzureConfiguration.UserManagment.TopicName, model);

            return RedirectToAction("Index", "Home", new { result = "success"});
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
