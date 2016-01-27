using System.Linq;
using Microsoft.AspNet.Mvc;
using TimeTracker.Model;

namespace TimeTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly TimeTrackerContext _dataContext;

        public HomeController(TimeTrackerContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var timelogs = _dataContext.TimeLogs.OrderBy(tl => tl.Start).ToList();
            return View();
        }
    }
}