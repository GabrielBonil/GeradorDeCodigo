using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace JsonMapAdd
{
    public class JsonThings
    {
        public static string FindTargetDirectory(string currentDirectory, string targetDirectory)
        {
            string currentDirName = new DirectoryInfo(currentDirectory).Name;

            if (string.Equals(currentDirName, targetDirectory, StringComparison.OrdinalIgnoreCase))
            {
                return currentDirectory;
            }

            DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory);

            if (parentDirectory == null)
            {
                return null;
            }

            return FindTargetDirectory(parentDirectory.FullName, targetDirectory);
        }

        public static List<MappingData> MappingJsonRead()
        {
            string path = JsonThings.FindTargetDirectory(AppDomain.CurrentDomain.BaseDirectory, "GeradorDeCodigo");
            path = path + @"\InterfaceWebConfig\Json\Mapping.json";
            string jsonMap = File.ReadAllText(path);
            List<MappingData> dadosList = JsonConvert.DeserializeObject<List<MappingData>>(jsonMap);

            return dadosList;
        }

        public static void OverrideJson(List<MappingData> json)
        {
            foreach (var dado in json)
            {
                dado.TipoTraduzido = MappingData.Type[dado.Tipo];
            }
            File.WriteAllText(JsonThings.FindTargetDirectory(AppDomain.CurrentDomain.BaseDirectory, "GeradorDeCodigo") + @"\InterfaceWebConfig\Json\Mapping.json", System.Text.Json.JsonSerializer.Serialize(json));
        }
    }
}
