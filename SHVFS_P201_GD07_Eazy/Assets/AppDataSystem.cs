using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
namespace HacMan_GD07
{
    public class AppDataSystem
    {
        //This system will have generic methods to serialize or deserialize almost any kind of system we want.
        public static void Save<T>(T data,string fileName)
        {
            var directoryPath = $"{Application.dataPath}/StreamingAssets/" + typeof(T).Name;
            var filePath = directoryPath + "/" + fileName+".json";
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if(!File.Exists(filePath))
            {
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }
            var serializeData = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, serializeData);
                  
        }
        public static T Load<T>(string fileName)
        {
            var filePath = $"{Application.dataPath}/StreamingAssets/{typeof(T).Name}/{fileName}.json";
            if(!File.Exists(filePath))
            {
                T defaultObject = default;
                Save(defaultObject, fileName); 
            }
            var serializeData = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<T>(serializeData);
            return data;
        }
         

    }
}
