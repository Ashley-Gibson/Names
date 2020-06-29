using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculation_Manager
{
    public static class WordCalculations
    {
        private static Dictionary<char, int> Letters = new Dictionary<char, int>() 
        {
            { 'A', 1 },{ 'B', 2 },{ 'C', 3 },{ 'D', 4 },{ 'E', 5 },{ 'F', 6 },{ 'G', 7 },{ 'H', 8 },{ 'I', 9 },{ 'J', 10 },{ 'K', 11 },{ 'L', 12 },{ 'M', 13 },
            { 'N', 14 },{ 'O', 15 },{ 'P', 16 },{ 'Q', 17 },{ 'R', 18 },{ 'S', 19 },{ 'T', 20 },{ 'U', 21 },{ 'V', 22 },{ 'W', 23 },{ 'X', 24 },{ 'Y', 25 },{ 'Z', 26 }
        };

        public static int CalculateWordScore(string word, int index)
        {
            int wordScore = 0;

            foreach (char letter in word)
                wordScore += Letters[letter];

            wordScore *= index;

            return wordScore;
        }

        private static int CalculateAlphabeticalValue(string word, int index)
        {
            int wordScore = 0;

            foreach (char letter in word)
                wordScore += Letters[letter];

            return wordScore;
        }

        public static int CalculateGrandTotalFromList(List<string> list)
        {
            int grandTotal = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                string item = list[i];
                grandTotal += CalculateWordScore(item, i);
            }

            return grandTotal;
        }

        public static string CalculateHighestTotalScoringNameFromList(List<string> list)
        {
            string highestTotalScoringName = "";
            int highestWordScore = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                string item = list[i];
                int wordScore = CalculateWordScore(item, i + 1);
                if (wordScore > highestWordScore)
                {
                    highestWordScore = wordScore;
                    highestTotalScoringName = item;
                }
            }

            return highestTotalScoringName;
        }

        public static string CalculateLowestTotalScoringNameFromList(List<string> list)
        {
            string lowestTotalScoringName = "";
            int lowestWordScore = CalculateWordScore(list[list.Count - 1], list.Count);

            for (int i = list.Count - 1; i >= 0; i--)
            {
                string item = list[i];
                int wordScore = CalculateWordScore(item, i + 1);
                if (wordScore < lowestWordScore)
                {
                    lowestWordScore = wordScore;
                    lowestTotalScoringName = item;
                }
            }

            return lowestTotalScoringName;
        }

        public static Tuple<string, int> CalculateHighestAlphabeticalValueAndNameFromList(List<string> list)
        {
            string highestAlphabeticalValueName = "";
            int highestAlphabeticalValue = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                string item = list[i];
                int wordScore = CalculateAlphabeticalValue(item, i + 1);
                if (wordScore > highestAlphabeticalValue)
                {
                    highestAlphabeticalValueName = item;
                    highestAlphabeticalValue = wordScore;
                }
            }

            Tuple<string, int> highestAlphabeticalValueAndName = new Tuple<string, int>(highestAlphabeticalValueName, highestAlphabeticalValue);

            return highestAlphabeticalValueAndName;
        }

        public static Tuple<string, int> CalculateLowestAlphabeticalValueAndNameFromList(List<string> list)
        {
            string lowestAlphabeticalValueName = "";
            int lowestAlphabeticalValue = CalculateAlphabeticalValue(list[list.Count - 1], list.Count);

            for (int i = list.Count - 1; i >= 0; i--)
            {
                string item = list[i];
                int wordScore = CalculateAlphabeticalValue(item, i + 1);
                if (wordScore < lowestAlphabeticalValue)
                {
                    lowestAlphabeticalValueName = item;
                    lowestAlphabeticalValue = wordScore;
                }
            }

            Tuple<string, int> lowestAlphabeticalValueAndName = new Tuple<string, int>(lowestAlphabeticalValueName, lowestAlphabeticalValue);

            return lowestAlphabeticalValueAndName;
        }

        public static int CalculateAverageAlphabeticalValueFromList(List<string> list)
        {
            int totalAlphabeticalValueOfAllNames = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                string item = list[i];
                totalAlphabeticalValueOfAllNames += CalculateAlphabeticalValue(item, i);
            }

            int averageAlphabeticalValue = totalAlphabeticalValueOfAllNames / list.Count;

            return averageAlphabeticalValue;
        }

        public static int GetNamePositionFromList(List<string> list, string name)
        {
            int index = list.IndexOf(name);

            return index + 1;
        }
    }
}
