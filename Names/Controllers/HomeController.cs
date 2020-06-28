using System.Collections.Generic;
using System.Diagnostics;
using File_Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Names.Models;

namespace Names.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<SelectListItem> originalListItems = new List<SelectListItem>();
            List<SelectListItem> outputListItems = new List<SelectListItem>();

            TextFileManipulator textFileManipulator = new TextFileManipulator();

            List<string> rawDataStringList = textFileManipulator.ConvertRawDataToList();

            foreach (var item in rawDataStringList)
            {
                originalListItems.Add(new SelectListItem() { Text = item, Value = item, Selected = false });
            }

            List<string> sortedStringList = textFileManipulator.SortStringList();

            foreach (var item in sortedStringList)
            {
                outputListItems.Add(new SelectListItem() { Text = item, Value = item, Selected = false });
            }

            NamesModel namesModel = new NamesModel()
            {
                OriginalNames = originalListItems,
                OutputNames = outputListItems
            };

            return View(namesModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
