using System.Collections.Generic;
using System.IO;
using System.Linq;
using Extensions;

namespace File_Manager
{
    public class TextFileManipulator : IFileManager
    {
        public string GetRawFileData()
        {
            return File.ReadLines("names.txt").FirstOrDefault();
        }

        public List<string> ConvertRawDataToList()
        {
            string rawData = GetRawFileData();            
            List<string> stringList = new List<string>();

            string[] stringArray = rawData.Split(',');

            foreach (var item in stringArray)
            {
                stringList.Add(item.RemoveQuotes());
            }

            return stringList;
        }

        // Maybe add a Quick Sort Algorithm here later
        public List<string> SortStringList()
        {
            List<string> list = ConvertRawDataToList();

            list.Sort();

            return list;
        }
    }
}
