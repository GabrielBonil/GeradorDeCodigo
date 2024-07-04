using InterfaceWebConfig.DataClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CodGeneretor
{
    class Generator
    {
        #region METODOS DE LISTAGEM DE PATH
        public static string[] List_ProjectWebConfig(string rootDirectory)
        {
            return Directory.GetFiles(rootDirectory, "Web.config", SearchOption.AllDirectories);
        }

        public static string[] List_FolderWebConfigs(string path)
        {
            return Directory.GetFiles(path, $"Web.*.config", SearchOption.AllDirectories);
        }

        #endregion

        #region METODOS PARA RETORNO DE NOMES DE ARQUIVOS
        public static List<string> GetName_Folder(string[] paths)
        {
            List<string> folderNames = new List<string> { };
            foreach (var dir in paths)
            {
                string[] pathsName = Path.GetDirectoryName(dir).Split(Path.DirectorySeparatorChar);
                folderNames.Add((pathsName[pathsName.Length - 2] + "/" + pathsName.Last()));
            }
            return folderNames;
        }

        public static List<string> GetName_DocumentsInFolder(string[] folderPath)
        {
            List<string> docsName = new List<string> { };
            foreach (var doc in folderPath)
            {
                docsName.Add(Path.GetFileName(doc));
            }
            return docsName;
        }
        #endregion

        #region METODOS QUE TRATAM O WEBCONFIG
        public static void ChangeWebConfig(XElement originalDoc, XElement contentDoc)
        {
            foreach (var dado in MappingJsonRead())
            {
                switch (dado.TipoTraduzido)
                {
                    case "Atributo":
                        Manipulator.AtributoXml(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, atributo: dado.Chave ,filtros: dado.Filtro ); break;
                    case "Elemento":
                        Manipulator.ElementoXml(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, atributo: dado.Chave, filtros: dado.Filtro); break;
                    case "Server":
                        Manipulator.ServerXml(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, atributo: dado.Chave, filtros: dado.Filtro); break;
                    case "Direct":
                        Manipulator.DirectChange(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, filtros: dado.Filtro); break;
                    default:
                        break;
                }

            }


        }

        public static void OverrideWebconfigAndSave(string pathOriginalWebConfig, string pathWebConfigBase)
        {

            XElement contentDoc = XElement.Load(pathWebConfigBase);
            XElement originalDoc = XElement.Load(pathOriginalWebConfig);


            Generator.ChangeWebConfig(originalDoc: originalDoc, contentDoc: contentDoc);

            originalDoc.Save(pathOriginalWebConfig);
        }
        #endregion

        #region LEITOR DE JSON

        public static List<MappingData> MappingJsonRead()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Json\Mapping.json");
            string jsonString = File.ReadAllText(filePath);
            List<MappingData> dadosList = JsonConvert.DeserializeObject<List<MappingData>>(jsonString);
            return dadosList;
        }
        #endregion
    }
}
