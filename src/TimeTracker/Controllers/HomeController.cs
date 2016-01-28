using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
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
            var timelogs = _dataContext.TimeLogs.Include(log => log.Client).OrderBy(tl => tl.Start).ToList();
            return View();
        }

        public IActionResult AddLog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLog(TimeLog log)
        {
            log.ClientId = 1;
            log.UserId = 1;
            _dataContext.TimeLogs.Add(log);
            _dataContext.SaveChanges();
            return View();
        }
    }
}