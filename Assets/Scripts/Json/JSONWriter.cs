using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONWriter 
{
    public static void ExportFile(string fileName, string data, string path)
    {
        File.WriteAllText(Application.dataPath + path + "/" + fileName, data);
    }

    public static string GenerateJsonString(MusicSheet fullSong)
    {
        return JsonConvert.SerializeObject(fullSong);
    }
}
