using System.Collections.Generic;

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
    }
}
