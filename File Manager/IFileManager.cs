using System.Collections.Generic;

namespace File_Manager
{
    public interface IFileManager
    {
        string GetRawFileData();
        List<string> ConvertRawDataToList();
    }
}
