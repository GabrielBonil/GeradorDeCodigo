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
        /// <summary>
        /// Lista projetos com Web.Config dentro
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns>string[] - array</returns>
        public static string[] List_ProjectWebConfig(string rootDirectory)
        {
            return Directory.GetFiles(rootDirectory, "Web.config", SearchOption.AllDirectories);
        }
        /// <summary>
        /// Lista pastas com Web.Config dentro
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string[] - array</returns>
        public static string[] List_FolderWebConfigs(string path)
        {
            return Directory.GetFiles(path, $"Web.*.config", SearchOption.AllDirectories);
        }

        #endregion

        #region METODOS PARA RETORNO DE NOMES DE ARQUIVOS
        /// <summary>
        /// Traz o nome das pastas
        /// </summary>
        /// <param name="paths"></param>
        /// <returns> <code>List&lt;String&gt;</code></returns>
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
        /// <summary>
        /// Traz o nome dos Web.Config da pasta
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns> <code>List&lt;String&gt;</code></returns>

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
        
        /// <summary>
        /// Método que recebe os WebConfigs, compara ambos e faz sua alteração.
        /// Usa o campo "TipoTraduzido" do Mapping.json para verificar qual changer usar.
        /// </summary>
        /// <param name="originalDoc"></param>
        /// <param name="contentDoc"></param>
        public static void ChangeWebConfig(XElement originalDoc, XElement contentDoc)
        {
            foreach (var dado in MappingJsonRead())
            {
                switch (dado.Tipo)
                {
                    case ((int)MappingData.typeAction.Atributo):
                        Manipulator.AtributoXml(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, atributo: dado.Chave ,filtros: dado.Filtro ); break;
                    case ((int)MappingData.typeAction.Elemento):
                        Manipulator.ElementoXml(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, atributo: dado.Chave, filtros: dado.Filtro); break;
                    case ((int)MappingData.typeAction.Server):
                        Manipulator.ServerXml(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, atributo: dado.Chave, filtros: dado.Filtro); break;
                    case ((int)MappingData.typeAction.Direct):
                        Manipulator.DirectChange(contentDoc: contentDoc, originalDoc: originalDoc, mudar: dado.Mudar, filtros: dado.Filtro); break;
                    default:
                        break;
                }

            }


        }

        /// <summary>
        /// Metodo que chama o changeWebConfig e salva o novo WebConfig.
        /// </summary>
        /// <param name="pathOriginalWebConfig"></param>
        /// <param name="pathWebConfigBase"></param>
        public static void OverrideWebconfigAndSave(string pathOriginalWebConfig, string pathWebConfigBase)
        {

            XElement contentDoc = XElement.Load(pathWebConfigBase);
            XElement originalDoc = XElement.Load(pathOriginalWebConfig);


            Generator.ChangeWebConfig(originalDoc: originalDoc, contentDoc: contentDoc);

            originalDoc.Save(pathOriginalWebConfig);
        }
        #endregion

        #region LEITOR DE JSON
        /// <summary>
        /// Metodo para deserializar o JSON de forma correta.
        /// </summary>
        /// <returns> <code>List&lt;MappingData&gt;</code></returns>

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
