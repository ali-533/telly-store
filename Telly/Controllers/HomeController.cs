using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Telly.Models;
using Telly.Services;

namespace Telly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITellyService _tellyService;

        public HomeController(ILogger<HomeController> logger, ITellyService tellyService)
        {
            _logger = logger;
            _tellyService = tellyService;
        }

        // Adjusted to accept searchString from the navbar form query parameter
        public IActionResult Index(string? searchString, List<int>? selectedBrands, List<int>? selectedSizes, decimal? minPrice, decimal? maxPrice)
        {
            var brands = _tellyService.GetAllBrands();
            var dimensions = _tellyService.GetAllDimensions();

            // Get filtered TVs based on parameters
            var tvs = _tellyService.GetFilteredTvs(searchString, selectedBrands, selectedSizes, minPrice, maxPrice);

            ViewBag.Brands = brands;
            ViewBag.Dimensions = dimensions;
            ViewBag.Tvs = tvs;
            ViewBag.CurrentSearch = searchString;

            return View();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new CheckoutViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            // Server-side validation check
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Here you can deserialize model.CartJson if you want to save order items to your SQL Server database!

            TempData["SuccessMessage"] = $"Thank you, {model.FullName}! Your payment has been securely processed.";
            return RedirectToAction(nameof(OrderConfirmation));
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Accessory()
        {
            var accessories = _tellyService.GetAllAccessories();
            return View(accessories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}