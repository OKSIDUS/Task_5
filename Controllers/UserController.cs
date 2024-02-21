using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Task_5.Interfaces;

namespace Task_5.Controllers
{
    public class UserController : Controller
    {
        private readonly IFakerService _fakerService;

        public UserController(IFakerService fakerService)
        {
            _fakerService = fakerService;
        }
        public IActionResult Index()
        {
            TempData["counter"] = 1;
            if (TempData.TryGetValue("Seed", out var seed) && TempData.TryGetValue("Region", out var region) && TempData.TryGetValue("error", out var error))
            {
                var page = TempData["page"];
                double errorValue = Convert.ToDouble(error, CultureInfo.InvariantCulture);
                var users = _fakerService.GenerateUsers(page==null ? 20 : (int)page*10, (region == "" ? "en_US" : region!.ToString()!), (int)seed!, errorValue);
                TempData["Seed"] = seed;
                TempData["error"] = error;
                TempData["Region"] = region;
                return View(users);
            }
            return View();


        }

        [HttpPost("ChangeFakerConfigure")]
        public IActionResult ChangeFakerConfigure(int seed, string error = "0", string region = "en_US")
        {
            _fakerService.ConfigureFaker(region, seed);

            TempData["Seed"] = seed;
            TempData["Region"] = region;
            TempData["error"] = error;


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult InfinityScroll(int page, int seed, string region, string error)
        {
            string errorVal = error.ToString().Replace('.', ',');
            double errorValue = Convert.ToDouble(errorVal);
            int countOfPage = page * 10;
            var users = _fakerService.GenerateUsers(countOfPage, region, seed, errorValue);
            users = users.Skip((page-1) * 10).Take(10);
            return PartialView("_UserListPartial", users);
        }
    }
}
