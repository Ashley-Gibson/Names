using System.Collections.Generic;
using System.Diagnostics;
using Calculation_Manager;
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

            // Get Raw Name Data from file
            string rawData = textFileManipulator.GetRawFileData();

            // Convert Raw Name Data to list
            List<string> rawDataStringList = textFileManipulator.ConvertRawDataToList(rawData);

            foreach (var item in rawDataStringList)
                originalListItems.Add(new SelectListItem() { Text = item, Value = item, Selected = false });

            // Sort Names list
            List<string> sortedStringList = textFileManipulator.SortStringList(rawDataStringList);

            // Save sorted Names list to file
            textFileManipulator.SaveListToFile(sortedStringList);

            for (int i = 0; i < sortedStringList.Count - 1; i++)
            {
                string item = sortedStringList[i];
                int wordScore = WordCalculations.CalculateWordScore(item, i + 1);
                string wordScoreString = wordScore.ToString();
                outputListItems.Add(new SelectListItem() { Text = item + " - " + wordScoreString, Value = wordScoreString, Selected = false });
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
