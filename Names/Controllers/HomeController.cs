using System;
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

            // Delete previous sorted_names.txt
            if(System.IO.File.Exists("sorted_names.txt"))
                System.IO.File.Delete("sorted_names.txt");

            for (int i = 0; i < sortedStringList.Count - 1; i++)
            {
                string word = sortedStringList[i];
                int wordScore = WordCalculations.CalculateWordScore(word, i + 1);
                string wordScoreString = wordScore.ToString();

                // Save sorted Names list to file
                textFileManipulator.WriteStringToFile(word, wordScoreString);
                // Output Sorted List to ListBox
                outputListItems.Add(new SelectListItem() { Text = word + " - " + wordScoreString, Value = wordScoreString, Selected = false });
            }

            // Calculate Grand Total
            int grandTotal = WordCalculations.CalculateGrandTotalFromList(sortedStringList);

            // Question 1
            string highestTotalScoringName = WordCalculations.CalculateHighestTotalScoringNameFromList(sortedStringList);
            int highestTotalScoringNamePosition = WordCalculations.GetNamePositionFromList(sortedStringList, highestTotalScoringName);

            // Question 2
            string lowestTotalScoringName = WordCalculations.CalculateLowestTotalScoringNameFromList(sortedStringList);
            int lowestTotalScoringNamePosition = WordCalculations.GetNamePositionFromList(sortedStringList, lowestTotalScoringName);

            // Question 3
            Tuple<string, int> highestAlphabeticalValueAndName = WordCalculations.CalculateHighestAlphabeticalValueAndNameFromList(sortedStringList);
            string highestAlphabeticalValueName = highestAlphabeticalValueAndName.Item1;
            int highestAlphabeticalValue = highestAlphabeticalValueAndName.Item2;

            NamesModel namesModel = new NamesModel()
            {
                OriginalNames = originalListItems,
                OutputNames = outputListItems,
                GrandTotal = grandTotal.ToString(),
                HighestTotalScoringName = highestTotalScoringName,
                HighestTotalScoringNamePosition = highestTotalScoringNamePosition.ToString(),
                LowestTotalScoringName = lowestTotalScoringName,
                LowestTotalScoringNamePosition = lowestTotalScoringNamePosition.ToString(),
                HighestAlphabeticalValueName = highestAlphabeticalValueName,
                HighestAlphabeticalValue = highestAlphabeticalValue.ToString()
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
