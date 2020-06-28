﻿using System.Collections.Generic;
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

        public List<string> ConvertRawDataToList(string rawData)
        {           
            List<string> stringList = new List<string>();

            string[] stringArray = rawData.Split(',');

            foreach (var item in stringArray) 
                stringList.Add(item.RemoveQuotes());

            return stringList;
        }

        // Maybe add a Quick Sort Algorithm here later
        public List<string> SortStringList(List<string> list)
        {
            list.Sort();

            return list;
        }

        public void SaveListToFile(List<string> list)
        {
            File.WriteAllLines("sorted_names.txt", list);
        }
    }
}
